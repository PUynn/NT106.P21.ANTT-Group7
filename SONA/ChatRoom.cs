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
        private string serverIp = IPAddressServer.serverIP;
        private string idUser;
        private string targetId;

        private TcpClient client;
        private NetworkStream stream;
        private BinaryReader reader;
        private BinaryWriter writer;
        private Thread receiveThread;
        private bool isConnected = false;

        public ChatRoom(string idUser, string targetId)
        {
            InitializeComponent();
            this.idUser = idUser;
            this.targetId = targetId;

            this.Load += ChatRoom_Load;
            this.Leave += ChatRoom_Leave;
        }

        private void ChatRoom_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(serverIp))
            {
                InfoMessage("Lỗi: Địa chỉ IP server không hợp lệ.");
                return;
            }

            InfoMessage("Đang kết nối đến server...");
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient(serverIp, 5000);
                stream = client.GetStream();
                reader = new BinaryReader(stream);
                writer = new BinaryWriter(stream);

                writer.Write("getMessages");
                writer.Write(idUser);
                writer.Write(targetId);

                isConnected = true;

                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                InfoMessage("❌ Không kết nối được server: " + ex.Message);
            }
        }

        private void ReceiveMessages()
        {
            try
            {
                int historyCount = reader.ReadInt32();
                for (int i = 0; i < historyCount; i++)
                {
                    string senderId = reader.ReadString();
                    string content = reader.ReadString();

                    string prefix = senderId == idUser ? "Bạn: " : $"{targetId}: ";
                    InfoMessage(prefix + content);
                }

                string readySignal = reader.ReadString();
                if (readySignal != "ready")
                {
                    InfoMessage("❌ Server không gửi tín hiệu 'ready'.");
                    return;
                }

                while (isConnected)
                {
                    string messageType = reader.ReadString();
                    if (messageType == "newMessage")
                    {
                        string senderId = reader.ReadString();
                        string content = reader.ReadString();
                        string prefix = senderId == idUser ? "Bạn: " : $"{targetId}: ";
                        InfoMessage(prefix + content);
                    }
                }
            }
            catch (IOException)
            {
                InfoMessage("💥 Mất kết nối đến server.");
            }
            catch (Exception ex)
            {
                InfoMessage("💥 Lỗi nhận tin nhắn: " + ex.Message);
            }
            finally
            {
                isConnected = false;
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
                InfoMessage("❗ Bạn chưa kết nối đến server.");
                return;
            }

            string text = tbMessage.Text.Trim();
            if (string.IsNullOrEmpty(text)) return;

            try
            {
                writer.Write("sendMessage");
                writer.Write(idUser);
                writer.Write(targetId);
                writer.Write(text);

                tbMessage.Clear();
            }
            catch (Exception ex)
            {
                InfoMessage("⚠️ Lỗi gửi: " + ex.Message);
                isConnected = false;
            }
        }

        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                btnSend_Click(sender, e);
            }
        }

        private void ChatRoom_Leave(object sender, EventArgs e)
        {
            try
            {
                isConnected = false;
                if (writer != null && client?.Connected == true)
                {
                    writer.Write("disconnect");
                }

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
                InfoMessage("⚠️ Lỗi ngắt kết nối: " + ex.Message);
            }
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
    }
}