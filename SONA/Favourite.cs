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
        private string idUser;
        private List<string> songIds = new List<string>();
        private Home h;
        public Favourite(Home h, string idUser)
        {
            InitializeComponent();
            this.h = h;
            this.idUser = idUser;
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
                    writer.Write(idUser);
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
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtKeyword.Visible = true;
            txtKeyword.Focus();
        }

        private void Favourite_Load(object sender, EventArgs e)
        {
            txtKeyword.KeyDown += txtKeyword_KeyDown;
            txtKeyword.Leave += TxtKeyword_Leave;
        }

        private void TxtKeyword_Leave(object sender, EventArgs e)
        {
            txtKeyword.Visible = false;
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SearchFavouriteSongs(txtKeyword.Text.Trim());
            }
        }

        private void SearchFavouriteSongs(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                getData(); // Nếu không nhập gì thì load lại toàn bộ
                return;
            }

            try
            {
                flpSongs.Controls.Clear();
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("SearchFavourite"); // Lệnh này bạn cần xử lý ở server
                    writer.Write(idUser);
                    writer.Write(keyword);

                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        int count = reader.ReadInt32();
                        var songIds = new List<string>();
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
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }
    }
}
