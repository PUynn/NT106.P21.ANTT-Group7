using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using NAudio.Wave;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Guna.UI2.WinForms;
using System.IO;
using System.Net.Sockets;
using Npgsql.Internal.TypeHandlers.LTreeHandlers;
using System.Net.Http;

namespace SONA
{
    public partial class ListenMusic : UserControl
    {
        private Home h;

        private List<string> playlistID;
        private string picturePath = null;
        private bool hasCustomPicture = false;

        private string id_song, picture_song, id_singer, name_singer, picture_singer, birthdate;

        public ListenMusic(Home h, string id_song)
        {
            this.h = h;
            this.id_song = id_song;
            this.playlistID = new List<string>();

            InitializeComponent();
            GetData();
            showSongsFavourite();
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
                    writer.Write("listenMusic");
                    writer.Write(id_song);
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        id_singer = reader.ReadString();
                        name_singer = reader.ReadString();
                        picture_singer = reader.ReadString();
                        birthdate = reader.ReadString();

                        picture_song = reader.ReadString();
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

        private void getPlaylist()
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getIDPlaylist");
                    writer.Write(User.idUser);

                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        int playlistCount = reader.ReadInt32();
                        playlistID.Clear();

                        for (int i = 0; i < playlistCount; i++)
                        {
                            string id_playlist = reader.ReadString();
                            playlistID.Add(id_playlist);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error retrieving playlists: " + response);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private void showSongsFavourite()
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("songFavourite");
                    writer.Write(User.idUser);
                    writer.Write(id_song);

                    string response = reader.ReadString();
                    if (response == "Exists")
                    {
                        btnFavourite.Checked = true;
                    }
                    else if (response == "Nothing")
                    {
                        btnFavourite.Checked = false;
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

        private void btnFavourite_Click(object sender, EventArgs e)
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    if (!btnFavourite.Checked)
                    {
                        writer.Write("addFavourite");
                        writer.Write(User.idUser);
                        writer.Write(id_song);

                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            btnFavourite.Checked = !btnFavourite.Checked;
                        }
                        else
                        {
                            MessageBox.Show(response);
                        }
                    }
                    else
                    {
                        writer.Write("removeFavourite");
                        writer.Write(User.idUser);
                        writer.Write(id_song);

                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            btnFavourite.Checked = !btnFavourite.Checked;
                        }
                        else
                        {
                            MessageBox.Show(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            pnAddPlaylist.Visible = !pnAddPlaylist.Visible;
            getPlaylist();
            if (pnAddPlaylist.Visible)
            {
                flpPlaylist.Controls.Clear();

                for (int i = 0; i < playlistID.Count; i++)
                {
                    PlaylistChoice playlistChoice = new PlaylistChoice(h, playlistID[i], id_song);
                    flpPlaylist.Controls.Add(playlistChoice);
                }
            }
        }

        private void setPicturePlaylist()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                cpbPicturePlaylist.Image = Image.FromFile(openFileDialog.FileName);
                picturePath = openFileDialog.FileName;
                hasCustomPicture = true;
            }
        }

        private void lblChoosePicture_Click(object sender, EventArgs e)
        {
            setPicturePlaylist();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                    using (NetworkStream stream = client.GetStream())
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        writer.Write("addPlaylist");
                        writer.Write(User.idUser);
                        writer.Write(User.emailUser);
                        writer.Write(tbNamePlaylist.Text.Trim());

                        if (hasCustomPicture && picturePath != null)
                        {
                            writer.Write("hasAvatar");
                            using (var fs = new FileStream(picturePath, FileMode.Open, FileAccess.Read))
                            {
                                byte[] imageData = new byte[fs.Length];
                                fs.Read(imageData, 0, imageData.Length);
                                writer.Write(imageData.Length);
                                writer.Write(imageData);
                            }
                        }
                        else
                        {
                            writer.Write("noAvatar");
                        }
                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            getPlaylist();
                            flpPlaylist.Controls.Clear();

                            for (int i = 0; i < playlistID.Count; i++)
                            {
                                PlaylistChoice playlistChoice = new PlaylistChoice(h, playlistID[i], id_song);
                                flpPlaylist.Controls.Add(playlistChoice);
                            }
                            playlistID.Clear();
                            pnCreatePlaylist.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Error adding playlist: " + response);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to server: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private async void  ListenMusic_Load(object sender, EventArgs e)
        {
            lblNameSinger.Text = name_singer;
            lblSince.Text = ConvertDate(birthdate);
            try
            {
                if (!string.IsNullOrEmpty(picture_singer))
                {
                    using (var htppClient = new HttpClient())
                    {
                        var imageData = await htppClient.GetByteArrayAsync(picture_singer);
                        using (var ms = new MemoryStream(imageData))
                        {
                            cpbPictureSinger.Image = Image.FromStream(ms);
                        }
                    }
                }
                else
                {
                    cpbPictureSinger.Image = null;
                }

                if (!string.IsNullOrEmpty(picture_song))
                {
                    using (var htppClient = new HttpClient())
                    {
                        var imageData = await htppClient.GetByteArrayAsync(picture_song);
                        using (var ms = new MemoryStream(imageData))
                        {
                            pbPictureSong.BackgroundImage = Image.FromStream(ms);
                        }
                    }
                }
                else
                {
                    pbPictureSong.BackgroundImage = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
                cpbPictureSinger.Image = null;
                pbPictureSong.BackgroundImage = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pnCreatePlaylist.Visible = !pnCreatePlaylist.Visible;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnCreatePlaylist.Visible = false;
        }

        private void btnCloseflpPlaylist_Click(object sender, EventArgs e)
        {
            pnAddPlaylist.Visible = false;
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

        // Hàm gọi form ArtsitInfor chứa các thông tin về nghệ sĩ
        private void cpbPictureSinger_Click(object sender, EventArgs e)
        {
            h.pnMain.Controls.Clear();
            h.pnMain.Controls.Add(new ArtistInfor(h, id_singer));
        }
    }
}