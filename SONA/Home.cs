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
            getIdUser(); // Lấy idUser ngay từ đầu
            getAvatarUser();
            getSongName();
            getSingerName();

            AutoCompleteStringCollection autoSource = new AutoCompleteStringCollection();
            autoSource.AddRange(songNames.ToArray());
            autoSource.AddRange(singerNames.ToArray());
            txtSearch.AutoCompleteCustomSource = autoSource;

            Console.WriteLine($"Home initialized with email={email}, idUser={User.idUser}");
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
                    Console.WriteLine($"getIDUser response for email {User.emailUser}: {response}");

                    if (response == "OK")
                    {
                        User.idUser = reader.ReadString();
                        Console.WriteLine($"Fetched idUser: {User.idUser}");
                    }
                    else
                    {
                        MessageBox.Show($"Error from server: {response}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
                Console.WriteLine($"Error in getIdUser: {ex.Message}");
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

                    string response = reader.ReadString();
                    Console.WriteLine($"getAvatarUser response for idUser {User.idUser}: {response}");
                    if (response == "OK")
                    {
                        string pictureUrl = reader.ReadString();
                        if (!string.IsNullOrEmpty(pictureUrl))
                        {
                            using (var httpClient = new HttpClient())
                            {
                                var imageData = await httpClient.GetByteArrayAsync(pictureUrl);
                                using (var ms = new MemoryStream(imageData))
                                {
                                    cpbUserInfor.Image = Image.FromStream(ms);
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
                Console.WriteLine($"Error in getAvatarUser: {ex.Message}");
            }
        }

        private void MyClick()
        {
            pnMyLibrary.FillColor = Color.FromArgb(17, 17, 17);
            btnDiscover.Checked = false;
            btnHome.Checked = false;
        }

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
            btnMaximum.Checked = false;

            PlaylistList playlistList = new PlaylistList(this);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(playlistList);
        }

        private void btnFavourited_Click(object sender, EventArgs e)
        {
            MyClick();
            btnMaximum.Checked = false;

            Favourite favourite = new Favourite(this);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(favourite);
        }

        private void btnAlbums_Click(object sender, EventArgs e)
        {
            MyClick();
            btnMaximum.Checked = false;

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

        private void btnHome_Click(object sender, EventArgs e)
        {
            MenuClick();
            btnMaximum.Checked = false;

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
            btnCloseMusicBar_Click(sender, e);
            btnMaximum.Checked = false;

            ChatForm chatForm = new ChatForm(User.emailUser);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(chatForm);
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

        public void StopMusicAndDispose()
        {
            if (woe != null)
            {
                lastPosition = TimeSpan.Zero;
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

        private async Task<bool> InitializeAudio()
        {
            try
            {
                StopMusicAndDispose();

                isPlaying = false;
                isAutoReplay = false;

                string tempFile = Path.GetTempFileName();
                using (var wc = new System.Net.WebClient())
                {
                    await wc.DownloadFileTaskAsync(new Uri(am_thanh), tempFile);
                }

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
                string nextSongId = isShuffled ? songIds[nextIndex] : originalSongIds[nextIndex];

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
                string prevSongId = isShuffled ? songIds[prevIndex] : originalSongIds[prevIndex];

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (afr != null)
            {
                lblProcess.Text = afr.CurrentTime.ToString(@"mm\:ss");
                tbsTimeSong.Value = (int)((afr.CurrentTime.TotalMilliseconds / afr.TotalTime.TotalMilliseconds) * 100);
            }
        }

        private void tbsTimeSong_Scroll(object sender, ScrollEventArgs e)
        {
            if (afr != null)
            {
                int newPosition = (int)(afr.TotalTime.TotalMilliseconds * tbsTimeSong.Value / 100);
                afr.CurrentTime = TimeSpan.FromMilliseconds(newPosition);
            }
        }

        private void tbsVolume_Scroll(object sender, ScrollEventArgs e)
        {
            if (afr != null)
            {
                afr.Volume = tbsVolume.Value / 100f;
            }
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            isAutoReplay = !isAutoReplay;
            btnReplay.Checked = isAutoReplay;
        }

        public void btnShuffle_Click(object sender, EventArgs e)
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
            catch (Exception ex)
            {
                MessageBox.Show("Error during shuffle: " + ex.Message);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnMaximum.Checked = false;

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
            btnCloseMusicBar_Click(sender, e);
            btnMaximum.Checked = false;

            UserInfor userInfor = new UserInfor(this, S);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(userInfor);
        }

        private void btnMaximum_Click(object sender, EventArgs e)
        {
            btnMaximum.Checked = true;

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