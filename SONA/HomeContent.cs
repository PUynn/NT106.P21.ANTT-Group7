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
        ConnectSQL connectSQL;
        DataTable dtbSongs, dtbArtist;

        public HomeContent(Home h)
        {
            InitializeComponent();
            H = h;
        }

        private void HomeContent_Load(object sender, EventArgs e)
        {

            try
            {
                connectSQL = new ConnectSQL();
                dtbSongs = connectSQL.Get("SONGS");
                dtbArtist = connectSQL.Get("SINGER");

                foreach (DataRow dr in dtbSongs.Rows)
                {
                    SongForm songForm = new SongForm(H, dr["NAME_SONG"].ToString(), (dr["PICTURE_SONG"].ToString()), dr["AM_THANH"].ToString());
                    flpSongs.Controls.Add(songForm);
                }

                foreach (DataRow dr in dtbArtist.Rows)
                {
                    ArtistForm artistForm = new ArtistForm(H, dr["NAME_SINGER"].ToString(), (dr["PICTURE_SINGER"].ToString()));
                    flpArtists.Controls.Add(artistForm);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading song images: " + ex.Message);
            }
        }
    }
}
