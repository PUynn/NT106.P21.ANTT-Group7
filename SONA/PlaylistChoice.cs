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
using System.Net.Http;

namespace SONA
{
    public partial class PlaylistChoice: UserControl
    {
        private Home h;
        private string idPlaylist, idSong;

        public PlaylistChoice(Home h, string idPlaylist, string idSong)
        {
            this.h = h;
            this.idPlaylist = idPlaylist;
            this.idSong = idSong;

            InitializeComponent();
        }

        private async void getPlaylistInfor()
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getPlaylistInfor");
                    writer.Write(idPlaylist);

                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        string namePlaylist = reader.ReadString();
                        string picturePlaylist = reader.ReadString();
                        
                        lblNamePlaylist.Text = namePlaylist;
                        if (!string.IsNullOrEmpty(picturePlaylist))
                        {
                            using (var htppClient = new HttpClient())
                            {
                                var imageData = await htppClient.GetByteArrayAsync(picturePlaylist);
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
                        MessageBox.Show("Error retrieving playlist information: " + response);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private void checkSonginPlaylist()
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("checkSongInPlaylist");
                    writer.Write(idPlaylist);
                    writer.Write(idSong);

                    string response = reader.ReadString();
                    if (response == "Exists")
                    {
                        btnCheck.Checked = true;
                    }
                    else if (response == "Nothing")
                    {
                        btnCheck.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("Error checking song in playlist: " + response);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    if (!btnCheck.Checked)
                    {
                        writer.Write("insertSongToPlaylist");
                        writer.Write(idPlaylist);
                        writer.Write(idSong);

                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            btnCheck.Checked = !btnCheck.Checked;
                        }
                        else
                        {
                            MessageBox.Show("Error insert song to playlist: " + response);
                        }
                    }
                    else
                    {
                        writer.Write("deleteSongFromPlaylist");
                        writer.Write(idPlaylist);
                        writer.Write(idSong);

                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            btnCheck.Checked = !btnCheck.Checked;
                        }
                        else
                        {
                            MessageBox.Show("Error remove song to playlist: " + response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }
        private void PlaylistChoice_Load(object sender, EventArgs e)
        {
            getPlaylistInfor();
            checkSonginPlaylist();
        }
    }
}
