using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace SONA
{
    public partial class SongSearch : UserControl
    {
        Home H;
        DataRow src;
        AudioFileReader afr;
        public SongSearch(Home h, DataRow dr)
        {
            H = h;
            src = dr;
            InitializeComponent();
        }

        // Hàm gọi form ListenMusic để phát nhạc
        private void btnPictureSong_Click(object sender, EventArgs e)
        {
            ListenMusic listenMusic = new ListenMusic(H, src);
            H.panel1.Controls.Clear();
            H.panel1.Controls.Add(listenMusic);
            H.SetCurrentListenMusic(listenMusic);
        }

        // Hàm ghi các nội dung cần thiết cho 1 bài hát
        private void SongSearch_Load(object sender, EventArgs e)
        {
            afr = new AudioFileReader(src["AM_THANH"].ToString());
            lblTimeSong.Text = afr.TotalTime.ToString(@"mm\:ss");

            lblNameSong.Text = src["NAME_SONG"].ToString();
            lblNameSinger.Text = src["NAME_SINGER"].ToString();

            btnPictureSong.BackgroundImage = Image.FromFile(src["PICTURE_SONG"].ToString());
            btnPictureSong.BackgroundImageLayout = ImageLayout.Stretch;
  
        }
    }
}