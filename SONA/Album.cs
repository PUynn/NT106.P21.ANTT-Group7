using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace SONA
{
    public partial class Album : UserControl
    {
        private Home h;
        private string idAlbum, idUser;
        private List<string> songIds = new List<string>();

        public Album(Home h, string idAlbum, string idUser)
        {
            this.h = h;
            this.idAlbum = idAlbum;
            this.idUser = idUser;
            InitializeComponent();
            getIdSongFromAlbum();
        }

        private void getIdSongFromAlbum()
        {
            try
            {
                flpSongs.Controls.Clear();

                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getIdSongFromAlbum");
                    writer.Write(idAlbum);
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
                            SongSearch songSearch = new SongSearch(h, songIds[i], idUser, songIds);
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
                MessageBox.Show("Lỗi kết nối tới Server: " + ex.Message);
            }
        }
    }
}
