using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;
using System.Collections.Generic;
using NAudio.Wave;
using System.Drawing;
namespace SONA
{
    public partial class RoomForm : UserControl
    {
        private string roomId;
        private string userId;
        private string role; // "host" hoặc "client"
        private string userName;
        private TcpClient client;
        private NetworkStream stream;
        private ChatBox chatBoxControl;
        private Thread listenThread;
        private bool isClosing = false;
        private List<string> songIds = new List<string>();
        private List<string> originalSongIds = new List<string>();
        private string id_song, name_song, picture_song, am_thanh;
        private bool isPlaying = false;
        private bool isAutoReplay = false;
        private bool isShuffled = false;
        private WaveOutEvent woe;
        private AudioFileReader afr;
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        public RoomForm(string roomId, string userId, string role, string userName)
        {
            InitializeComponent();
            this.roomId = roomId;
            this.userId = userId;
            this.role = role;
            this.userName = userName;

            lbRoomID.Text = $"Room ID: {roomId}";
            lbHostName.Text = $"Host: {userName}";

            // Kết nối TCP riêng cho phòng
            try
            {
                client = new TcpClient(IPAddressServer.serverIP, 5000);
                stream = client.GetStream();

                LoadSongList();
                originalSongIds = new List<string>(songIds);
                id_song = songIds.Count > 0 ? songIds[0] : null;

                chatBoxControl = new ChatBox(roomId, userId, userName);
                chatBoxControl.Dock = DockStyle.Fill;
                pnChat.Controls.Clear();
                pnChat.Controls.Add(chatBoxControl);

                if (songIds.Count > 0)
                {
                    CreatePlaylist();
                    PlaySong(id_song);
                }

                // Gắn event handler cho các nút
                btnPlayMusic.Click += btnPlayMusic_Click;
                btnNext.Click += btnNext_Click;
                btnPrev.Click += btnPrev_Click;
                btnShuffle.Click += btnShuffle_Click;
                btnReplay.Click += btnReplay_Click;
                tbsTimeSong.Scroll += tbsTimeSong_Scroll;
                timer1.Interval = 500;
                timer1.Tick += timer1_Tick;

                listenThread = new Thread(ListenRoom);
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối phòng: " + ex.Message);
            }

            this.Disposed += RoomForm_Disposed;
        }

        private void LoadSongList()
        {
            try
            {
                using (TcpClient tempClient = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream tempStream = tempClient.GetStream())
                using (BinaryWriter writer = new BinaryWriter(tempStream))
                using (BinaryReader reader = new BinaryReader(tempStream))
                {
                    writer.Write("getIDSong");
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        int songCount = reader.ReadInt32();
                        songIds.Clear();
                        for (int i = 0; i < songCount; i++)
                        {
                            string songId = reader.ReadString();
                            songIds.Add(songId);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi lấy danh sách bài hát: " + response);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối server: " + ex.Message);
            }
        }

        private void CreatePlaylist()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => CreatePlaylist()));
                return;
            }

            pnPlaylist.Controls.Clear();
            
            // Tạo FlowLayoutPanel để sắp xếp các bài hát
            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            flowPanel.Dock = DockStyle.Fill;
            flowPanel.AutoScroll = true;
            flowPanel.FlowDirection = FlowDirection.TopDown;
            flowPanel.WrapContents = false;
            flowPanel.BackColor = System.Drawing.Color.FromArgb(17, 17, 17);

            Guna.UI2.WinForms.Guna2HtmlLabel titleLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            titleLabel.Text = "Playlist";
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold);
            titleLabel.ForeColor = System.Drawing.Color.White;
            titleLabel.AutoSize = true;
            titleLabel.Margin = new Padding(10, 10, 10, 20);
            flowPanel.Controls.Add(titleLabel);

            foreach (string songId in songIds)
            {
                SongSearch songItem = new SongSearch(null, songId, userId, songIds);
                songItem.Width = pnPlaylist.Width - 20;
                songItem.Margin = new Padding(5);
                songItem.Click += (sender, e) => PlaySong(songId);
                AddClickEventToChildren(songItem, songId);
                flowPanel.Controls.Add(songItem);
            }
            pnPlaylist.Controls.Add(flowPanel);
        }

        private void AddClickEventToChildren(Control parent, string songId)
        {
            foreach (Control child in parent.Controls)
            {
                child.Click += (sender, e) => PlaySong(songId);
                AddClickEventToChildren(child, songId);
            }
        }

        private void PlaySong(string songId)
        {
            StopMusicAndDispose();
            id_song = songId;
            // Lấy thông tin bài hát từ server
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("listenMusic");
                    writer.Write(id_song);
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        name_song = reader.ReadString();
                        reader.ReadString(); // id_singer (bỏ qua)
                        reader.ReadString(); // name_singer (bỏ qua)
                        reader.ReadString(); // picture_singer (bỏ qua)
                        reader.ReadString(); // birthdate (bỏ qua)
                        picture_song = reader.ReadString();
                        am_thanh = reader.ReadString();
                    }
                    else
                    {
                        MessageBox.Show(response);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
                return;
            }
            // Load ảnh bài hát
            try
            {
                using (var wc = new System.Net.WebClient())
                using (var stream = wc.OpenRead(picture_song))
                {
                    pbPictureSong.Image = Image.FromStream(stream);
                }
            }
            catch { pbPictureSong.Image = null; }
            lbNameSong.Text = name_song;
            // Phát nhạc
            try
            {
                string tempFile = Path.GetTempFileName();
                using (var wc = new System.Net.WebClient())
                    wc.DownloadFile(new Uri(am_thanh), tempFile);
                afr = new AudioFileReader(tempFile);
                if (woe == null)
                {
                    woe = new WaveOutEvent();
                    woe.PlaybackStopped += OnPlaybackStopped;
                }
                woe.Init(afr);
                lblEnd.Text = afr.TotalTime.ToString(@"mm\:ss");
                tbsTimeSong.Value = 0;
                lblProcess.Text = "00:00";
                woe.Play();
                isPlaying = true;
                btnPlayMusic.Checked = false;
                timer1.Start();
                if (role == "host") SendMusicSync("play", 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing song: " + ex.Message);
            }
        }

        private void StopMusicAndDispose()
        {
            if (woe != null)
            {
                woe.PlaybackStopped -= OnPlaybackStopped;
                woe.Stop();
                woe.Dispose();
                woe = null;
            }
            if (afr != null)
            {
                afr.Dispose();
                afr = null;
            }
            isPlaying = false;
            timer1.Stop();
        }

        private void btnPlayMusic_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                woe.Pause();
                btnPlayMusic.Checked = true;
                isPlaying = false;
                timer1.Stop();
                if (role == "host") SendMusicSync("pause", afr?.CurrentTime.TotalMilliseconds ?? 0);
            }
            else
            {
                woe?.Play();
                btnPlayMusic.Checked = false;
                isPlaying = true;
                timer1.Start();
                if (role == "host") SendMusicSync("play", afr?.CurrentTime.TotalMilliseconds ?? 0);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (songIds == null || songIds.Count == 0) return;
            int idx = songIds.IndexOf(id_song);
            int nextIdx = (idx + 1) % songIds.Count;
            PlaySong(songIds[nextIdx]);
            if (role == "host") SendMusicSync("next", 0);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (songIds == null || songIds.Count == 0) return;
            int idx = songIds.IndexOf(id_song);
            int prevIdx = (idx - 1 + songIds.Count) % songIds.Count;
            PlaySong(songIds[prevIdx]);
            if (role == "host") SendMusicSync("prev", 0);
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            if (songIds == null || songIds.Count == 0) return;
            if (!isShuffled)
            {
                Random rng = new Random();
                int n = songIds.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    string value = songIds[k];
                    songIds[k] = songIds[n];
                    songIds[n] = value;
                }
            }
            else
            {
                songIds = new List<string>(originalSongIds);
            }
            isShuffled = !isShuffled;
            btnShuffle.Checked = isShuffled;
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            isAutoReplay = !isAutoReplay;
            btnReplay.Checked = isAutoReplay;
        }

        private void tbsTimeSong_Scroll(object sender, ScrollEventArgs e)
        {
            if (afr != null)
            {
                int newPosition = (int)(afr.TotalTime.TotalMilliseconds * tbsTimeSong.Value / 100);
                afr.CurrentTime = TimeSpan.FromMilliseconds(newPosition);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (afr != null)
            {
                lblProcess.Text = afr.CurrentTime.ToString(@"mm\:ss");
                tbsTimeSong.Value = (int)((afr.CurrentTime.TotalMilliseconds / afr.TotalTime.TotalMilliseconds) * 100);
            }
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (isAutoReplay)
            {
                afr.Position = 0;
                woe.Play();
            }
            else
            {
                btnNext_Click(sender, e);
            }
        }

        private void SendMusicSync(string action, double position = 0)
        {
            if (stream == null || string.IsNullOrEmpty(roomId)) return;
            try
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
                {
                    writer.Write("musicSync");
                    writer.Write(roomId);
                    writer.Write(action);
                    writer.Write(id_song ?? "");
                    writer.Write(position);
                }
            }
            catch { }
        }

        private void ListenRoom()
        {
            try
            {
                using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
                {
                    while (!isClosing)
                    {
                        string type = reader.ReadString();
                        if (type == "musicSync")
                        {
                            string syncRoomId = reader.ReadString();
                            string action = reader.ReadString();
                            string syncSongId = reader.ReadString();
                            double position = reader.ReadDouble();
                            if (syncRoomId == roomId)
                            {
                                this.Invoke((MethodInvoker)(() => SyncPlayback(action, position, syncSongId)));
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void SyncPlayback(string action, double position, string syncSongId)
        {
            switch (action)
            {
                case "play":
                    if (syncSongId != id_song) PlaySong(syncSongId);
                    afr.CurrentTime = TimeSpan.FromMilliseconds(position);
                    woe?.Play();
                    isPlaying = true;
                    btnPlayMusic.Checked = false;
                    timer1.Start();
                    break;
                case "pause":
                    if (syncSongId != id_song) PlaySong(syncSongId);
                    afr.CurrentTime = TimeSpan.FromMilliseconds(position);
                    woe?.Pause();
                    isPlaying = false;
                    btnPlayMusic.Checked = true;
                    timer1.Stop();
                    break;
                case "next":
                    btnNext_Click(this, EventArgs.Empty);
                    break;
                case "prev":
                    btnPrev_Click(this, EventArgs.Empty);
                    break;
            }
        }

        private void RoomForm_Disposed(object sender, EventArgs e)
        {
            try
            {
                isClosing = true;
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
                {
                    writer.Write("leaveRoom");
                    writer.Write(roomId);
                    writer.Write(userId);
                }
                listenThread?.Abort();
                stream?.Close();
                client?.Close();
                StopMusicAndDispose();
            }
            catch { }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
                {
                    writer.Write("leaveRoom");
                    writer.Write(roomId);
                    writer.Write(userId);
                }
                var parentPanel = this.Parent as Panel;
                if (parentPanel != null)
                {
                    parentPanel.Controls.Clear();
                    var musicRoom = new MusicRoom(userId, userName);
                    musicRoom.Dock = DockStyle.Fill;
                    parentPanel.Controls.Add(musicRoom);
                }
                StopMusicAndDispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi quay lại: " + ex.Message);
            }
        }
    }
}
