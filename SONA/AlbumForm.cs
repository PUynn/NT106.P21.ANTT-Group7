using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;

namespace SONA
{
    public partial class AlbumForm: UserControl
    {
        private Home h;
        private string idAlbum, idUser;

        public AlbumForm(Home h, string idAlbum, string idUser)
        {
            InitializeComponent();
            this.h = h;
            this.idAlbum = idAlbum;
            this.idUser = idUser;
        }

        private async void AlbumForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("albumForm");
                    writer.Write(idAlbum);

                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        lblNameAlbum.Text = reader.ReadString();

                        // Tải hình ảnh từ URL
                        string pictureUrl = reader.ReadString(); // Lấy đường dẫn URL của hình ảnh trên supabase
                        if (!string.IsNullOrEmpty(pictureUrl))  // Nếu có tồn tại đường dẫn tới file hình ảnh
                        {
                            using (var htppClient = new HttpClient()) // Tạo HttpClient để tải hình ảnh
                            {
                                var imageData = await htppClient.GetByteArrayAsync(pictureUrl); // Tải hình ảnh từ URL bằng phương thức GetByteArrayAsync
                                using (var ms = new MemoryStream(imageData)) // Tạo MemoryStream dể lấy dữ liệu hình ảnh
                                {
                                    btnPictureAlbum.BackgroundImage = Image.FromStream(ms); // Chuyển đổi MemoryStream thành Image
                                }
                            }
                        }
                        else
                        {
                            btnPictureAlbum.BackgroundImage = null;
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
                btnPictureAlbum.BackgroundImage = null;
            }
        }

        private void btnPictureAlbum_Click(object sender, EventArgs e)
        {
            Album album = new Album(h, idAlbum, idUser);
            h.pnMain.Controls.Clear();
            h.pnMain.Controls.Add(album);
        }
    }
}
