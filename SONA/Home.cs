using Guna.UI2.WinForms;
using NAudio.Dsp;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class Home : UserControl
    {
        private SONA S;

        public List<string> songNames;
        public List<string> singerNames;

        private WaveOutEvent woe; // Đối tượng phát nhạc
        private AudioFileReader afr; // Đối tượng đọc tệp âm thanh

        private bool isPlaying;
        private bool isAutoReplay;
        private bool isShuffled = false;
        private TimeSpan lastPosition;


        private List<string> songIds;
        private List<string> originalSongIds; // Danh sách bài hát gốc để sử dụng khi tắt chế độ xáo trộn

        private string id_song, am_thanh;

        public Home(SONA s, string email)
        {
            S = s;
            User.emailUser = email;
            songNames = new List<string>();
            singerNames = new List<string>();

            InitializeComponent();
            getIdUser();
            getAvatarUser();
            getSongName();
            getSingerName();

            AutoCompleteStringCollection autoSource = new AutoCompleteStringCollection();
            autoSource.AddRange(songNames.ToArray());
            autoSource.AddRange(singerNames.ToArray());
            txtSearch.AutoCompleteCustomSource = autoSource;
        }

        private void getSongName()
        {
            using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
            using (NetworkStream stream = client.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                writer.Write("getAllSongName");
                string response = reader.ReadString();

                if (response == "OK")
                {
                    int songCount = reader.ReadInt32();

                    for (int i = 0; i < songCount; i++)
                    {
                        string songName = reader.ReadString();
                        songNames.Add(songName);
                    }
                }
                else
                {
                    MessageBox.Show(response);
                }
            }
        }

        private void getSingerName()
        {
            using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
            using (NetworkStream stream = client.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                writer.Write("getAllSingerName");
                string response = reader.ReadString();

                if (response == "OK")
                {
                    int singerCount = reader.ReadInt32();

                    for (int i = 0; i < singerCount; i++)
                    {
                        string singerName = reader.ReadString();
                        singerNames.Add(singerName);
                    }
                }
                else
                {
                    MessageBox.Show(response);
                }
            }
        }

        private void getIdUser()
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getIDUser");
                    writer.Write(User.emailUser);
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        User.idUser = reader.ReadString();
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

        private async void getAvatarUser()
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getAvatarUser");
                    writer.Write(User.idUser);

                    string response = reader.ReadString(); // Nhận phản hồi từ server
                    if (response == "OK")
                    {
                        string pictureUrl = reader.ReadString(); // Lấy đường dẫn URL của hình ảnh trên supabase
                        if (!string.IsNullOrEmpty(pictureUrl))  // Nếu có tồn tại đường dẫn tới file hình ảnh
                        {
                            using (var htppClient = new HttpClient()) // Tạo HttpClient để tải hình ảnh
                            {
                                var imageData = await htppClient.GetByteArrayAsync(pictureUrl); // Tải hình ảnh từ URL bằng phương thức GetByteArrayAsync
                                using (var ms = new MemoryStream(imageData)) // Tạo MemoryStream dể lấy dữ liệu hình ảnh
                                {
                                    cpbUserInfor.Image = Image.FromStream(ms); // Chuyển đổi MemoryStream thành Image
                                }
                            }
                        }
                        else
                        {
                            cpbUserInfor.Image = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show(response);
                        cpbUserInfor.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }
        private void MyClick()
        {
            pnMyLibrary.FillColor = Color.FromArgb(17, 17, 17);
            btnDiscover.Checked = false;
            btnHome.Checked = false;
        }

        // Hàm gọi form homeContent chứa các nội dung trong home
        private void Home_Load(object sender, EventArgs e)
        {
            HomeContent homeContent = new HomeContent(this);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(homeContent);
        }

        private void btnLibrary_Click(object sender, EventArgs e)
        {
            pnMyLibrary.FillColor = Color.FromArgb(17, 17, 17);
        }

        private void btnPlaylists_Click(object sender, EventArgs e)
        {
            MyClick();

            PlaylistList playlistList = new PlaylistList(this);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(playlistList);
        }

        private void btnFavourited_Click(object sender, EventArgs e)
        {
            MyClick();

            Favourite favourite = new Favourite(this);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(favourite);
        }

        private void btnAlbums_Click(object sender, EventArgs e)
        {
            MyClick();

            AlbumList albumList = new AlbumList(this);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(albumList);
        }

        private void MenuClick()
        {
            pnMyLibrary.FillColor = Color.FromArgb(39, 39, 39);
            btnAlbums.Checked = false;
            btnPlaylists.Checked = false;
            btnLibrary.Checked = false;
            btnFavourited.Checked = false;
            btnChat.Checked = false;
        }

        // Hàm quay trở lại màn hình chính khi nhấn nút home và gọi hàm StopMusicAndDispose để dừng bài hát đang phát
        private void btnHome_Click(object sender, EventArgs e)
        {
            MenuClick();

            HomeContent home = new HomeContent(this);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(home);
        }

        private void btnDiscover_Click(object sender, EventArgs e)
        {
            MenuClick();
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            MyClick();

            ChatForm chatForm = new ChatForm(User.emailUser);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(chatForm);
        }

        private void btnArtists_Click(object sender, EventArgs e)
        {
            MyClick();

            ArtistList artistList = new ArtistList(this);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(artistList);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            StopMusicAndDispose();
            Application.Exit();
        }

        public void btnMinimize_Click(object sender, EventArgs e)
        {
            S.WindowState = FormWindowState.Minimized;
        }

        private void getData()
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("musicBar");
                    writer.Write(id_song);
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        am_thanh = reader.ReadString();
                        lblNameSong.Text = reader.ReadString();
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

        public void listenMusic(string id_song, List<string> songIds)
        {
            pnMusicBar.Visible = true;

            this.id_song = id_song;
            this.songIds = new List<string>(songIds);
            originalSongIds = new List<string>(songIds);

            getData();
            playMusic();
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
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during audio initialization: " + ex.Message);
                return false;
            }
        }

        private async void playMusic()
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

                if (btnMaximum.Checked)
                {
                    ListenMusic listenMusic = new ListenMusic(this, id_song);
                    pnMain.Controls.Clear();
                    pnMain.Controls.Add(listenMusic);
                }

                getData();
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

                if (btnMaximum.Checked)
                {
                    ListenMusic listenMusic = new ListenMusic(this, id_song);
                    pnMain.Controls.Clear();
                    pnMain.Controls.Add(listenMusic);
                }

                getData();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during previous song: " + ex.Message);
            }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during shuffle: " + ex.Message);
            }
        }

        // Hàm tìm kiếm bài hát khi nhấn enter vào ô tìm kiếm
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchForm searchForm = new SearchForm(this, txtSearch.Text);
                pnMain.Controls.Clear();
                pnMain.Controls.Add(searchForm);
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void cpbUserInfor_Click(object sender, EventArgs e)
        {
            UserInfor userInfor = new UserInfor(this, S);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(userInfor);
        }

        private void btnMaximum_Click(object sender, EventArgs e)
        {
            ListenMusic listenMusic = new ListenMusic(this, id_song);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(listenMusic);
        }

        private void btnCloseMusicBar_Click(object sender, EventArgs e)
        {
            StopMusicAndDispose();
            pnMusicBar.Visible = false;
        }
    }
    public static class User
    {
        public static string idUser;
        public static string emailUser;
    }
}