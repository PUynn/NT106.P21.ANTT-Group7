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
using System.ComponentModel.Design;
using System.IO;
using System.Net.Sockets;

namespace SONA
{
    public partial class SongSearch : UserControl
    {
        private Home H;
        private AudioFileReader afr;
        private string id_song, name_song, picture_song, am_thanh, name_singer;

        public SongSearch(Home h, string id_song)
        {
            H = h;
            this.id_song = id_song;
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("songSearch");
                    writer.Write(id_song);
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        name_song = reader.ReadString();
                        picture_song = reader.ReadString();
                        am_thanh = reader.ReadString();
                        name_singer = reader.ReadString();
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

        // Hàm gọi form ListenMusic để phát nhạc
        private void btnPictureSong_Click(object sender, EventArgs e)
        {
            ListenMusic listenMusic = new ListenMusic(H, id_song);
            H.pnMain.Controls.Clear();
            H.pnMain.Controls.Add(listenMusic);
            H.SetCurrentListenMusic(listenMusic);
        }

        // Hàm ghi các nội dung cần thiết cho 1 bài hát
        private void SongSearch_Load(object sender, EventArgs e)
        {
            //afr = new AudioFileReader(am_thanh);
            //lblTimeSong.Text = afr.TotalTime.ToString(@"mm\:ss");

            lblNameSong.Text = name_song;
            lblNameSinger.Text = name_singer;

            try
            {
                using (var wc = new System.Net.WebClient())
                using (var stream = wc.OpenRead(picture_song))
                {
                    btnPictureSong.BackgroundImage = Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }
    }
}