using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class PlaylistForm : UserControl
    {
        private Home h;
        private string idPlaylist, idUser;

        public PlaylistForm(Home h, string idPlaylist, string idUser)
        {
            InitializeComponent();
            this.h = h;
            this.idPlaylist = idPlaylist;
            this.idUser = idUser;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Playlist a = new Playlist(h, idPlaylist, idUser);
            h.pnMain.Controls.Clear();
            h.pnMain.Controls.Add(a);
        }
    }
}
