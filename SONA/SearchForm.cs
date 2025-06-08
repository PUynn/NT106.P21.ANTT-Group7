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
        Home H;
        private string idUser;
        private List<string> songIds = new List<string>();

        public SearchForm(Home h, string idUser)
        {
            InitializeComponent();
            H = h;
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
                    writer.Write("getIDSong"); // Gửi yêu cầu lấy bài hát
                    string response = reader.ReadString(); // Nhận phản hồi từ server

                    if (response == "OK")
                    {
                        int songCount = reader.ReadInt32(); // Đọc số lượng bài hát
                        for (int i = 0; i < songCount; i++)
                        {
                            string id_song = reader.ReadString();
                            songIds.Add(id_song);
                            SongSearch songSearch = new SongSearch(H, id_song, idUser, songIds);
                            flpResult.Controls.Add(songSearch);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response); // Hiển thị lỗi từ server
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
                Title title = new Title("Artists:");
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
                            ArtistForm artistForm = new ArtistForm(H, id_singer, idUser);
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
            getIDSong();
        }

        private void btnArtists_Click(object sender, EventArgs e)
        {
            flpResult.Controls.Clear();
            getIDSinger();
        }
    }
}