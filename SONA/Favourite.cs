using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class Favourite : UserControl
    {
        private List<string> songIds = new List<string>();
        private Home h;
        public Favourite(Home h)
        {
            InitializeComponent();
            this.h = h;
            getData();
        }

        private void getData()
        {
            try
            {
                flpSongs.Controls.Clear();

                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("Favourite");
                    writer.Write(User.idUser);
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        int count = reader.ReadInt32();
                        for (int i = 0; i < count; i++)
                        {
                            string id_song = reader.ReadString();
                            songIds.Add(id_song);
                        }

                        for (int i = 0; i < count; i++)
                        {
                            SongSearch songSearch = new SongSearch(h, songIds[i], songIds);
                            flpSongs.Controls.Add(songSearch);
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
