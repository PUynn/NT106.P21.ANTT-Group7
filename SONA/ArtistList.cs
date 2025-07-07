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
    public partial class ArtistList: UserControl
    {
        private Home h;
        
        public ArtistList(Home h)
        {
            this.h = h;
            InitializeComponent();
            getIdArtist();
        }
        
        private void getIdArtist()
        {
            try
            {
                Title title = new Title("Artists:");
                flpArtists.Controls.Clear();
                flpArtists.Controls.Add(title);

                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getIDSinger");
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        int singerCount = reader.ReadInt32();

                        for (int i = 0; i < singerCount; i++)
                        {
                            string id_singer = reader.ReadString();
                            ArtistForm artistForm = new ArtistForm(h, id_singer);
                            flpArtists.Controls.Add(artistForm);
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
