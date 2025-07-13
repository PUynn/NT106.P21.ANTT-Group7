using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace SONA
{
    public partial class ChatForm : UserControl
    {
        private string emailUser, name_user;
        public ChatForm(string email)
        {
            InitializeComponent();
            emailUser = email;
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("chatForm");
                    writer.Write(emailUser);

                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        name_user = reader.ReadString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối tới Server: " + ex.Message);
            }
            ChatRoom chatRoom = new ChatRoom(name_user);
            pnChatRoom.Controls.Clear();
            pnChatRoom.Controls.Add(chatRoom);
        }
    }
}