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
    public partial class SongPlaylist : UserControl
    {
        private Home h;

        public List<string> songIds;
        private string idPlaylist;
        private string id_song, name_song, picture_song, id_singer, name_singer;

        public event EventHandler<string> SongRemoved;

        public SongPlaylist(Home h, string id_song, string idPlaylist, List<string> songIds)
        {
            this.h = h;
            this.idPlaylist = idPlaylist;
            this.id_song = id_song;
            this.songIds = new List<string>(songIds);

            InitializeComponent();
            getData();
            showSongsFavourite();
        }

        private void getData()
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

        // Hàm gọi form ListenMusic để phát nhạc
        private void btnPictureSong_Click(object sender, EventArgs e)
        {
            h.listenMusic(id_song, songIds);
        }

        private void lblNameSinger_Click(object sender, EventArgs e)
        {
            ArtistInfor artistInfor = new ArtistInfor(h, id_singer);
            h.pnMain.Controls.Clear();
            h.pnMain.Controls.Add(artistInfor);
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

        private void btnFavorited_Click(object sender, EventArgs e)
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("deleteSongFromPlaylist");
                    writer.Write(idPlaylist);
                    writer.Write(id_song);

                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        SongRemoved?.Invoke(this, id_song);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi xóa bài hát khỏi playlist: " + response);
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