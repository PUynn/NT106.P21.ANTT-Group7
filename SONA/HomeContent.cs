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
using Guna.UI2.WinForms;

namespace SONA
{
    public partial class HomeContent : UserControl
    {
        private Home h;
        private List<string> songIds = new List<string>();
        private List<string> artistIds = new List<string>();
        private List<string> albumIds = new List<string>();

        public HomeContent(Home h)
        {
            InitializeComponent();
            this.h = h;
        }

        // Hàm liệt kê các danh sách bài hát và nghệ sĩ ngẫu nhiên vào trong panel tương ứng
        private void HomeContent_Load(object sender, EventArgs e)
        {
            btnRefreshSong_Click(sender, e);
            btnRefreshArtist_Click(sender, e);
            btnRefreshAlbum_Click(sender, e);
        }

        // Hàm liệt kê các bài hát từ danh sách đã nhận từ server
        private void btnRefreshSong_Click(object sender, EventArgs e)
        {
            try
            {
                flpSongs.Controls.Clear();
                songIds.Clear();

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

                        }
                        for (int i = 0; i < 10; i++)
                        {
                            SongForm songForm = new SongForm(h, songIds[i], songIds);
                            flpSongs.Controls.Add(songForm);
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

        // Hàm liệt kê các nghệ sĩ từ danh sách đã lấy từ Supabase
        private void btnRefreshArtist_Click(object sender, EventArgs e)
        {
            try
            {
                flpArtists.Controls.Clear();
                artistIds.Clear();

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
                        }
                        for (int i = 0; i < 10; i++)
                        {
                            ArtistForm artistForm = new ArtistForm(h, artistIds[i]);
                            flpArtists.Controls.Add(artistForm);
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

        private void btnRefreshAlbum_Click(object sender, EventArgs e)
        {
            try
            {
                flpAlbums.Controls.Clear();
                albumIds.Clear();

                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getIDAlbum");
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        int albumCount = reader.ReadInt32();

                        for (int i = 0; i < albumCount; i++)
                        {
                            string id_album = reader.ReadString();
                            albumIds.Add(id_album);

                            AlbumForm albumForm = new AlbumForm(h, id_album);
                            flpAlbums.Controls.Add(albumForm);
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

        private void btnMusic_Click(object sender, EventArgs e)
        {
            pnAll.Visible = false;
            flpMusic.Visible = true;
            flpMusic.Controls.Clear();
            
            Title title = new Title("Music:");
            flpMusic.Controls.Add(title);

            foreach (string songId in songIds)
            {
                SongForm songForm = new SongForm(h, songId,songIds);
                flpMusic.Controls.Add(songForm);
            }
        }

        private void btnArtists_Click(object sender, EventArgs e)
        {
            pnAll.Visible = false;
            flpMusic.Visible = true;
            flpMusic.Controls.Clear();

            Title title = new Title("Artists:");
            flpMusic.Controls.Add(title);

            foreach (string artistId in artistIds)
            {
                ArtistForm artistForm = new ArtistForm(h, artistId);
                flpMusic.Controls.Add(artistForm);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            flpMusic.Visible = false;
            pnAll.Visible = true;
        }
    }
}