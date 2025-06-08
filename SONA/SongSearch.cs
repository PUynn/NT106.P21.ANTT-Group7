using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using System.ComponentModel.Design;
using System.IO;
using System.Net.Sockets;

namespace SONA
{
    public partial class SongSearch : UserControl
    {
        private Home H;
        private bool isFavorited = false;
        
        private List<string> songIds;
        private string id_song, name_song, picture_song, id_singer, name_singer;
        private string idUser;

        public SongSearch(Home h, string id_song, string idUser, List<string> songIds)
        {
            H = h;
            this.id_song = id_song;
            this.idUser = idUser;
            this.songIds = new List<string>(songIds);
            
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
                    writer.Write("songSearch");
                    writer.Write(id_song);
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        name_song = reader.ReadString();
                        picture_song = reader.ReadString();
                        id_singer = reader.ReadString();
                        name_singer = reader.ReadString();
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

        // Hàm gọi form ListenMusic để phát nhạc
        private void btnPictureSong_Click(object sender, EventArgs e)
        {
            ListenMusic listenMusic = new ListenMusic(H, id_song, idUser, songIds);
            H.pnMain.Controls.Clear();
            H.pnMain.Controls.Add(listenMusic);
            H.SetCurrentListenMusic(listenMusic);
        }

        private void lblNameSinger_Click(object sender, EventArgs e)
        {
            ArtistInfor artistInfor = new ArtistInfor(H, id_singer, idUser);
            H.pnMain.Controls.Clear();
            H.pnMain.Controls.Add(artistInfor);
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
                    writer.Write("songFavurite");
                    writer.Write(idUser);
                    writer.Write(id_song);

                    string response = reader.ReadString();
                    if (response == "Exists")
                    {
                        isFavorited = true;
                        btnFavourite.Checked = true;
                    }
                    else if (response == "Nothing")
                    {
                        isFavorited = false;
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

        private void btnFavorited_Click(object sender, EventArgs e)
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    if (!isFavorited)
                    {
                        writer.Write("addFavourite");
                        writer.Write(idUser);
                        writer.Write(id_song);

                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            isFavorited = true;
                            btnFavourite.Checked = true;
                        }
                        else
                        {
                            isFavorited = false;
                            btnFavourite.Checked = false;
                            MessageBox.Show(response);
                        }
                    }
                    else
                    {
                        writer.Write("removeFavourite");
                        writer.Write(idUser);
                        writer.Write(id_song);

                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            isFavorited = false;
                            btnFavourite.Checked = false;
                        }
                        else
                        {
                            isFavorited = true;
                            btnFavourite.Checked = true;
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

        // Hàm ghi các nội dung cần thiết cho 1 bài hát
        private void SongSearch_Load(object sender, EventArgs e)
        {
            lblNameSong.Text = name_song;
            lblNameSinger.Text = name_singer;

            try
            {
                using (var wc = new System.Net.WebClient())
                using (var stream = wc.OpenRead(picture_song))
                {
                    btnPictureSong.BackgroundImage = Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }
    }
}