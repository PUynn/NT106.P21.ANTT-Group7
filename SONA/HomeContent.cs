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

            try
            {
                ConnectSQL connectSQL = new ConnectSQL();
                DataTable dtb;

                dtb = connectSQL.Query("SELECT * FROM SONGS INNER JOIN SINGER ON SONGS.ID_SINGER = SINGER.ID_SINGER");

                foreach (DataRow dr in dtb.Rows)
                {
                    SongForm songForm = new SongForm(H, dr);
                    flpSongs.Controls.Add(songForm);
                }

                foreach (DataRow dr in dtb.Rows)
                {
                    ArtistForm artistForm = new ArtistForm(H, dr);
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
