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
    public partial class SearchForm : UserControl
    {
        private Home h;
        private string idUser;
        private List<string> songIds = new List<string>();
        private List<string> artistIds = new List<string>();

        public SearchForm(Home h, string idUser)
        {
            InitializeComponent();
            this.h = h;
            this.idUser = idUser;
        }

        private void getIDSong()
        {
            try
            {
                flpResult.Controls.Clear();
                Title title = new Title("Songs:");
                flpResult.Controls.Add(title);

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
                            SongSearch songSearch = new SongSearch(h, songId, idUser, songIds);
                            flpResult.Controls.Add(songSearch);
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

        private void getIDSinger()
        {
            try
            {
                Title title = new Title("Singers:");
                flpResult.Controls.Add(title);

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
                            artistIds.Add(id_singer);
                            ArtistForm artistForm = new ArtistForm(h, id_singer, idUser);
                            flpResult.Controls.Add(artistForm);
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

        private void SearchForm_Load(object sender, EventArgs e)
        {
            getIDSong();
            getIDSinger();
        }

        private void btnSongs_Click(object sender, EventArgs e)
        {
            Title title = new Title("Songs:");

            flpResult.Controls.Clear();
            flpResult.Controls.Add(title);
            
            foreach (var songId in songIds)
            {
                SongSearch songSearch = new SongSearch(h, songId, idUser, songIds);
                flpResult.Controls.Add(songSearch);
            }
        }

        private void btnArtists_Click(object sender, EventArgs e)
        {
            Title title = new Title("Singers:");

            flpResult.Controls.Clear();
            flpResult.Controls.Add(title);

            foreach (var artistId in artistIds)
            {
                ArtistForm artistForm = new ArtistForm(h, artistId, idUser);
                flpResult.Controls.Add(artistForm);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Title title = new Title("Songs:");

            flpResult.Controls.Clear();
            flpResult.Controls.Add(title);

            foreach (var songId in songIds)
            {
                SongSearch songSearch = new SongSearch(h, songId, idUser, songIds);
                flpResult.Controls.Add(songSearch);
            }

            title = new Title("Singers:");
            flpResult.Controls.Add(title);

            foreach (var artistId in artistIds)
            {
                ArtistForm artistForm = new ArtistForm(h, artistId, idUser);
                flpResult.Controls.Add(artistForm);

            }
        }
    }
}