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
    public partial class AlbumForm: UserControl
    {
        private Home h;
        private string idAlbum;

        public AlbumForm(Home h, string idAlbum)
        {
            InitializeComponent();
            this.h = h;
            this.idAlbum = idAlbum;
        }

        private void btnPictureAlbum_Click(object sender, EventArgs e)
        {
            Album album = new Album(h, idAlbum);
            h.pnMain.Controls.Clear();
            h.pnMain.Controls.Add(album);
        }
    }
}
