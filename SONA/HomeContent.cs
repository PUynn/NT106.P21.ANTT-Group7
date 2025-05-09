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
    public partial class HomeContent : UserControl
    {
        Home H;
        public HomeContent(Home h)
        {
            InitializeComponent();
            H = h;
        }
        
        // Hàm liệt kê các danh sách bài hát và nghệ sĩ ngẫu nhiên vào trong panel tương ứng
        private void HomeContent_Load(object sender, EventArgs e)
        {
            btnRefreshSong_Click(sender, e);
            btnRefreshArtist_Click(sender, e);
        }

        // Hàm liệt kê các bài hát trong cơ sở dữ liệu và chọn ngẫu nhiên các bài hát từ kết quả truy vấn đó
        private void btnRefreshSong_Click(object sender, EventArgs e)
        {
            int countSong = 0; // đếm số lượng bài hát
            HashSet<string> songDiffirent = new HashSet<string>(); // tránh trùng bài hát
            try
            {
                ConnectSQL connectSQL = new ConnectSQL();
                DataTable dtb = connectSQL.Query("SELECT * FROM SONGS INNER JOIN SINGER ON SONGS.ID_SINGER = SINGER.ID_SINGER ORDER BY NEWID()"); // kết table singer và songs để lấy các thông tin về bài hát và nghệ sĩ cần thiết
                flpSongs.Controls.Clear();

                foreach (DataRow dr in dtb.Rows)
                {
                    if (countSong >= 8) break;
                    if (songDiffirent.Contains(dr["ID_SONG"].ToString())) continue;

                    songDiffirent.Add(dr["ID_SONG"].ToString());
                    countSong++;

                    SongForm songForm = new SongForm(H, dr);
                    flpSongs.Controls.Add(songForm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing songs: " + ex.Message);
            }
        }

        // Hàm liệt kê các nghệ sĩ trong cơ sở dữ liệu và chọn ngẫu nhiên các nghệ sĩ từ kết quả truy vấn đó
        private void btnRefreshArtist_Click(object sender, EventArgs e)
        {
            int countArtist = 0;
            HashSet<string> artistDiffirent = new HashSet<string>();
            try
            {
                ConnectSQL connectSQL = new ConnectSQL();
                DataTable dtb = connectSQL.Query("SELECT * FROM SONGS INNER JOIN SINGER ON SONGS.ID_SINGER = SINGER.ID_SINGER ORDER BY NEWID()");
                flpArtists.Controls.Clear();

                foreach (DataRow dr in dtb.Rows)
                {
                    if (countArtist >= 8) break;
                    if (artistDiffirent.Contains(dr["ID_SINGER"].ToString())) continue;

                    artistDiffirent.Add(dr["ID_SINGER"].ToString());
                    countArtist++;

                    ArtistForm artistForm = new ArtistForm(H, dr);
                    flpArtists.Controls.Add(artistForm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing songs: " + ex.Message);
            }
        }
    }
}
