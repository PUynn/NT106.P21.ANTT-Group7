using SONA;
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
    public partial class Playlist : UserControl
    {
        private Home h;
        private string idPlaylist, idUser;
        private List<string> songIds = new List<string>();

        public Playlist(Home h, string idPlaylist, string idUser)
        {
            InitializeComponent();
            this.h = h;
            this.idPlaylist = idPlaylist;
            this.idUser = idUser;
        }
    }
}
