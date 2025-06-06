using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using System.Net.Sockets;

namespace SONA
{
    public partial class ArtistForm : UserControl
    {
        private Home H;
        private string id_singer, idUser;

        public ArtistForm(Home h, string id_singer, string idUser)
        {
            InitializeComponent();
            H = h;
            this.id_singer = id_singer;
            this.idUser = idUser;
        }

        // Hàm ghi các nội dung cần thiết cho 1 nghệ sĩ
        private async void ArtistForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("artistForm");
                    writer.Write(id_singer);

                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        lbNameSinger.Text = reader.ReadString();

                        // Tải hình ảnh từ URL
                        string pictureUrl = reader.ReadString(); // Lấy đường dẫn URL của hình ảnh trên supabase
                        if (!string.IsNullOrEmpty(pictureUrl))  // Nếu có tồn tại đường dẫn tới file hình ảnh
                        {
                            using (var htppClient = new HttpClient()) // Tạo HttpClient để tải hình ảnh
                            {
                                var imageData = await htppClient.GetByteArrayAsync(pictureUrl); // Tải hình ảnh từ URL bằng phương thức GetByteArrayAsync
                                using (var ms = new MemoryStream(imageData)) // Tạo MemoryStream dể lấy dữ liệu hình ảnh
                                {
                                    btnPictureSinger.BackgroundImage = Image.FromStream(ms); // Chuyển đổi MemoryStream thành Image
                                }
                            }
                        }
                        else
                        {
                            btnPictureSinger.BackgroundImage = null; // Nếu không có hình ảnh từ đường dẫn thì set thành hình ảnh mặc định
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
                MessageBox.Show($"Error loading singer image: {ex.Message}");
                btnPictureSinger.BackgroundImage = null; // Xử lý lỗi bằng cách không hiển thị hình
            }
        }

        // Hàm gọi form ArtistInfor để xem thông tin của nghệ sĩ bài hát
        private void btnPictureSong_Click(object sender, EventArgs e)
        {
            ArtistInfor artistInfor = new ArtistInfor(H, id_singer, idUser);
            H.pnMain.Controls.Clear();
            H.pnMain.Controls.Add(artistInfor);
        }
    }
}