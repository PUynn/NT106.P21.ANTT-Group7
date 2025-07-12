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
        private List<string> songIds;
        private List<string> songFavouriteNames;

        private Home h;
        public Favourite(Home h)
        {
            this.h = h;
            songIds = new List<string>();
            songFavouriteNames = new List<string>();

            InitializeComponent();
            getData();
            getSongFavourireName();

            AutoCompleteStringCollection autoSource = new AutoCompleteStringCollection();
            autoSource.AddRange(songFavouriteNames.ToArray());
            txtSearch.AutoCompleteCustomSource = autoSource;
        }

        private void getData()
        {
            try
            {
                flpSongFavourites.Controls.Clear();
                songIds.Clear();

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
                            flpSongFavourites.Controls.Add(songSearch);
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

        private void getSongFavourireName()
        {
            using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
            using (NetworkStream stream = client.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                writer.Write("getAllSongFavouriteName");
                writer.Write(User.idUser);

                string response = reader.ReadString();

                if (response == "OK")
                {
                    int songCount = reader.ReadInt32();

                    for (int i = 0; i < songCount; i++)
                    {
                        string songName = reader.ReadString();
                        songFavouriteNames.Add(songName);
                    }
                }
                else
                {
                    MessageBox.Show(response);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Visible = true;
            btnSearch.Visible = false;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchText = txtSearch.Text.Trim();
                flpSongFavourites.Controls.Clear();

                try
                {
                    flpSongFavourites.Controls.Clear();
                    songIds.Clear();

                    using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                    using (NetworkStream stream = client.GetStream())
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        writer.Write("getIDSearchSongFavourite");
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
                                SongSearch songSearch = new SongSearch(h, songId, songIds);
                                flpSongFavourites.Controls.Add(songSearch);
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
}
