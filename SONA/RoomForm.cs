// RoomForm.cs (viết lại hoàn toàn với async/await để tối ưu UI, ổn định kết nối)
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace SONA
{
    public partial class RoomForm : UserControl
    {
        private string roomId, userId, userName, role;
        private TcpClient client;
        private NetworkStream stream;
        private BinaryReader reader;
        private BinaryWriter writer;
        private List<string> songIds = new List<string>();
        private int currentSongIndex = 0;
        private string currentSongUrl;

        private WaveOutEvent woe;
        private AudioFileReader afr;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        // Các trường cho chat room 
        private TcpClient chatClient;
        private NetworkStream chatStream;
        private BinaryWriter chatWriter;
        private BinaryReader chatReader;
        private Thread chatListenThread;


        public RoomForm(string roomId, string userId, string role, string userName)
        {
            InitializeComponent();
            this.roomId = roomId;
            this.userId = userId;
            this.role = role;
            this.userName = userName;

            this.Load += RoomForm_Load;
            this.Disposed += RoomForm_Disposed;

            btnPlayMusic.Click += BtnPlay_Click;
            btnNext.Click += BtnNext_Click;
            btnPrev.Click += BtnPrev_Click;
            btnShuffle.Click += BtnShuffle_Click;
            btnReplay.Click += BtnReplay_Click;
            tbsTimeSong.Scroll += tbsTimeSong_Scroll;

            timer.Interval = 500;
            timer.Tick += Timer_Tick;
        }

        private async void RoomForm_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectToServer();
                songIds = LoadSongList();

                lbRoomID.Text = $"Room ID: {roomId}";
                lbHostName.Text = role == "host" ? $"Host: {userName}" : "Client";

                if (songIds.Count > 0)
                {
                    currentSongIndex = 0;
                    await PlaySongAsync(songIds[0]);
                }

                CreatePlaylist();
                InitChat();

                _ = Task.Run(() => ListenRoom(cancellationTokenSource.Token));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo phòng: " + ex.Message);
            }
        }

        private void ConnectToServer()
        {
            
            client = new TcpClient();
            client.Connect(IPAddressServer.serverIP, 5000);
            stream = client.GetStream();
            reader = new BinaryReader(stream, Encoding.UTF8, true);
            writer = new BinaryWriter(stream, Encoding.UTF8, true);
        }

        private List<string> LoadSongList()
        {
            var songList = new List<string>();
            TcpClient songClient = null;
            NetworkStream stream = null;
            BinaryReader reader = null;
            BinaryWriter writer = null;
            try
            {
                
                songClient = new TcpClient();
                songClient.Connect(IPAddressServer.serverIP, 5000);
                stream = songClient.GetStream();
                reader = new BinaryReader(stream, Encoding.UTF8, true);
                writer = new BinaryWriter(stream, Encoding.UTF8, true);

                writer.Write("getIDSong");
                if (reader.ReadString() == "OK")
                {
                    int count = reader.ReadInt32();
                    for (int i = 0; i < count; i++)
                        songList.Add(reader.ReadString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy danh sách bài hát: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                writer?.Close();
                stream?.Close();
                songClient?.Close();
            }
            return songList;
        }

        private async Task PlaySongAsync(string songId)
        {
            StopMusic();
            currentSongIndex = songIds.IndexOf(songId);

            string name = "", picture = "", songUrl = "";
            TcpClient playClient = null;
            NetworkStream stream = null;
            BinaryReader reader = null;
            BinaryWriter writer = null;
            try
            {
                
                playClient = new TcpClient();
                playClient.Connect(IPAddressServer.serverIP, 5000);
                stream = playClient.GetStream();
                reader = new BinaryReader(stream, Encoding.UTF8, true);
                writer = new BinaryWriter(stream, Encoding.UTF8, true);

                writer.Write("listenMusic");
                writer.Write(songId);
                if (reader.ReadString() != "OK") return;
                name = reader.ReadString();
                reader.ReadString(); reader.ReadString(); reader.ReadString(); reader.ReadString();
                picture = reader.ReadString();
                songUrl = reader.ReadString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy thông tin bài hát: " + ex.Message);
                return;
            }
            finally
            {
                reader?.Close();
                writer?.Close();
                stream?.Close();
                playClient?.Close();
            }

        string tempPath = Path.GetTempFileName();
            await Task.Run(() => new System.Net.WebClient().DownloadFile(currentSongUrl, tempPath));

            afr = new AudioFileReader(tempPath);
            woe = new WaveOutEvent();
            woe.Init(afr);
            woe.PlaybackStopped += OnPlaybackStopped;

            lblEnd.Invoke((MethodInvoker)(() =>
            {
                lblEnd.Text = afr.TotalTime.ToString("mm\\:ss");
                tbsTimeSong.Value = 0;
                lblProcess.Text = "00:00";
            }));

            woe.Play();
            timer.Start();
            if (role == "host") SendMusicSync("play", 0);
        }

        private void CreatePlaylist()
        {
            pnPlaylist.Controls.Clear();
            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.FromArgb(17, 17, 17)
            };

            var titleLabel = new Guna.UI2.WinForms.Guna2HtmlLabel
            {
                Text = "Playlist",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Margin = new Padding(10, 10, 10, 20)
            };
            flowPanel.Controls.Add(titleLabel);

            foreach (string id in songIds)
            {
                SongSearch item = new SongSearch(null, id, userId, songIds)
                {
                    Width = pnPlaylist.Width - 20,
                    Margin = new Padding(5)
                };
                item.Click += async (s, e) => await PlaySongAsync(id);
                AddClickEventToChildren(item, id);
                flowPanel.Controls.Add(item);
            }
            pnPlaylist.Controls.Add(flowPanel);
        }

        private void AddClickEventToChildren(Control parent, string songId)
        {
            foreach (Control child in parent.Controls)
            {
                child.Click += async (sender, e) => await PlaySongAsync(songId);
                AddClickEventToChildren(child, songId);
            }
        }

        private void StopMusic()
        {
            timer.Stop();
            woe?.Stop();
            afr?.Dispose();
            woe?.Dispose();
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            BtnNext_Click(null, null);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (afr == null) return;
            lblProcess.Text = afr.CurrentTime.ToString("mm\\:ss");
            tbsTimeSong.Value = (int)(afr.CurrentTime.TotalMilliseconds / afr.TotalTime.TotalMilliseconds * 100);
        }

        private async void BtnPlay_Click(object sender, EventArgs e)
        {
            if (woe == null) return;
            if (woe.PlaybackState == PlaybackState.Playing)
            {
                woe.Pause();
                timer.Stop();
                if (role == "host") SendMusicSync("pause", afr.CurrentTime.TotalMilliseconds);
            }
            else
            {
                woe.Play();
                timer.Start();
                if (role == "host") SendMusicSync("play", afr.CurrentTime.TotalMilliseconds);
            }
        }

        private async void BtnNext_Click(object sender, EventArgs e)
        {
            currentSongIndex = (currentSongIndex + 1) % songIds.Count;
            await PlaySongAsync(songIds[currentSongIndex]);
            if (role == "host") SendMusicSync("next", 0);
        }

        private async void BtnPrev_Click(object sender, EventArgs e)
        {
            currentSongIndex = (currentSongIndex - 1 + songIds.Count) % songIds.Count;
            await PlaySongAsync(songIds[currentSongIndex]);
            if (role == "host") SendMusicSync("prev", 0);
        }

        private async void BtnShuffle_Click(object sender, EventArgs e)
        {
            var rng = new Random();
            for (int i = songIds.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (songIds[i], songIds[j]) = (songIds[j], songIds[i]);
            }
            currentSongIndex = 0;
            await PlaySongAsync(songIds[0]);
        }

        private void BtnReplay_Click(object sender, EventArgs e)
        {
            woe.PlaybackStopped -= OnPlaybackStopped;
            woe.PlaybackStopped += (s, ev) => this.Invoke((MethodInvoker)(() => _ = PlaySongAsync(songIds[currentSongIndex])));

        }

        private void tbsTimeSong_Scroll(object sender, ScrollEventArgs e)
        {
            if (afr != null)
            {
                int newPosition = (int)(afr.TotalTime.TotalMilliseconds * tbsTimeSong.Value / 100);
                afr.CurrentTime = TimeSpan.FromMilliseconds(newPosition);
            }
        }

        private void SendMusicSync(string action, double position)
        {
            TcpClient syncClient = null;
            NetworkStream stream = null;
            BinaryWriter writer = null;
            try
            {
                
                syncClient = new TcpClient();
                syncClient.Connect(IPAddressServer.serverIP, 5000);
                stream = syncClient.GetStream();
                writer = new BinaryWriter(stream, Encoding.UTF8, true);

                writer.Write("musicSync");
                writer.Write(roomId);
                writer.Write(action);
                writer.Write(songIds[currentSongIndex]);
                writer.Write(position);
            }
            catch (Exception ex)
            {
                // Có thể log 
            }
            finally
            {
                writer?.Close();
                stream?.Close();
                syncClient?.Close();
            }
        }


        private void ListenRoom(CancellationToken token)
        {
            TcpClient listenClient = null;
            NetworkStream stream = null;
            BinaryReader reader = null;
            try
            {
                
                listenClient = new TcpClient();
                listenClient.Connect(IPAddressServer.serverIP, 5000);
                stream = listenClient.GetStream();
                reader = new BinaryReader(stream, Encoding.UTF8, true);

                while (!token.IsCancellationRequested)
                {
                    string type = reader.ReadString();
                    if (type == "musicSync")
                    {
                        string action = reader.ReadString();
                        string songId = reader.ReadString();
                        double pos = reader.ReadDouble();
                        this.Invoke((MethodInvoker)(() =>
                        {
                            if (songId != songIds[currentSongIndex])
                                _ = PlaySongAsync(songId);
                            afr.CurrentTime = TimeSpan.FromMilliseconds(pos);
                            if (action == "pause")
                            {
                                woe.Pause();
                                timer.Stop();
                            }
                            else if (action == "play")
                            {
                                woe.Play();
                                timer.Start();
                            }
                            else if (action == "next")
                            {
                                BtnNext_Click(null, null);
                            }
                            else if (action == "prev")
                            {
                                BtnPrev_Click(null, null);
                            }
                        }));
                       
                    
                    }
                }
            }
            catch (Exception ex) 
            {
            
            }
            finally
            {
                reader?.Close();
                stream?.Close();
                listenClient?.Close();
            }
        }

        #region Chat 
        private void InitChat()
        {
            if (string.IsNullOrEmpty(IPAddressServer.serverIP))
            {
                MessageBox.Show("Địa chỉ server chưa được cấu hình hoặc bị null!");
                return;
            }
            try
            {
                chatClient = new TcpClient();
                chatClient.Connect(IPAddressServer.serverIP, 5000);
                chatStream = chatClient.GetStream();
                chatWriter = new BinaryWriter(chatStream, Encoding.UTF8, true);
                chatReader = new BinaryReader(chatStream, Encoding.UTF8, true);

                chatWriter.Write("roomChat");
                chatWriter.Write(roomId);
                chatWriter.Write(userId);
                chatWriter.Write(userName);

                chatListenThread = new Thread(ListenRoomChat);
                chatListenThread.IsBackground = true;
                chatListenThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo chat room: " + ex.Message);
            }
        }

        private void btSendMessage_Click(object sender, EventArgs e)
        {
            string message = tbEnterChat.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                // Hiển thị tin nhắn của mình lên giao diện
                displayChatMessage("You", message);

                // Gửi lên server
                try
                {
                    chatWriter.Write("roomMessage");
                    chatWriter.Write(roomId);
                    chatWriter.Write(userId);
                    chatWriter.Write(userName);
                    chatWriter.Write(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi gửi tin nhắn: " + ex.Message);
                }
                tbEnterChat.Clear();
            }
        }

        private void displayChatMessage(string username, string message)
        {
            pnLayout.Invoke((MethodInvoker)delegate
            {
                FlowLayoutPanel frame = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    AutoSize = true,
                    Margin = new Padding(0, 0, 0, 0)
                };
                Label lbu = new Label
                {
                    Text = username,
                    Font = new Font("Segoe UI", 8, FontStyle.Bold),
                    Margin = new Padding(0, 0, 5, -1),
                };
                Label messageLabel = new Label
                {
                    Text = message,
                    AutoSize = true,
                    Padding = new Padding(10),
                    Margin = new Padding(0),
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                };

                frame.Controls.Add(lbu);
                frame.Controls.Add(messageLabel);

                pnLayout.Controls.Add(frame);
                pnLayout.ScrollControlIntoView(frame);
            });
        }

        private void ListenRoomChat()
        {
            try
            {
                while (true)
                {
                    string type = chatReader.ReadString();
                    if (type == "message")
                    {
                        string msg = chatReader.ReadString();
                        // Giả sử server gửi về dạng "username: message"
                        int idx = msg.IndexOf(':');
                        if (idx > 0)
                            displayChatMessage(msg.Substring(0, idx), msg.Substring(idx + 1).Trim());
                        else
                            displayChatMessage("Server", msg);
                    }
                }
            }
            catch { }
            finally
            {
                chatReader?.Close();
                chatWriter?.Close();
                chatStream?.Close();
                chatClient?.Close();
            }
        }

        #endregion 



        private void RoomForm_Disposed(object sender, EventArgs e)
        {
            try
            {
                cancellationTokenSource.Cancel();
                writer.Write("leaveRoom");
                writer.Write(roomId);
                writer.Write(userId);
            }
            catch { }
            stream?.Close();
            client?.Close();
            StopMusic();

            try
            {
                chatListenThread?.Abort();
            }
            catch { }
            chatReader?.Close();
            chatWriter?.Close();
            chatStream?.Close();
            chatClient?.Close();
        }
    }

}
