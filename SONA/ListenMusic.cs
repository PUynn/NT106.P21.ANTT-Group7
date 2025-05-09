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
        Home H;
        WaveOutEvent woe; // Đối tượng phát nhạc
        AudioFileReader afr; // Đối tượng đọc tệp âm thanh

        bool isPlaying;
        bool isAutoReplay;

        DataRow src;
        TimeSpan lastPosition;

        public ListenMusic(Home h, DataRow dr)
        {
            H = h;
            src = dr;

            InitializeComponent();
            this.Disposed += (s, e) => StopMusicAndDispose(); // Giải phóng tài nguyên khi điều khiển bị hủy
        }

        // Hàm chuyển đổi định dạng ngày tháng
        private string ConvertDate(string date)
        {
            try
            {
                DateTime parsedDate = DateTime.Parse(date);

                string month = parsedDate.ToString("MMMM");
                int day = parsedDate.Day;
                int year = parsedDate.Year;

                return $"Since {month} {day}, {year}";
            }
            catch (FormatException)
            {
                return "Invalid date format";
            }
        }

        // Hàm bật lại nhạc khi nhạc dừng
        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (isAutoReplay)
            {
                afr.Position = 0; // Đặt lại vị trí phát nhạc về đầu
                woe.Play();
            }
        }

        // Hàm dừng nhạc và giải phóng tài nguyên
        public void StopMusicAndDispose()
        {
            if (woe != null)
            {
                lastPosition = afr?.CurrentTime ?? TimeSpan.Zero; // Lưu lại vị trí hiện tại
                woe.PlaybackStopped -= OnPlaybackStopped; // Ngừng theo dõi sự kiện dừng phát
                woe.Stop();
                woe.Dispose(); // Giải phóng tài nguyên cho đối tượng phát nhạc
                woe = null;
            }
            if (afr != null)
            {
                afr.Dispose(); // Giải phóng tài nguyên cho đối tượng đọc tệp âm thanh
                afr = null;
            }
            timer1.Stop(); // Dừng bộ đếm thời gian
        }

        // Hàm khởi tạo âm thanh
        private bool InitializeAudio()
        {
            try
            {
                if (afr == null)
                {
                    afr = new AudioFileReader(src["AM_THANH"].ToString()); // Đọc tệp âm thanh từ trong cơ sở dữ liệu
                    afr.Volume = tbsVolume.Value / 100f; // Đặt giá trị âm lượng ban đầu là 50%
                }

                if (woe == null)
                {
                    woe = new WaveOutEvent();
                    woe.Init(afr); // Khởi tạo đối tượng phát nhạc với tệp âm thanh
                    woe.PlaybackStopped += OnPlaybackStopped; // Theo dõi sự kiện dừng phát
                }

                if (lastPosition != TimeSpan.Zero) // Kiểm tra xem có vị trí đã lưu không
                {
                    afr.CurrentTime = lastPosition; // Đặt lại vị trí phát nhạc về vị trí đã lưu
                }

                lblEnd.Text = afr.TotalTime.ToString(@"mm\:ss"); // Lấy thời gian tổng của bài hát
                lblNameSinger.Text = src["NAME_SINGER"].ToString();
                lblSince.Text = ConvertDate(src["BIRTHDATE"].ToString());

                pbPictureSong.Image = Image.FromFile(src["PICTURE_SONG"].ToString());
                pbPictureSong.SizeMode = PictureBoxSizeMode.StretchImage; ;
                
                btnPictureSinger.BackgroundImage = Image.FromFile(src["PICTURE_SINGER"].ToString());
                btnPictureSinger.BackgroundImageLayout = ImageLayout.Stretch;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during audio initialization: " + ex.Message);
                return false;
            }
        }

        // Hàm tự khởi động phát nhạc khi form được load
        private void ListenMusic_Load(object sender, EventArgs e)
        {
            try
            {
                StopMusicAndDispose(); // Giải phóng tài nguyên trước khi khởi động lại
                if (InitializeAudio())
                {
                    woe.Play(); // Phát nhạc
                    isPlaying = true;
                    btnPlayMusic.Image = Properties.Resources.PauseAni;
                    timer1.Start(); // Bắt đầu bộ đếm thời gian
                }
                else
                {
                    isPlaying = false;
                    btnPlayMusic.Image = Properties.Resources.PlayAni;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during initialization: " + ex.Message);
                isPlaying = false;
                btnPlayMusic.Image = Properties.Resources.PlayAni;
            }
        }

        // Hàm tạm dừng hoặc phát nhạc
        private void btnPlayMusic_Click(object sender, EventArgs e)
        {
            try
            {
                if (isPlaying) // Nếu đang phát nhạc
                {
                    lastPosition = afr.CurrentTime; // Lưu lại vị trí hiện tại
                    woe.Pause(); // Tạm dừng phát nhạc
                    btnPlayMusic.Image = Properties.Resources.PlayAni;
                    isPlaying = false;
                    timer1.Stop(); // Dừng bộ đếm thời gian
                }
                else
                {
                    if (woe == null || afr == null) // Nếu chưa được khởi tạo
                    {
                        if (!InitializeAudio()) return; // Khởi tạo lại âm thanh, nếu không được thì return
                    }

                    woe.Play();
                    btnPlayMusic.Image = Properties.Resources.PauseAni;
                    isPlaying = true;
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                isPlaying = false;
                btnPlayMusic.Image = Properties.Resources.PlayAni;
            }
        }

        // Hàm cập nhật thanh thời gian và lấy thời gian bài hát
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (afr != null)
            {
                lblProcess.Text = afr.CurrentTime.ToString(@"mm\:ss");
                tbsTimeSong.Value = (int)((afr.CurrentTime.TotalMilliseconds / afr.TotalTime.TotalMilliseconds) * 100); // Cập nhật thanh thời gian bằng cách lấy thời gian hiện tại chia cho tổng thời gian
            }
        }

        // Hàm cho phép người dùng tua bài hát
        private void tbsTimeSong_Scroll(object sender, ScrollEventArgs e)
        {
            if (afr != null)
            {
                int newPosition = (int)(afr.TotalTime.TotalMilliseconds * tbsTimeSong.Value / 100); // Tính toán vị trí mới dựa trên giá trị thanh trượt
                afr.CurrentTime = TimeSpan.FromMilliseconds(newPosition); // Đặt lại vị trí phát nhạc
            }
        }

        // Hàm cho phép người dùng điều chỉnh âm lượng
        private void tbsVolume_Scroll(object sender, ScrollEventArgs e)
        {
            if (afr != null)
            {
                afr.Volume = tbsVolume.Value / 100f; // Đặt lại âm lượng dựa trên giá trị thanh trượt
            }
        }

        // Hàm lặp lại bài hát
        private void btReplay_Click(object sender, EventArgs e)
        {
            isAutoReplay = !isAutoReplay; // Đảo ngược trạng thái lặp lại

            if (isAutoReplay)
                btReplay.Image = Properties.Resources.RecoreOn;
            else
                btReplay.Image = Properties.Resources.Record;
        }

        // Hàm gọi form ArtsitInfor chứa các thông tin về nghệ sĩ
        private void btnSinger_Click(object sender, EventArgs e)
        {
            StopMusicAndDispose();
            H.panel1.Controls.Clear();
            H.panel1.Controls.Add(new ArtistInfor(H, src));
        }

    }
}