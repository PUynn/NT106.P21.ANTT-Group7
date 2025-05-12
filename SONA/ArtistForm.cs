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

namespace SONA
{
    public partial class ArtistForm : UserControl
    {
        Home H;
        DataRow src;

        public ArtistForm(Home h, DataRow dr)
        {
            InitializeComponent();
            H = h;
            src = dr;
        }

        // Hàm ghi các nội dung cần thiết cho 1 nghệ sĩ
        private async void ArtistForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblNameSinger.Text = src["NAME_SINGER"].ToString();

                // Tải hình ảnh nghệ sĩ từ URL của thuộc tính PICTURE_SINGER trong table SINGER
                string pictureUrl = src["PICTURE_SINGER"].ToString();
                if (!string.IsNullOrEmpty(pictureUrl))
                {
                    using (var client = new HttpClient())
                    {
                        var imageData = await client.GetByteArrayAsync(pictureUrl);
                        using (var ms = new MemoryStream(imageData))
                        {
                            btnPictureSinger.BackgroundImage = Image.FromStream(ms);
                        }
                    }
                }

                btnPictureSinger.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading artist image: {ex.Message}");
            }
        }

        // Hàm gọi form ArtistInfor để xem thông tin của nghệ sĩ bài hát
        private void btnPictureSong_Click(object sender, EventArgs e)
        {
            ArtistInfor artistInfor = new ArtistInfor(H, src);
            H.pnMain.Controls.Clear();
            H.pnMain.Controls.Add(artistInfor);
        }
    }
}