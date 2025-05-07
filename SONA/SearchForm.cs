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
    public partial class SearchForm: UserControl
    {
        ConnectSQL connectSQL;
        Home H;
        public SearchForm(Home h)
        {
            InitializeComponent();
            H = h;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            try
            {
                connectSQL = new ConnectSQL();
                DataTable dtb = connectSQL.Query("SELECT * FROM SONGS INNER JOIN SINGER ON SONGS.ID_SINGER = SINGER.ID_SINGER");

                flpResult.Controls.Clear();
                foreach (DataRow dr in dtb.Rows)
                {
                    SongSearch songSearch = new SongSearch(H, dr["NAME_SONG"].ToString(), (dr["PICTURE_SONG"].ToString()), dr["AM_THANH"].ToString(), dr["NAME_SINGER"].ToString());
                    flpResult.Controls.Add(songSearch);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading song images: " + ex.Message);
            }
        }
    }
}
