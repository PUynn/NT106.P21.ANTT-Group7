using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class SongSearch : UserControl
    {
        string srcSong, srcPicture, srcMusic, srcSinger;
        Home H;

        public SongSearch(Home h, string nameSong, string pictureSong, string Music, string nameSinger)
        {
            InitializeComponent();
            srcSong = nameSong;
            srcPicture = pictureSong;
            srcMusic = Music;
            srcSinger = nameSinger;

            lblNameArtist.Text = srcSinger;
            lblNameSong.Text = srcSong;
            btnPictureSong.BackgroundImage = Image.FromFile(srcPicture);
            btnPictureSong.BackgroundImageLayout = ImageLayout.Stretch;

            H = h;
        }

        private void btnPictureSong_Click(object sender, EventArgs e)
        {
            ListenMusic listenMusic = new ListenMusic(H, srcMusic, srcPicture);
            H.panel1.Controls.Clear();
            H.panel1.Controls.Add(listenMusic);
            H.SetCurrentListenMusic(listenMusic);
        }
    }
}