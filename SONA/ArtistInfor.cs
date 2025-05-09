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
    public partial class ArtistInfor: UserControl
    {
        Home H;
        DataRow src;

        public ArtistInfor(Home h, DataRow dr)
        {
            InitializeComponent();
            src = dr;
            H = h;
        }

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

        private void ArtistInfor_Load(object sender, EventArgs e)
        {
            ConnectSQL connectSQL = new ConnectSQL();
            DataTable dtb = connectSQL.Query("SELECT * FROM SONGS INNER JOIN SINGER ON SONGS.ID_SINGER = SINGER.ID_SINGER WHERE SINGER.ID_SINGER = " + src["ID_SINGER"].ToString());

            foreach (DataRow dr in dtb.Rows)
            {
                SongSearch songSearch = new SongSearch(H, dr);
                flpSongs.Controls.Add(songSearch);
            }

            btnAvatar.BackgroundImage = Image.FromFile(src["PICTURE_SINGER"].ToString());
            btnAvatar.BackgroundImageLayout = ImageLayout.Stretch;

            lblNameSinger.Text = src["NAME_SINGER"].ToString();
            lblDate.Text = ConvertDate(src["BIRTHDATE"].ToString());
            lblCountry.Text = src["NATIONALITY"].ToString();

        }
    }
}
