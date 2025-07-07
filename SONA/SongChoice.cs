using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
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
    public partial class SongChoice : UserControl
    {
        private string idPlaylist;
        private string idSong;

        public SongChoice(Home h, string id_playlist, string id_song)
        {
            idPlaylist = id_playlist;
            idSong = id_song;

            InitializeComponent();
            showSongInPlaylist();
        }
        private void showSongInPlaylist()
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
                        btnAdd.Checked = true;
                    }
                    else if (response == "Nothing")
                    {
                        btnAdd.Checked = false;
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

        private void SongChoice_Load(object sender, EventArgs e)
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("songChoice");
                    writer.Write(idSong);
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        lblNameSong.Text = reader.ReadString();
                        lblNameSinger.Text = reader.ReadString();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    if (btnAdd.Checked)
                    {
                        writer.Write("deleteSongFromPlaylist");
                        writer.Write(idPlaylist);
                        writer.Write(idSong);

                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            btnAdd.Checked = !btnAdd.Checked;
                        }
                        else
                        {
                            MessageBox.Show("Error remove song to playlist: " + response);
                        }
                    }
                    else
                    {
                        writer.Write("insertSongToPlaylist");
                        writer.Write(idPlaylist);
                        writer.Write(idSong);

                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            btnAdd.Checked = !btnAdd.Checked;
                        }
                        else
                        {
                            MessageBox.Show("Error adding song to playlist: " + response);
                        }
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
