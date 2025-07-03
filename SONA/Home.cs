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
        SONA S;
        private ListenMusic currentListenMusic;
        private string emailUser;
        private string idUser;

        // Biến cho tìm kiếm real-time và gợi ý
        private string currentSearchTerm = "";
        private System.Windows.Forms.Timer searchTimer;
        private List<(string id, string type)> searchResults = new List<(string, string)>();

        public Home(SONA s, string email)
        {
            S = s;
            emailUser = email;
            InitializeComponent();
            getIdUser();
            getAvatarUser();

            // Khởi tạo timer
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 500;
            searchTimer.Tick += SearchTimer_Tick;

            // Đăng ký event cho txtSearch
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.KeyDown += txtSearch_KeyDown;
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
                    writer.Write(emailUser);
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        idUser = reader.ReadString();
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
                    writer.Write(idUser);

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
            HomeContent homeContent = new HomeContent(this, idUser);
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

            PlaylistList a = new PlaylistList(this, idUser);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(a);
        }

        private void btnFavorited_Click(object sender, EventArgs e)
        {
            MyClick();

            if (currentListenMusic != null)
            {
                currentListenMusic.StopMusicAndDispose();
                currentListenMusic = null;
            }

            Favourite favourite = new Favourite(this, idUser);
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

            AlbumList albumList = new AlbumList(this, idUser);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(albumList);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MenuClick();
            txtSearch.Visible = true;
            btnSearch.Visible = false;
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

            HomeContent home = new HomeContent(this, idUser);
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

            ChatForm chatForm = new ChatForm(emailUser);
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

            ArtistList artistList = new ArtistList(this, idUser);
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

        // Event handler cho textbox tìm kiếm
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            currentSearchTerm = txtSearch.Text.Trim();
            searchTimer.Stop();
            searchTimer.Start();
           
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchTimer.Stop();

                string searchTerm = txtSearch.Text.Trim();

                SearchForm searchForm = new SearchForm(this, idUser);
                pnMain.Controls.Clear();
                pnMain.Controls.Add(searchForm);

                // Gửi từ khóa tìm kiếm sang SearchForm
                searchForm.SetSearchTerm(searchTerm);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtSearch.Focus();
            }
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            if (!string.IsNullOrWhiteSpace(currentSearchTerm))
            // Hiển thị kết quả real-time
            PerformSearch(currentSearchTerm);
        }

 
        private void PerformSearch(string searchTerm)
        {
            searchResults.Clear();
            pnMain.Controls.Clear();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                ShowAllSongsAndArtists();
                return;
            }

            // Tìm kiếm bài hát
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("searchSongs");
                    writer.Write(searchTerm);
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        int songCount = reader.ReadInt32();
                        for (int i = 0; i < songCount; i++)
                        {
                            string id_song = reader.ReadString();
                            searchResults.Add((id_song, "song"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching songs: " + ex.Message);
            }

            // Tìm kiếm nghệ sĩ
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("searchArtists");
                    writer.Write(searchTerm);
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        int singerCount = reader.ReadInt32();
                        for (int i = 0; i < singerCount; i++)
                        {
                            string id_singer = reader.ReadString();
                            searchResults.Add((id_singer, "artist"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching artists: " + ex.Message);
            }

            // ALBUMS
            List<string> albumIds = new List<string>();
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("searchAlbums");
                    writer.Write(searchTerm);
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        int albumCount = reader.ReadInt32();
                        for (int i = 0; i < albumCount; i++)
                        {
                            string id_album = reader.ReadString();
                            albumIds.Add(id_album);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching albums: " + ex.Message);
            }

            // Hiển thị kết quả
            // SONGS
            foreach (var result in searchResults)
            {
                if (result.type == "song" || result.type == "artist")
                {
                    SongSearch songSearch = new SongSearch(this, result.id, idUser, null, result.type);
                    pnMain.Controls.Add(songSearch);
                }
            }
            // ALBUMS
            foreach (var id_album in albumIds)
            {
                AlbumForm albumForm = new AlbumForm(this, id_album, idUser);
                pnMain.Controls.Add(albumForm);
            }
        }

        private void ShowAllSongsAndArtists()
        {
            // Hiển thị tất cả bài hát và nghệ sĩ như mặc định
            pnMain.Controls.Clear();
            // Gọi lại các hàm lấy toàn bộ bài hát và nghệ sĩ nếu cần
            // ...
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
            UserInfor userInfor = new UserInfor(this, S, idUser);
            pnMain.Controls.Clear();
            pnMain.Controls.Add(userInfor);
        }

        private void pnMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}