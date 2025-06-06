using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using System.Net.Sockets;

namespace SONA
{
    public partial class ArtistInfor : UserControl
    {
        private Home H;
        private string id_singer, name_singer, picture_singer, birthdate, nationality, idUser;
        private List<string> id_song;

        public ArtistInfor(Home h, string id_singer, string idUser)
        {
            H = h;
            this.id_singer = id_singer;
            this.idUser = idUser;
            id_song = new List<string>();

            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("artistInfor");
                    writer.Write(id_singer);
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        id_singer = reader.ReadString();
                        name_singer = reader.ReadString();
                        picture_singer = reader.ReadString();
                        birthdate = reader.ReadString();
                        nationality = reader.ReadString();

                        int songCount = reader.ReadInt32();
                        for (int i = 0; i < songCount; i++)
                        {
                            id_song.Add(reader.ReadString());
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

        // Hàm chuyển đổi định dạng ngày tháng
        private string ConvertDate(string date)
        {
            try
            {
                DateTime parsedDate = DateTime.Parse(date);
                string month = parsedDate.ToString("MMMM");
                int day = parsedDate.Day;
                int year = parsedDate.Year;
                return $"Since {month} {day}, {year}";
            }
            catch (FormatException)
            {
                return "Invalid date format";
            }
        }

        // Hàm in ra danh sách bài hát của nghệ sĩ
        private async void ArtistInfor_Load(object sender, EventArgs e)
        {
            try
            {
                flpSongs.Controls.Clear();
                foreach (string id in id_song)
                {
                    SongSearch songSearch = new SongSearch(H, id, idUser);
                    flpSongs.Controls.Add(songSearch);
                }

                // Tải hình ảnh của nghệ sĩ từ URL
                string pictureUrl = picture_singer;
                if (!string.IsNullOrEmpty(pictureUrl))
                {
                    using (var client = new HttpClient())
                    {
                        var imageData = await client.GetByteArrayAsync(pictureUrl);
                        if (imageData != null && imageData.Length > 0)
                        {
                            using (var ms = new MemoryStream(imageData))
                            {
                                btnAvatar.BackgroundImage = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            btnAvatar.BackgroundImage = null;
                        }
                    }
                }
                else
                {
                    btnAvatar.BackgroundImage = null;
                }

                lblNameSinger.Text = name_singer;
                lblDate.Text = ConvertDate(birthdate);
                lblCountry.Text = nationality;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading artist information: " + ex.Message);
                btnAvatar.BackgroundImage = null;
            }
        }
    }
}