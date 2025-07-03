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
    public partial class PlaylistList : UserControl
    {
        private Home h;
        private string idUser;

        public PlaylistList(Home h, string idUser)
        {
            InitializeComponent();
            this.h = h;
            this.idUser = idUser;
        }
    }
}
