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
using System.Net.Http; // Thêm để tải hình ảnh từ URL
using System.IO;

namespace SONA
{
    public partial class SongForm : UserControl
    {
        Home H;
        DataRow src;

        public SongForm(Home h, DataRow dr)
        {
            InitializeComponent();
            H = h;
            src = dr;
        }

        // Hàm ghi các nội dung cần thiết cho 1 bài hát
        private async void SongForm_Load(object sender, EventArgs e)
        {
            try
            {
                lbNameSong.Text = src["NAME_SONG"].ToString();

                // Tải hình ảnh từ URL
                string pictureUrl = src["PICTURE_SONG"]?.ToString();
                if (!string.IsNullOrEmpty(pictureUrl))
                {
                    using (var client = new HttpClient())
                    {
                        var imageData = await client.GetByteArrayAsync(pictureUrl);
                        using (var ms = new MemoryStream(imageData))
                        {
                            btnPictureSong.BackgroundImage = Image.FromStream(ms);
                        }
                    }
                }
                else
                {
                    btnPictureSong.BackgroundImage = null; // Hoặc hình ảnh mặc định
                }

                btnPictureSong.BackgroundImageLayout = ImageLayout.Stretch;
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
            ListenMusic listenMusic = new ListenMusic(H, src);
            H.panel1.Controls.Clear();
            H.panel1.Controls.Add(listenMusic);
            H.SetCurrentListenMusic(listenMusic);
        }
    }
}