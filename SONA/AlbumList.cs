using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace SONA
{
    public partial class AlbumList : UserControl
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
            try
            {
                Title title = new Title("Albums:");
                flpAlbum.Controls.Clear();
                flpAlbum.Controls.Add(title);

                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getIDAlbum");
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        int albumCount = reader.ReadInt32();
                        for (int i = 0; i < albumCount; i++)
                        {
                            string id_album = reader.ReadString();
                            AlbumForm albumForm = new AlbumForm(h, id_album, idUser);
                            flpAlbum.Controls.Add(albumForm);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }
    }
}
