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

        private void HomeContent_Load(object sender, EventArgs e)
        {
            btnRefreshSong_Click(sender, e);
            btnRefreshArtist_Click(sender, e);
        }

        private void btnRefreshSong_Click(object sender, EventArgs e)
        {
            int countSong = 0;
            HashSet<string> songDiffirent = new HashSet<string>();
            try
            {
                ConnectSQL connectSQL = new ConnectSQL();
                DataTable dtb = connectSQL.Query("SELECT * FROM SONGS INNER JOIN SINGER ON SONGS.ID_SINGER = SINGER.ID_SINGER ORDER BY NEWID()");
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
