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
        private string currentUserId; 
        private string currentUserName; 

        public MusicRoom()
        {
            InitializeComponent();
        }

        private void MusicRoom_Load(object sender, EventArgs e)
        {

        }

        private void lbMusicRoom_Click(object sender, EventArgs e)
        {

        }

        private void txtJoinRoom_TextChanged(object sender, EventArgs e)
        {
            string roomId = txtJoinRoom.Text.Trim();
            using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
            using (NetworkStream stream = client.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                writer.Write("joinRoom");
                writer.Write(roomId);
                writer.Write(currentUserId);
                writer.Write(currentUserName);
                string response = reader.ReadString();
                if (response == "OK")
                {
                    string role = reader.ReadString(); // "host" hoặc "client"
                    var roomForm = new RoomForm(roomId, currentUserId, role, currentUserName);
                    roomForm.Show();
                }
                else
                {
                    string error = reader.ReadString();
                    MessageBox.Show("Join thất bại: " + error);
                }
            }

        }

        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
            using (NetworkStream stream = client.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                writer.Write("createRoom");
                writer.Write(currentUserId);
                writer.Write(currentUserName);
                string response = reader.ReadString();
                if (response == "OK")
                {
                    string roomId = reader.ReadString();
                    // Mở RoomForm với quyền host
                    var roomForm = new RoomForm(roomId, currentUserId, "host", currentUserName);
                    roomForm.Show();
                }
                else
                {
                    MessageBox.Show("Tạo phòng thất bại!");
                }
            }
        }
    }
}
