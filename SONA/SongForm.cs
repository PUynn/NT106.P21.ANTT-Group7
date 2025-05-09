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
using Guna.UI2.WinForms;

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
        private void SongForm_Load(object sender, EventArgs e)
        {
            lbNameSong.Text = src["NAME_SONG"].ToString();
            btnPictureSong.BackgroundImage = Image.FromFile(src["PICTURE_SONG"].ToString());
            btnPictureSong.BackgroundImageLayout = ImageLayout.Stretch;
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