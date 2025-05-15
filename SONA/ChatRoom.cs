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
        private BinaryReader reader;
        private BinaryWriter writer;
        private Thread receiveThread;
        private bool isConnected = false;
        string serverIp = IPAddressServer.serverIP;
        DataRow dr;

        public ChatRoom(DataRow userData)
        {
            InitializeComponent();
            lvMessages.Columns.Add("Messages", -2);
            dr = userData;
        }

        private void AddMessageToListView(string message)
        {
            this.Invoke(new Action(() =>
            {
                ListViewItem item = new ListViewItem(message);
                lvMessages.Items.Add(item);
                lvMessages.EnsureVisible(lvMessages.Items.Count - 1);
            }));
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
                        AddMessageToListView("Current clients in chat:");
                        for (int i = 0; i < clientCount; i++)
                        {
                            string clientInfo = reader.ReadString();
                            AddMessageToListView(clientInfo);
                        }
                    }
                    else if (messageType == "Message")
                    {
                        string message = reader.ReadString();
                        AddMessageToListView(message);
                    }
                    else
                    {
                        AddMessageToListView($"Loại tin nhắn không xác định: {messageType}");
                    }
                }
            }
            catch (Exception ex)
            {
                if (isConnected)
                {
                    AddMessageToListView("Disconnected from server: " + ex.Message);
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

                string username = dr != null && dr.Table.Columns.Contains("NAME_USER") ? dr["NAME_USER"].ToString() : "Anonymous";
                writer.Write("chat");
                writer.Write(username);

                isConnected = true;
                AddMessageToListView($"Kết nối tới Server {serverIp}:5000");

                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                AddMessageToListView("Lỗi kết nối tới Server: " + ex.Message);
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
                AddMessageToListView("Không thể gửi tin nhắn: Bạn chưa kết nối tới server.");
                return;
            }
            if (string.IsNullOrEmpty(tbMessage.Text))
            {
                AddMessageToListView("Vui lòng nhập tin nhắn trước khi gửi.");
                return;
            }
            try
            {
                writer.Write(tbMessage.Text);
                tbMessage.Clear();
            }
            catch (Exception ex)
            {
                AddMessageToListView("Lỗi gửi tin nhắn: " + ex.Message);
            }
        }

        private void ChatRoom_Load(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                if (string.IsNullOrEmpty(serverIp))
                {
                    AddMessageToListView("Lỗi: Địa chỉ IP của server không hợp lệ.");
                    return;
                }
                if (dr != null && dr.Table.Columns.Contains("NAME_USER"))
                {
                    AddMessageToListView($"Chào mừng {dr["NAME_USER"]} đến với phòng chat!");
                }
                ConnectToServer();
            }
        }

        private void ChatRoom_Leave(object sender, EventArgs e)
        {
            if (isConnected)
            {
                try
                {
                    writer?.Write(""); // Thông báo cho server rằng client rời nhóm
                }
                catch { }
            }
            isConnected = false;
            if (receiveThread != null && receiveThread.IsAlive)
            {
                receiveThread.Join(1000);
                receiveThread = null;
            }
            stream?.Close();
            reader?.Close();
            writer?.Close();
            client?.Close();
        }
    }
}