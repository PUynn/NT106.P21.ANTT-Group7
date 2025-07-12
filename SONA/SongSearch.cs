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
        private Home h;
        private bool isFavorited = false;

        private List<string> songIds;
        private string id_song, name_song, picture_song, id_singer, name_singer;
        private string idUser;
        private string type; // "song" hoặc "artist"

        public SongSearch(Home h, string id, string idUser, List<string> songIds, string type)
        {
            this.h = h;
            this.idUser = idUser;
            this.type = type;
            this.songIds = songIds != null ? new List<string>(songIds) : new List<string>();

            if (type == "song")
                this.id_song = id;
            else
                this.id_singer = id;

            InitializeComponent();
            if (type == "song")
            {
                GetData();
                showSongsFavourite();
            }
            else if (type == "artist")
            {
                GetArtistData();
                btnFavourite.Visible = false; // Ẩn nút yêu thích với nghệ sĩ
            }
        }

        public SongSearch(Home h, string id_song, string idUser, List<string> songIds)
            : this(h, id_song, idUser, songIds, "song")
        {
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

        private void GetArtistData()
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("artistForm");
                    writer.Write(id_singer);
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        name_singer = reader.ReadString();
                        picture_song = reader.ReadString(); // Tận dụng picture_song để lưu ảnh nghệ sĩ
                    }
                    else
                    {
                        MessageBox.Show(response);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading artist: " + ex.Message);
            }
        }

        private void btnPictureSong_Click(object sender, EventArgs e)
        {
            if (type == "song" && h != null) // Chỉ thực hiện khi h không null (không phải trong RoomForm)
            {
                ListenMusic listenMusic = new ListenMusic(h, id_song, idUser, songIds);
                h.pnMain.Controls.Clear();
                h.pnMain.Controls.Add(listenMusic);
                h.SetCurrentListenMusic(listenMusic);
            }
        }

        private void lblNameSinger_Click(object sender, EventArgs e)
        {
            if (type == "song" && h != null) // Chỉ thực hiện khi h không null (không phải trong RoomForm)
            {
                ArtistInfor artistInfor = new ArtistInfor(h, id_singer, idUser);
                h.pnMain.Controls.Clear();
                h.pnMain.Controls.Add(artistInfor);
            }
        }

        private void showSongsFavourite()
        {
            if (type != "song") return;
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
            if (type != "song") return;
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

        private void SongSearch_Load(object sender, EventArgs e)
        {
            if (type == "song")
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
            else if (type == "artist")
            {
                lblNameSong.Text = name_singer;
                lblNameSinger.Text = "Artist";
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
}