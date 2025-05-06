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
        string srcSinger, srcImage;

        public ArtistForm(Home h, string nameSinger, string imgSinger)
        {
            InitializeComponent();
            H = h;
            srcSinger = nameSinger;
            srcImage = imgSinger;

            lblNameSinger.Text = srcSinger;
            btnPictureSinger.BackgroundImage = Image.FromFile(srcImage);
            btnPictureSinger.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnPictureSong_Click(object sender, EventArgs e)
        {

        }
    }
}
