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
using System.Threading;
using System.IO;

namespace SONA
{
    public partial class ChatBox : UserControl
    {
        private string roomId;
        private string userId;
        private string userName;
        private TcpClient client;
        private NetworkStream stream;
        private BinaryReader reader;
        private BinaryWriter writer;
        private Thread receiveThread;
        private bool isConnected = false;

        public ChatBox(string roomId, string userId, string userName)
        {
            InitializeComponent();
            this.roomId = roomId;
            this.userId = userId;
            this.userName = userName;
            this.Disposed += ChatBox_Disposed;
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient(IPAddressServer.serverIP, 5000);
                stream = client.GetStream();
                reader = new BinaryReader(stream);
                writer = new BinaryWriter(stream);

                // Gửi yêu cầu join chat room
                writer.Write("roomChat");
                writer.Write(roomId);
                writer.Write(userId);
                writer.Write(userName);

                isConnected = true;
                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                AddMessage("Lỗi kết nối: " + ex.Message);
            }
        }

        private void ReceiveMessages()
        {
            try
            {
                while (isConnected)
                {
                    string type = reader.ReadString();
                    if (type == "message")
                    {
                        string msg = reader.ReadString();
                        AddMessage(msg);
                    }
                    // mở rộng thêm các loại message khác (thông báo vào/ra phòng, ...)                 }
                }
            }
            catch (Exception ex)
            {
                AddMessage("Mất kết nối: " + ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!isConnected || string.IsNullOrWhiteSpace(tbEnterChat.Text)) return;
            try
            {
                writer.Write("roomMessage");
                writer.Write(roomId);
                writer.Write(userId);
                writer.Write(userName);
                writer.Write(tbEnterChat.Text.Trim());
                tbEnterChat.Clear();
            }
            catch (Exception ex)
            {
                AddMessage("Lỗi gửi: " + ex.Message);
            }
        }

        private void AddMessage(string msg, bool isMine = false)
        {
            if (pnLayout.InvokeRequired)
            {
                pnLayout.Invoke(new Action<string, bool>(AddMessage), msg, isMine);
            }
            else
            {
                // Tạo label cho tin nhắn
                var lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
                lbl.Text = msg;
                lbl.AutoSize = true;
                lbl.BackColor = isMine ? System.Drawing.Color.LightBlue : System.Drawing.Color.LightGray;
                lbl.Margin = new Padding(5);
                lbl.Padding = new Padding(8);
                lbl.MaximumSize = new System.Drawing.Size(pnLayout.Width - 30, 0);
                lbl.Anchor = isMine ? AnchorStyles.Right : AnchorStyles.Left;
                // Có thể căn phải/trái bằng cách set lbl.Left hoặc dùng FlowLayoutPanel với FlowDirection
                pnLayout.Controls.Add(lbl);
                pnLayout.ScrollControlIntoView(lbl); // Tự động cuộn xuống cuối
            }
        }

        private void ChatBox_Disposed(object sender, EventArgs e)
        {
            try
            {
                isConnected = false;
                receiveThread?.Abort();
                writer?.Close();
                reader?.Close();
                stream?.Close();
                client?.Close();
            }
            catch { }
        }
    }
}