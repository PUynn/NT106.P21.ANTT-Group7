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
    public partial class AlbumList: UserControl
    {
        private Home h;
        private string idUser;
        public AlbumList(Home h, string idUser)
        {
            InitializeComponent();
            this.h = h;
            this.idUser = idUser;
            getAlbumList();
        }

        private void getAlbumList()
        {
            flpAlbum.Controls.Clear();
            for (int i = 0; i < 10; i++) 
            {
                AlbumForm albumForm = new AlbumForm(h, idUser);
                flpAlbum.Controls.Add(albumForm);
            }
        }
    }
}
