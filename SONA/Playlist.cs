using SONA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class Playlist : UserControl
    {
        private Home h;
        private string idPlaylist, namePlaylist, picturePlaylist;
        private List<string> songIds;
        private List<string> songInPlaylist;
        private Dictionary<string, SongPlaylist> songPlaylists;

        public Playlist(Home h, string idPlaylist, string namePlaylist, string picturePlaylist)
        {
            this.h = h;
            this.idPlaylist = idPlaylist;
            this.namePlaylist = namePlaylist;
            this.picturePlaylist = picturePlaylist;

            songIds = new List<string>();
            songInPlaylist = new List<string>();
            songPlaylists = new Dictionary<string, SongPlaylist>();

            InitializeComponent();
            getIdSongFromPlaylist();

            AutoCompleteStringCollection autoSource = new AutoCompleteStringCollection();
            autoSource.AddRange(h.songNames.ToArray());
            txtSearch.AutoCompleteCustomSource = autoSource;
        }

        private void getIdAllSong()
        {
            try
            {
                flpListSong.Controls.Clear();
                songIds.Clear();

                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getIDSong");

                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        int songCount = reader.ReadInt32();
                        for (int i = 0; i < songCount; i++)
                        {
                            string id_song = reader.ReadString();
                            songIds.Add(id_song);
                        }
                        foreach (var songId in songIds)
                        {
                            SongChoice songChoice = new SongChoice(h, idPlaylist, songId);
                            flpListSong.Controls.Add(songChoice);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private void getIdSongFromPlaylist()
        {
            try
            {
                flpSongs.Controls.Clear();
                songInPlaylist.Clear();

                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getIdSongFromPlaylist");
                    writer.Write(idPlaylist);
                    
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        int count = reader.ReadInt32();
                        for (int i = 0; i < count; i++)
                        {
                            string id_song = reader.ReadString();
                            songInPlaylist.Add(id_song);

                        }
                        foreach (var songId in songInPlaylist)
                        {
                            SongPlaylist songPlaylist = new SongPlaylist(h, songId, idPlaylist, songInPlaylist);
                            songPlaylist.SongRemoved += SongPlaylist_SongRemoved;
                            
                            flpSongs.Controls.Add(songPlaylist);
                            songPlaylists[songId] = songPlaylist;
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

        private void SongPlaylist_SongRemoved(object sender, string idSong)
        {
            if (songPlaylists.ContainsKey(idSong))
            {
                SongPlaylist removedSong = songPlaylists[idSong];
                flpSongs.Controls.Remove(removedSong);
                songPlaylists.Remove(idSong);
            }
        }

        private async void Playlist_Load(object sender, EventArgs e)
        {
            lblNamePlaylist.Text = namePlaylist;
            lblNameUser.Text = User.emailUser;

            try
            {
                if (!string.IsNullOrEmpty(picturePlaylist))
                {
                    using (var htppClient = new HttpClient())
                    {
                        var imageData = await htppClient.GetByteArrayAsync(picturePlaylist);
                        using (var ms = new MemoryStream(imageData))
                        {
                            pbPicturePlaylist.BackgroundImage = Image.FromStream(ms);
                        }
                    }
                }
                else
                {
                    pbPicturePlaylist.BackgroundImage = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading playlist image: " + ex.Message);
                pbPicturePlaylist.BackgroundImage = null;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchText = txtSearch.Text.Trim();
                flpListSong.Controls.Clear();
                songIds.Clear();

                try
                {
                    flpListSong.Controls.Clear();

                    using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                    using (NetworkStream stream = client.GetStream())
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        writer.Write("getIDSearchSong");
                        writer.Write(searchText);

                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            int songCount = reader.ReadInt32();
                            for (int i = 0; i < songCount; i++)
                            {
                                string id_song = reader.ReadString();
                                songIds.Add(id_song);
                            }
                            foreach (var songId in songIds)
                            {
                                SongChoice songChoice = new SongChoice(h, idPlaylist, songId);
                                flpListSong.Controls.Add(songChoice);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            getIdAllSong();
            pnAddSong.Visible = true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            songInPlaylist.Clear();

            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getIdSongFromPlaylist");
                    writer.Write(idPlaylist);

                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        int count = reader.ReadInt32();
                        for (int i = 0; i < count; i++)
                        {
                            string id_song = reader.ReadString();
                            songInPlaylist.Add(id_song);
                        }
                        h.listenMusic(songInPlaylist[0], songInPlaylist);
                    }
                    else
                    {
                        MessageBox.Show(response);
                    }
                }
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            getIdSongFromPlaylist();
            pnAddSong.Visible = false;  
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnAddSong.Visible = false;
        }
    }
}
