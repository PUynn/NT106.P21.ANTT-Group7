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
using NAudio.Wave;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SONA
{
    public partial class ListenMusic : UserControl
    {
        //string connectString = @"Data Source=(local);Initial Catalog=MUSIC_APP;Integrated Security=True";
        //SqlConnection connect;
        //SqlCommand command;
        //SqlDataAdapter adapter;
        //DataTable dtb;

        Home H;
        WaveOutEvent woe;
        AudioFileReader afr;
        int songIndex;

        string srcPicture;
        string srcMusic;
        bool isPlaying;
        bool isAutoReplay;

        public ListenMusic(Home h, string music, string image)
        {
            H = h;
            InitializeComponent(); ;
            srcMusic = music;
            srcPicture = image;
        }
        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (isAutoReplay)
            {
                afr.Position = 0;
                woe.Play();
            }
        }

        private void ListenMusic_Load(object sender, EventArgs e)
        {
            try
            {
                //isPlaying = false;
                //isAutoReplay = false;
                //connect = new SqlConnection(connectString);

                //connect.Open();

                //command = new SqlCommand("SELECT * FROM SONGS", connect);
                //adapter = new SqlDataAdapter(command);
                //dtb = new DataTable();

                //adapter.Fill(dtb);

                //if (dtb.Rows.Count > 0 && songIndex >= 0 && songIndex < dtb.Rows.Count)
                //{
                //    srcPicture = dtb.Rows[songIndex]["PICTURE_SONG"].ToString();
                //    srcMusic = dtb.Rows[songIndex]["AM_THANH"].ToString();
                //}
                //else
                //{
                //    MessageBox.Show("No song found at index " + songIndex + ".");
                //    connect.Close();
                //    return;
                //}

                //if (!System.IO.File.Exists(srcMusic))
                //{
                //    MessageBox.Show("Music file not found: " + srcMusic);
                //    connect.Close();
                //    return;
                //}

                afr = new AudioFileReader(srcMusic);
                afr.Volume = guna2TrackBar2.Value / 100f;

                woe = new WaveOutEvent();
                woe.Init(afr);
                woe.PlaybackStopped += OnPlaybackStopped;

                guna2PictureBox1.Image = Image.FromFile(srcPicture);
                guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                guna2HtmlLabel2.Text = afr.TotalTime.ToString(@"mm\:ss");

                woe.Play();
                isPlaying = true;
                guna2Button1.Image = Properties.Resources.PauseAni;
                timer1.Start();

                //connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during initialization: " + ex.Message);
            }
        }

        private void guna2TrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (afr != null)
            {
                afr.Volume = guna2TrackBar2.Value / 100f;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (isPlaying)
                {
                    woe.Pause();
                    guna2Button1.Image = Properties.Resources.PlayAni;
                    isPlaying = false;
                    timer1.Stop();
                }
                else
                {
                    woe.Play();
                    guna2Button1.Image = Properties.Resources.PauseAni;
                    isPlaying = true;
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (afr != null)
            {
                guna2HtmlLabel1.Text = afr.CurrentTime.ToString(@"mm\:ss");
                guna2TrackBar1.Value = (int)((afr.CurrentTime.TotalMilliseconds / afr.TotalTime.TotalMilliseconds) * 100);
            }
        }


        private void ListenMusic_Leave(object sender, EventArgs e)
        {
            if (woe != null)
            {
                woe.PlaybackStopped -= OnPlaybackStopped;
                woe.Stop();
                woe.Dispose();
            }
            if (afr != null)
            {
                afr.Dispose();
            }
            timer1.Stop();
        }

        private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (afr != null)
            {
                int newPosition = (int)(afr.TotalTime.TotalMilliseconds * guna2TrackBar1.Value / 100);
                afr.CurrentTime = TimeSpan.FromMilliseconds(newPosition);
            }
        }

        public void StopMusicAndDispose()
        {
            ListenMusic_Leave(this, EventArgs.Empty);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }
    }
}
