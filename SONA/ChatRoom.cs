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
using System.Threading;
using static Guna.UI2.Native.WinApi;
using Npgsql;

namespace SONA
{
    public partial class ChatRoom : UserControl
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;

        private BinaryReader reader;
        private BinaryWriter writer;

        private bool isConnected = false;
        private string serverIp = IPAddressServer.serverIP;
        private string nameUser;

        public ChatRoom(string name)
        {
            InitializeComponent();
            lvMessages.Columns.Add("Messages", -2);
            nameUser = name;
        }

        private void InfoMessage(string message)
        {
            if (lvMessages.InvokeRequired)
            {
                lvMessages.Invoke(new Action<string>(InfoMessage), message);
            }
            else
            {
                lvMessages.Items.Add(message);
                lvMessages.EnsureVisible(lvMessages.Items.Count - 1);
            }
        }

        private void ReceiveMessages()
        {
            try
            {
                while (isConnected)
                {
                    string messageType = reader.ReadString();
                    if (messageType == "ClientList")
                    {
                        int clientCount = reader.ReadInt32();
                        for (int i = 0; i < clientCount; i++)
                        {
                            string clientInfo = reader.ReadString();
                            InfoMessage(clientInfo);
                        }
                    }
                    else if (messageType == "Message")
                    {
                        string message = reader.ReadString();
                        if (!string.IsNullOrEmpty(message))
                            InfoMessage(message);
                    }
                    else
                    {
                        InfoMessage($"Loại tin nhắn không xác định: {messageType}");
                    }
                }
            }
            catch (Exception ex)
            {
                if (isConnected)
                {
                    InfoMessage("Disconnected from server: " + ex.Message);
                    isConnected = false;
                }
            }
            finally
            {
                stream?.Close();
                reader?.Close();
                writer?.Close();
                client?.Close();
            }
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient(serverIp, 5000);
                stream = client.GetStream();

                reader = new BinaryReader(stream);
                writer = new BinaryWriter(stream);

                writer.Write("chatRoom");
                writer.Write(nameUser);

                isConnected = true;

                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                InfoMessage("Lỗi kết nối tới Server: " + ex.Message);
                stream?.Close();
                reader?.Close();
                writer?.Close();
                client?.Close();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                InfoMessage("Không thể gửi tin nhắn: Bạn chưa kết nối tới server.");
                return;
            }
            if (string.IsNullOrEmpty(tbMessage.Text))
            {
                InfoMessage("Vui lòng nhập tin nhắn trước khi gửi.");
                return;
            }
            try
            {
                writer.Write(tbMessage.Text);
                tbMessage.Clear();
            }
            catch (Exception ex)
            {
                InfoMessage("Lỗi gửi tin nhắn: " + ex.Message);
            }
        }

        private void ChatRoom_Load(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                if (string.IsNullOrEmpty(serverIp))
                {
                    InfoMessage("Lỗi: Địa chỉ IP của server không hợp lệ.");
                    return;
                }
                InfoMessage($"Chào mừng {nameUser} đến với phòng chat!");
                ConnectToServer();
            }
        }

        private void ChatRoom_Leave(object sender, EventArgs e)
        {
            try
            {
                isConnected = false;
                if (client != null && client.Connected) writer.Write("disconnect");

                if (receiveThread != null && receiveThread.IsAlive)
                {
                    receiveThread.Join();
                    receiveThread = null;
                }

                stream?.Close();
                reader?.Close();
                writer?.Close();
                client?.Close();
            }
            catch (Exception ex)
            {
                InfoMessage("Lỗi đóng kết nối: " + ex.Message);
            }
        }

        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, e);
            }
        }
    }
}