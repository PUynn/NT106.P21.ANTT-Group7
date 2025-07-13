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
        private string emailUser, name_user, idUser;
        private ChatRoom currentChatRoom;

        public ChatForm(string emailUser)
        {
            InitializeComponent();
            this.emailUser = emailUser;
            this.Load += ChatForm_Load;
            Console.WriteLine($"ChatForm initialized with email={emailUser}");
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            if (!FetchUserInfo())
            {
                MessageBox.Show("Không thể tải thông tin người dùng.");
                return;
            }

            LoadChatList();
        }

        private bool FetchUserInfo()
        {
            try
            {
                using (var client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (var stream = client.GetStream())
                using (var writer = new BinaryWriter(stream))
                using (var reader = new BinaryReader(stream))
                {
                    writer.Write("chatForm");
                    writer.Write(emailUser);
                    Console.WriteLine($"Sending chatForm request with email: {emailUser}");

                    string response = reader.ReadString();
                    Console.WriteLine($"Server response: {response}");
                    if (response == "OK")
                    {
                        name_user = reader.ReadString();
                        idUser = reader.ReadString();
                        Console.WriteLine($"Fetched user: email={emailUser}, name={name_user}, id={idUser}");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"Server trả về lỗi: {response}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in FetchUserInfo: {ex.GetType()} - {ex.Message}");
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
                return false;
            }
        }

        private void LoadChatList()
        {
            if (string.IsNullOrEmpty(idUser))
            {
                MessageBox.Show("idUser không được thiết lập. Vui lòng kiểm tra lại.");
                return;
            }
            Console.WriteLine($"Loading chat list with idUser: {idUser}");
            Chat_List chatListControl = new Chat_List(idUser);
            chatListControl.Dock = DockStyle.Fill;
            chatListControl.OnUserSelected += LoadChatRoom;

            pnListChat.Controls.Clear();
            pnListChat.Controls.Add(chatListControl);
        }

        private void LoadChatRoom(string targetId)
        {
            if (currentChatRoom != null)
            {
                currentChatRoom.Dispose();
            }

            currentChatRoom = new ChatRoom(idUser, targetId);
            currentChatRoom.Dock = DockStyle.Fill;

            pnChatRoom.Controls.Clear();
            pnChatRoom.Controls.Add(currentChatRoom);
        }
    }
}