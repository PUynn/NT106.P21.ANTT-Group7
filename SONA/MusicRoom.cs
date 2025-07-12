using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace SONA
{
    public partial class MusicRoom : UserControl
    {
        private string UserId; 
        private string UserName; 

       public MusicRoom(string userId, string userName)
        {
            InitializeComponent();
            this.UserId = userId;
            this.UserName = userName;
            buttonCreate.Click += btnCreateRoom_Click;
            buttonJoin.Click += btnJoinRoom_Click;
        }
        private void MusicRoom_Load(object sender, EventArgs e)
        {

        }

        
        private void txtJoinRoom_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("IP đang dùng để kết nối: " + IPAddressServer.serverIP);
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("createRoom");
                    writer.Write(UserId);
                    writer.Write(UserName);
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        string roomId = reader.ReadString();
                        // Mở RoomForm với quyền host
                        var roomForm = new RoomForm(roomId,UserId, "host",UserName);
                        var parentPanel = this.Parent as Panel;
                        if (parentPanel != null)
                        {
                            parentPanel.Controls.Clear();
                            roomForm.Dock = DockStyle.Fill;
                            parentPanel.Controls.Add(roomForm);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tạo phòng thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối tới server: " + ex.Message);
            }
        }

        private void btnJoinRoom_Click(object sender, EventArgs e)
        {
            string roomId = txtJoinRoom.Text.Trim();
            using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
            using (NetworkStream stream = client.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                writer.Write("joinRoom");
                writer.Write(roomId);
                writer.Write(UserId);
                writer.Write(UserName);
                string response = reader.ReadString();
                if (response == "OK")
                {
                    string role = reader.ReadString(); // "host" hoặc "client"
                    var roomForm = new RoomForm(roomId,UserId, role,UserName);
                    var parentPanel = this.Parent as Panel;
                    if (parentPanel != null)
                    {
                        parentPanel.Controls.Clear();
                        roomForm.Dock = DockStyle.Fill;
                        parentPanel.Controls.Add(roomForm);
                    }
                }
                else
                {
                    string error = reader.ReadString();
                    MessageBox.Show("Join thất bại: " + error);
                }
            }

        }

    }
}
