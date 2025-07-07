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
        private ListenMusic currentListenMusic;
        
        public List<string> songNames;
        public List<string> singerNames;

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
            btnSearch.Checked = false;
            txtSearch.Visible = false;
            btnSearch.Visible = true;
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

            if (currentListenMusic != null)
            {
                currentListenMusic.StopMusicAndDispose();
                currentListenMusic = null;
            }

            PlaylistList playlistList = new PlaylistList(this);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(playlistList);


        }

        private void btnFavorited_Click(object sender, EventArgs e)
        {
            MyClick();

            if (currentListenMusic != null)
            {
                currentListenMusic.StopMusicAndDispose();
                currentListenMusic = null;
            }

            Favourite favourite = new Favourite(this);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(favourite);
        }

        private void btnAlbums_Click(object sender, EventArgs e)
        {
            MyClick();

            if (currentListenMusic != null)
            {
                currentListenMusic.StopMusicAndDispose();
                currentListenMusic = null;
            }

            AlbumList albumList = new AlbumList(this);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(albumList);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MenuClick();
            btnSearch.Visible = false;
            txtSearch.Visible = true;
            txtSearch.Focus();
        }

        private void MenuClick()
        {
            pnMyLibrary.FillColor = Color.FromArgb(39, 39, 39);
            btnAlbums.Checked = false;
            btnPlaylists.Checked = false;
            btnLibrary.Checked = false;
            btnFavorited.Checked = false;
            btnChat.Checked = false;
        }

        // Hàm quay trở lại màn hình chính khi nhấn nút home và gọi hàm StopMusicAndDispose để dừng bài hát đang phát
        private void btnHome_Click(object sender, EventArgs e)
        {
            MenuClick();

            txtSearch.Visible = false;
            btnSearch.Visible = true;

            if (currentListenMusic != null)
            {
                currentListenMusic.StopMusicAndDispose();
                currentListenMusic = null;
            }

            HomeContent home = new HomeContent(this);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(home);
        }

        private void btnDiscover_Click(object sender, EventArgs e)
        {
            MenuClick();
            txtSearch.Visible = false;
            btnSearch.Visible = true;
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            MyClick();

            if (currentListenMusic != null)
            {
                currentListenMusic.StopMusicAndDispose();
                currentListenMusic = null;
            }

            ChatForm chatForm = new ChatForm(User.emailUser);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(chatForm);
        }

        private void btnArtists_Click(object sender, EventArgs e)
        {
            MyClick();

            if (currentListenMusic != null)
            {
                currentListenMusic.StopMusicAndDispose();
                currentListenMusic = null;
            }

            ArtistList artistList = new ArtistList(this);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(artistList);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void btnMinimize_Click(object sender, EventArgs e)
        {
            S.WindowState = FormWindowState.Minimized;
        }

        // Hàm tìm kiếm bài hát khi nhấn enter vào ô tìm kiếm
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (currentListenMusic != null)
                {
                    currentListenMusic.StopMusicAndDispose();
                    currentListenMusic = null;
                }

                SearchForm searchForm = new SearchForm(this, txtSearch.Text);
                pnMain.Controls.Clear();
                pnMain.Controls.Add(searchForm);
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        // Hàm dừng bài hát khi nó đang phát trong form listenMusic
        public void SetCurrentListenMusic(ListenMusic listenMusic)
        {
            if (currentListenMusic != null && currentListenMusic != listenMusic)
            {
                currentListenMusic.StopMusicAndDispose();
            }
            currentListenMusic = listenMusic;
        }

        private void cpbUserInfor_Click(object sender, EventArgs e)
        {
            if (currentListenMusic != null)
            {
                currentListenMusic.StopMusicAndDispose();
                currentListenMusic = null;
            }

            UserInfor userInfor = new UserInfor(this, S);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(userInfor);
        }
    }
    public static class User
    {
        public static string idUser;
        public static string emailUser;
    }
}