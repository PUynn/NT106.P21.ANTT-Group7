using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Net.Http; // Thư viện dùng để tải hình ảnh từ URL
using System.IO;
using System.Net.Sockets;

namespace SONA
{
    public partial class SongForm : UserControl
    {
        private Home H;
        private string id_song, idUser;

        public SongForm(Home h, string id_song, string idUser)
        {
            InitializeComponent();
            H = h;
            this.id_song = id_song;
            this.idUser = idUser;
        }

        // Hàm ghi các nội dung cần thiết cho 1 bài hát
        private async void SongForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("songForm");
                    writer.Write(id_song);

                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        lbNameSong.Text = reader.ReadString();

                        // Tải hình ảnh từ URL
                        string pictureUrl = reader.ReadString(); // Lấy đường dẫn URL của hình ảnh trên supabase
                        if (!string.IsNullOrEmpty(pictureUrl))  // Nếu có tồn tại đường dẫn tới file hình ảnh
                        {
                            using (var htppClient = new HttpClient()) // Tạo HttpClient để tải hình ảnh
                            {
                                var imageData = await htppClient.GetByteArrayAsync(pictureUrl); // Tải hình ảnh từ URL bằng phương thức GetByteArrayAsync
                                using (var ms = new MemoryStream(imageData)) // Tạo MemoryStream dể lấy dữ liệu hình ảnh
                                {
                                    btnPictureSong.BackgroundImage = Image.FromStream(ms); // Chuyển đổi MemoryStream thành Image
                                }
                            }
                        }
                        else
                        {
                            btnPictureSong.BackgroundImage = null; // Nếu không có hình ảnh từ đường dẫn thì set thành hình ảnh mặc định
                        }
                    }
                    else
                    {
                        MessageBox.Show(response); // Hiển thị lỗi từ server
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading song image: {ex.Message}");
                btnPictureSong.BackgroundImage = null; // Xử lý lỗi bằng cách không hiển thị hình
            }
        }

        // Hàm gọi form ListenMusic để phát nhạc
        private void btnPictureSong_Click(object sender, EventArgs e)
        {
            ListenMusic listenMusic = new ListenMusic(H, id_song, idUser);
            H.pnMain.Controls.Clear();
            H.pnMain.Controls.Add(listenMusic);
            H.SetCurrentListenMusic(listenMusic);
        }
    }
}