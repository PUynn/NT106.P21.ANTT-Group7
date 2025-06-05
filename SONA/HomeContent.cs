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
        Home H;

        public HomeContent(Home h)
        {
            InitializeComponent();
            H = h;
        }

        // Hàm liệt kê các danh sách bài hát và nghệ sĩ ngẫu nhiên vào trong panel tương ứng
        private void HomeContent_Load(object sender, EventArgs e)
        {
            btnRefreshSong_Click(sender, e);
            btnRefreshArtist_Click(sender, e);
        }

        // Hàm liệt kê các bài hát từ danh sách đã nhận từ server
        private void btnRefreshSong_Click(object sender, EventArgs e)
        {
            try
            {
                flpSongs.Controls.Clear();

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
                            SongForm songForm = new SongForm(H, id_song);
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

                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getIDSinger"); // Gửi yêu cầu lấy bài hát
                    string response = reader.ReadString(); // Nhận phản hồi từ server

                    if (response == "OK")
                    {
                        int singerCount = reader.ReadInt32(); // Đọc số lượng bài hát

                        for (int i = 0; i < singerCount; i++)
                        {
                            string id_singer = reader.ReadString();
                            ArtistForm artistForm = new ArtistForm(H, id_singer);
                            flpArtists.Controls.Add(artistForm);
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
    }
}