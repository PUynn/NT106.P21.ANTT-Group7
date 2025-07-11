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
using System.Net.Http;
using System.Net.Sockets;

namespace SONA
{
    public partial class PlaylistForm : UserControl
    {
        private Home h;
        private string idPlaylist;
        private string pictureUrl;

        // Định nghĩa sự kiện khi playlist được xóa
        public event EventHandler<string> PlaylistRemoved;

        public PlaylistForm(Home h, string idPlaylist)
        {
            InitializeComponent();
            this.h = h;
            this.idPlaylist = idPlaylist;
        }

        private async void PlaylistForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("playlistForm");
                    writer.Write(idPlaylist);

                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        lblNamePlaylist.Text = reader.ReadString();

                        pictureUrl = reader.ReadString();
                        if (!string.IsNullOrEmpty(pictureUrl))
                        {
                            using (var htppClient = new HttpClient())
                            {
                                var imageData = await htppClient.GetByteArrayAsync(pictureUrl);
                                using (var ms = new MemoryStream(imageData))
                                {
                                    btnPicturePlaylist.BackgroundImage = Image.FromStream(ms);
                                }
                            }
                        }
                        else
                        {
                            btnPicturePlaylist.BackgroundImage = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error loading playlist image: " + response);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}");
                btnPicturePlaylist.BackgroundImage = null;
            }
        }

        private void btnPicturePlaylist_Click(object sender, EventArgs e)
        {
            Playlist playlist = new Playlist(h, idPlaylist, lblNamePlaylist.Text, pictureUrl);
            h.pnMain.Controls.Clear();
            h.pnMain.Controls.Add(playlist);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("deletePlaylist");
                    writer.Write(idPlaylist);

                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        PlaylistRemoved?.Invoke(this, idPlaylist);
                    }
                    else
                    {
                        MessageBox.Show("Error delete Playlist: " + response);
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