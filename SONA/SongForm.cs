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
        DataTable dtb;
        string srcSong, srcImage;

        public SongForm(Home h, string nameSong, string imgSong, string soundSong)
        {
            InitializeComponent();
            H = h;
            srcSong = soundSong;
            srcImage = imgSong;

            lbNameSong.Text = nameSong;
            btnPictureSong.BackgroundImage = Image.FromFile(imgSong);
            btnPictureSong.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            ListenMusic listenMusic = new ListenMusic(H, srcSong, srcImage);
            H.panel1.Controls.Clear();
            H.panel1.Controls.Add(listenMusic);
            listenMusic.Dock = DockStyle.Fill;

        }

        private void SongForm_Load(object sender, EventArgs e)
        {

        }
    }
}
