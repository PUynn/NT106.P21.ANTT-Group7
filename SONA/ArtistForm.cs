using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace SONA
{
    public partial class ArtistForm: UserControl
    {
        Home H;
        DataRow src;

        public ArtistForm(Home h, DataRow dr)
        {
            InitializeComponent();
            H = h;
            src = dr;
        }

        private void btnPictureSong_Click(object sender, EventArgs e)
        {
            ArtistInfor artistInfor = new ArtistInfor(H, src);
            H.panel1.Controls.Clear();
            H.panel1.Controls.Add(artistInfor);
        }

        private void ArtistForm_Load(object sender, EventArgs e)
        {
            lblNameSinger.Text = src["NAME_SINGER"].ToString();
            btnPictureSinger.BackgroundImage = Image.FromFile(src["PICTURE_SINGER"].ToString());
            btnPictureSinger.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
