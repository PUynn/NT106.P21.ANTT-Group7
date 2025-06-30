using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using NAudio.Wave;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Guna.UI2.WinForms;
using System.IO;
using System.Net.Sockets;

namespace SONA
{
    public partial class ListenMusic : UserControl
    {
        private Home h;
        private WaveOutEvent woe; // Đối tượng phát nhạc
        private AudioFileReader afr; // Đối tượng đọc tệp âm thanh

        private bool isPlaying;
        private bool isAutoReplay;
        private bool isShuffled = false;
        private TimeSpan lastPosition;

        private List<string> songIds;
        private List<string> originalSongIds; // Danh sách bài hát gốc để sử dụng khi tắt chế độ xáo trộn

        private string id_song, name_song, picture_song, am_thanh, id_singer, name_singer, picture_singer, birthdate;
        private string idUser;
        private bool isFavorited = false;

        public ListenMusic(Home h, string id_song, string idUser, List<string> songIds)
        {
            this.h = h;
            this.id_song = id_song;
            this.idUser = idUser;
            this.songIds = new List<string>(songIds);
            this.originalSongIds = new List<string>(songIds);

            InitializeComponent();
            GetData();
            showSongsFavourite();
            this.Disposed += (s, e) => StopMusicAndDispose(); // Giải phóng tài nguyên khi điều khiển bị hủy        
        }

        private void GetData()
        {
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
                        id_singer = reader.ReadString();
                        name_singer = reader.ReadString();
                        picture_singer = reader.ReadString();
                        birthdate = reader.ReadString();
                        picture_song = reader.ReadString();
                        am_thanh = reader.ReadString();
                    }
                    else
                    {
                        MessageBox.Show(response);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private void showSongsFavourite()
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("songFavurite");
                    writer.Write(idUser);
                    writer.Write(id_song);

                    string response = reader.ReadString();
                    if (response == "Exists")
                    {
                        isFavorited = true;
                        btnFavourite.Checked = true;
                    }
                    else if (response == "Nothing")
                    {
                        isFavorited = false;
                        btnFavourite.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show(response);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        // Hàm chuyển đổi định dạng ngày tháng
        private string ConvertDate(string date)
        {
            try
            {
                DateTime parsedDate = DateTime.Parse(date);

                string month = parsedDate.ToString("MMMM");
                int day = parsedDate.Day;
                int year = parsedDate.Year;

                return $"Since {month} {day}, {year}";
            }
            catch (FormatException)
            {
                return "Invalid date format";
            }
        }

        // Hàm bật nhạc lại từ đầu khi nhạc kết thúc
        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (isAutoReplay)
            {
                afr.Position = 0; // Đặt lại vị trí phát nhạc về đầu
                woe.Play();
            }
            else
            {
                btnNext_Click(sender, e); // Tự động chuyển sang bài hát tiếp theo nếu không lặp lại
            }
        }

        // Hàm dừng nhạc và giải phóng tài nguyên
        public void StopMusicAndDispose()
        {
            if (woe != null)
            {
                lastPosition = TimeSpan.Zero; // Đặt lại vị trí về 0 khi dừng
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
            timer1.Stop();
        }

        // Hàm khởi tạo âm thanh
        private async Task<bool> InitializeAudio()
        {
            try
            {
                StopMusicAndDispose(); // Đảm bảo tài nguyên cũ được giải phóng

                isPlaying = false;
                isAutoReplay = false;

                // Load ảnh bài hát từ URL của thuộc tính PICTURE_SONG
                try
                {
                    using (var wc = new System.Net.WebClient())
                    using (var stream = wc.OpenRead(picture_song))
                    {
                        pbPictureSong.BackgroundImage = Image.FromStream(stream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                    return false;
                }

                // Load ảnh nghệ sĩ từ URL
                try
                {
                    using (var wc = new System.Net.WebClient())
                    using (var stream = wc.OpenRead(picture_singer))
                    {
                        cpbPictureSinger.Image = Image.FromStream(stream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                    return false;
                }

                // Phát nhạc từ URL (tải về tạm thời)
                string tempFile = Path.GetTempFileName();
                using (var wc = new System.Net.WebClient())
                {
                    await wc.DownloadFileTaskAsync(new Uri(am_thanh), tempFile);
                }

                // Tạo mới AudioFileReader để đảm bảo reset vị trí
                afr = new AudioFileReader(tempFile);
                afr.Volume = tbsVolume.Value / 100f;

                if (woe == null)
                {
                    woe = new WaveOutEvent();
                    woe.PlaybackStopped += OnPlaybackStopped;
                }
                woe.Init(afr);

                lblEnd.Text = afr.TotalTime.ToString(@"mm\:ss");
                lbNameSong.Text = name_song;
                lblNameSinger.Text = name_singer;
                lblSince.Text = ConvertDate(birthdate);
                CenterLabelInPanel();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during audio initialization: " + ex.Message);
                return false;
            }
        }

        // Hàm tự khởi động phát nhạc khi form được load
        private async void ListenMusic_Load(object sender, EventArgs e)
        {
            try
            {
                if (await InitializeAudio())
                {
                    woe.Play();
                    isPlaying = true;
                    btnPlayMusic.Checked = false;
                    timer1.Start();
                    tbsTimeSong.Value = 0;
                    CenterLabelInPanel();
                }
                else
                {
                    isPlaying = false;
                    btnPlayMusic.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during initialization: " + ex.Message);
                isPlaying = false;
                btnPlayMusic.Checked = true;
            }
        }

        private void btnFavourite_Click(object sender, EventArgs e)
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    if (!isFavorited)
                    {
                        writer.Write("addFavourite");
                        writer.Write(idUser);
                        writer.Write(id_song);

                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            isFavorited = true;
                            btnFavourite.Checked = true;
                        }
                        else
                        {
                            isFavorited = false;
                            btnFavourite.Checked = false;
                            MessageBox.Show(response);
                        }
                    }
                    else
                    {
                        writer.Write("removeFavourite");
                        writer.Write(idUser);
                        writer.Write(id_song);

                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            isFavorited = false;
                            btnFavourite.Checked = false;
                        }
                        else
                        {
                            isFavorited = true;
                            btnFavourite.Checked = true;
                            MessageBox.Show(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (songIds == null || songIds.Count == 0)
                {
                    MessageBox.Show("Không có bài hát nào trong danh sách!");
                    return;
                }

                int currentIndex = songIds.IndexOf(id_song);
                if (currentIndex == -1)
                {
                    MessageBox.Show("Bài hát hiện tại không nằm trong danh sách!");
                    return;
                }

                int nextIndex = (currentIndex + 1) % songIds.Count;
                string nextSongId = isShuffled ? songIds[nextIndex] : originalSongIds[nextIndex]; // Sử dụng danh sách xáo trộn nếu bật

                StopMusicAndDispose();
                id_song = nextSongId;

                GetData();
                if (await InitializeAudio())
                {
                    woe.Play();
                    isPlaying = true;
                    btnPlayMusic.Checked = false;
                    timer1.Start();
                    tbsTimeSong.Value = 0;
                }
                else
                {
                    isPlaying = false;
                    btnPlayMusic.Checked = true;
                }

                showSongsFavourite();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during next song: " + ex.Message);
            }
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                if (songIds == null || songIds.Count == 0)
                {
                    MessageBox.Show("Không có bài hát nào trong danh sách!");
                    return;
                }

                int currentIndex = songIds.IndexOf(id_song);
                if (currentIndex == -1)
                {
                    MessageBox.Show("Bài hát hiện tại không nằm trong danh sách!");
                    return;
                }

                int prevIndex = (currentIndex - 1 + songIds.Count) % songIds.Count;
                string prevSongId = isShuffled ? songIds[prevIndex] : originalSongIds[prevIndex]; // Sử dụng danh sách xáo trộn nếu bật

                StopMusicAndDispose();
                id_song = prevSongId;

                GetData();
                if (await InitializeAudio())
                {
                    woe.Play();
                    isPlaying = true;
                    btnPlayMusic.Checked = false;
                    timer1.Start();
                    tbsTimeSong.Value = 0;
                }
                else
                {
                    isPlaying = false;
                    btnPlayMusic.Checked = true;
                }

                showSongsFavourite();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during previous song: " + ex.Message);
            }
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbNameSong_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        // Hàm tạm dừng hoặc phát nhạc
        private async void btnPlayMusic_Click(object sender, EventArgs e)
        {
            try
            {
                if (isPlaying)
                {
                    lastPosition = afr.CurrentTime;
                    woe.Pause();
                    btnPlayMusic.Checked = true;
                    isPlaying = false;
                    timer1.Stop();
                }
                else
                {
                    if (woe == null || afr == null)
                    {
                        if (!await InitializeAudio()) return;
                    }

                    woe.Play();
                    btnPlayMusic.Checked = false;
                    isPlaying = true;
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                isPlaying = false;
                btnPlayMusic.Checked = true;
            }
        }

        // Hàm cập nhật thanh thời gian và lấy thời gian bài hát
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (afr != null)
            {
                lblProcess.Text = afr.CurrentTime.ToString(@"mm\:ss");
                tbsTimeSong.Value = (int)((afr.CurrentTime.TotalMilliseconds / afr.TotalTime.TotalMilliseconds) * 100);
            }
        }

        // Hàm cho phép người dùng tua bài hát
        private void tbsTimeSong_Scroll(object sender, ScrollEventArgs e)
        {
            if (afr != null)
            {
                int newPosition = (int)(afr.TotalTime.TotalMilliseconds * tbsTimeSong.Value / 100);
                afr.CurrentTime = TimeSpan.FromMilliseconds(newPosition);
            }
        }

        // Hàm cho phép người dùng điều chỉnh âm lượng
        private void tbsVolume_Scroll(object sender, ScrollEventArgs e)
        {
            if (afr != null)
            {
                afr.Volume = tbsVolume.Value / 100f;
            }
        }

        // Hàm lặp lại bài hát
        private void btnReplay_Click(object sender, EventArgs e)
        {
            isAutoReplay = !isAutoReplay;
            btnReplay.Checked = isAutoReplay;
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            try
            {
                if (songIds == null || songIds.Count == 0)
                {
                    MessageBox.Show("Không có bài hát nào trong danh sách!");
                    return;
                }

                int currentIndex = songIds.IndexOf(id_song);
                if (currentIndex == -1)
                {
                    MessageBox.Show("Bài hát hiện tại không nằm trong danh sách!");
                    return;
                }

                if (!isShuffled)
                {
                    // Xáo trộn danh sách
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
                    songIds = new List<string>(originalSongIds); // Khôi phục danh sách gốc
                }

                isShuffled = !isShuffled;
                btnShuffle.Checked = isShuffled;

                // Không phát lại bài hiện tại, chỉ cập nhật trạng thái
                showSongsFavourite();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during shuffle: " + ex.Message);
            }
        }

        // Hàm gọi form ArtsitInfor chứa các thông tin về nghệ sĩ
        private void cpbPictureSinger_Click(object sender, EventArgs e)
        {
            StopMusicAndDispose();
            h.pnMain.Controls.Clear();
            h.pnMain.Controls.Add(new ArtistInfor(h, id_singer, idUser));
        }

        private void CenterLabelInPanel()
        {
            lbNameSong.Left = (guna2Panel7.Width - lbNameSong.Width) / 2;
        }
    }
}