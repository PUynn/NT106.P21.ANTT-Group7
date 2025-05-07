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
using NAudio.Wave;

namespace SONA
{
    public partial class MusicBar: UserControl
    {
        Home H;
        WaveOutEvent woe;
        AudioFileReader afr;
        int songIndex;

        string srcPicture;
        string srcMusic;
        bool isPlaying;
        bool isAutoReplay;
        TimeSpan lastPosition;
        public MusicBar(Home h, string music, string image)
        {
            InitializeComponent();
            H = h;
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

        private void InitializeAudio()
        {
            try
            {
                if (afr == null)
                {
                    afr = new AudioFileReader(srcMusic);
                    afr.Volume = guna2TrackBar2.Value / 100f;
                }

                if (woe == null)
                {
                    woe = new WaveOutEvent();
                    woe.Init(afr);
                    woe.PlaybackStopped += OnPlaybackStopped;
                }

                if (lastPosition != TimeSpan.Zero)
                {
                    afr.CurrentTime = lastPosition;
                }

                btnPicture.BackgroundImage = Image.FromFile(srcPicture);
                btnPicture.BackgroundImageLayout = ImageLayout.Stretch;
                guna2HtmlLabel2.Text = afr.TotalTime.ToString(@"mm\:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during audio initialization: " + ex.Message);
            }
        }

        private void ListenMusic_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeAudio();

                woe.Play();
                isPlaying = true;
                btnStart.Image = Properties.Resources.PauseAni;
                timer1.Start();
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
                    lastPosition = afr.CurrentTime;
                    woe.Pause();
                    btnStart.Image = Properties.Resources.PlayAni;
                    isPlaying = false;
                    timer1.Stop();
                }
                else
                {
                    if (woe == null || afr == null)
                    {
                        InitializeAudio();
                    }

                    woe.Play();
                    btnStart.Image = Properties.Resources.PauseAni;
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

        }

        private void ListenMusic_Leave(object sender, EventArgs e)
        {

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
            if (woe != null)
            {
                lastPosition = afr?.CurrentTime ?? TimeSpan.Zero;
                woe.PlaybackStopped -= OnPlaybackStopped;
                woe.Stop();
                woe.Dispose();
                woe = null;
            }
            if (afr != null)
            {
                afr.Dispose();
                afr = null;
            }
            timer1.Stop();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {

        }
    }
}
