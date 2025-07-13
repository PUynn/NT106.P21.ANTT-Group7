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
using System.Net.Http;

namespace SONA
{
    public partial class Album : UserControl
    {
        private Home h;
        private string idAlbum, nameAlbum, pictureAlbum, description;
        private List<string> songIds;

        public Album(Home h, string idAlbum, string nameAlbum, string pictureAlbum, string description)
        {
            this.h = h;
            this.idAlbum = idAlbum;
            this.nameAlbum = nameAlbum;
            this.pictureAlbum = pictureAlbum;
            this.description = description;
            songIds = new List<string>();

            InitializeComponent();
            getIdSongFromAlbum();
        }

        private void Album_Load(object sender, EventArgs e)
        {
            lblNameAlbum.Text = nameAlbum;
            lblDescription.Text = description;

            if (!string.IsNullOrEmpty(pictureAlbum))
            {
                using (var httpClient = new HttpClient())
                {
                    var imageData = httpClient.GetByteArrayAsync(pictureAlbum).Result;
                    using (var ms = new MemoryStream(imageData))
                    {
                        pbPictureAlbum.BackgroundImage = Image.FromStream(ms);
                    }
                }
            }
            else
            {
                pbPictureAlbum.BackgroundImage = null;
            }
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
                            SongAlbum songAlbum = new SongAlbum(h, songIds[i], songIds);
                            flpSongs.Controls.Add(songAlbum);
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

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                h.listenMusic(songIds[0], songIds);
            }
            catch (Exception ex)
            {

            }
        }
        private void btnShuffle_Click(object sender, EventArgs e)
        {
            btnPlay_Click(sender, e);
            h.btnShuffle_Click(sender, e);
        }
    }
}