using SONA;
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
    public partial class PlaylistList : UserControl
    {
        private Home h;
        private string picturePath = null;
        private bool hasCustomPicture = false;
        private Dictionary<string, PlaylistForm> playlistForms = new Dictionary<string, PlaylistForm>();

        public PlaylistList(Home h)
        {
            this.h = h;
            InitializeComponent();
            getPlaylist();
        }

        private void getPlaylist()
        {
            try
            {
                Title title = new Title("Your playlist:");
                flpPlaylist.Controls.Clear();
                flpPlaylist.Controls.Add(title);

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
                        for (int i = 0; i < playlistCount; i++)
                        {
                            string id_playlist = reader.ReadString();
                            PlaylistForm playlistForm = new PlaylistForm(h, id_playlist);
                            // Đăng ký sự kiện xóa
                            playlistForm.PlaylistRemoved += PlaylistForm_PlaylistRemoved;
                            flpPlaylist.Controls.Add(playlistForm);
                            playlistForms[id_playlist] = playlistForm; // Lưu tham chiếu để dễ xóa sau
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

        // Xử lý sự kiện khi playlist được xóa
        private void PlaylistForm_PlaylistRemoved(object sender, string idPlaylist)
        {
            if (playlistForms.ContainsKey(idPlaylist))
            {
                PlaylistForm removedForm = playlistForms[idPlaylist];
                flpPlaylist.Controls.Remove(removedForm);
                playlistForms.Remove(idPlaylist);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnAddPlaylist.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pnAddPlaylist.Visible = true;
        }

        private void cpbPicturePlaylist_Click(object sender, EventArgs e)
        {
            setPicturePlaylist();
        }

        private void btnOk_Click(object sender, EventArgs e)
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
                        pnAddPlaylist.Visible = false;
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
    }
}