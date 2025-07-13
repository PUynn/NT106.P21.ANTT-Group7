using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class ChatRoom : UserControl
    {
        private readonly string serverIp = IPAddressServer.serverIP;
        private readonly string idUser;
        private readonly string targetId;
        private TcpClient client;
        private NetworkStream stream;
        private BinaryReader reader;
        private BinaryWriter writer;
        private Thread receiveThread;
        private bool isConnected = false;
        private bool isConnecting = false;
        private int retryCount = 0;
        private const int MaxRetries = 3;

        public ChatRoom(string idUser, string targetId)
        {
            InitializeComponent();
            this.idUser = idUser;
            this.targetId = targetId;

            this.Load += ChatRoom_Load;
            this.Leave += ChatRoom_Leave;

            // Initialize ListView columns
            lvMessages.Columns.Add("Messages", -2);
        }

        private async void ChatRoom_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(serverIp))
            {
                InfoMessage("Lỗi: Địa chỉ IP server không hợp lệ.");
                return;
            }

            await Task.Delay(100); // Allow UI to initialize
            if (lvMessages.IsDisposed)
            {
                InfoMessage("Lỗi: lvMessages không sẵn sàng.");
                return;
            }

            if (!isConnected && !isConnecting)
            {
                InfoMessage($"Chào mừng {idUser} đến với phòng chat với {targetId}!");
                await ConnectToServerWithRetryAsync();
            }
        }

        private async Task ConnectToServerWithRetryAsync()
        {
            while (retryCount < MaxRetries && !isConnected && !isConnecting)
            {
                isConnecting = true;
                try
                {
                    Console.WriteLine($"[DEBUG] Attempting to connect to {serverIp}:5000 at {DateTime.Now} (Attempt {retryCount + 1}/{MaxRetries})");
                    client = new TcpClient();
                    var connectTask = client.ConnectAsync(serverIp, 5000);
                    if (await Task.WhenAny(connectTask, Task.Delay(10000)) != connectTask)
                    {
                        Console.WriteLine($"[DEBUG] Connection timeout to {serverIp}:5000 at {DateTime.Now}");
                        InfoMessage("⏳ Đang thử kết nối lại...");
                        retryCount++;
                        continue;
                    }
                    await connectTask;
                    Console.WriteLine($"[DEBUG] Connected to {serverIp}:5000 at {DateTime.Now}");

                    stream = client.GetStream();
                    reader = new BinaryReader(stream);
                    writer = new BinaryWriter(stream);
                    Console.WriteLine($"[DEBUG] Stream opened at {DateTime.Now}");

                    // Match the working code's protocol
                    writer.Write("chatRoom");
                    writer.Write(idUser);
                    Console.WriteLine($"[DEBUG] Sent chatRoom request with idUser={idUser} at {DateTime.Now}");

                    isConnected = true;
                    isConnecting = false;
                    retryCount = 0;

                    receiveThread = new Thread(ReceiveMessages);
                    receiveThread.IsBackground = true;
                    receiveThread.Start();
                    Console.WriteLine($"[DEBUG] Started receiveThread at {DateTime.Now}");
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DEBUG] Connection error: {ex.Message} - StackTrace: {ex.StackTrace} at {DateTime.Now}");
                    InfoMessage("⏳ Đang thử kết nối lại...");
                    retryCount++;
                    isConnected = false;
                    isConnecting = false;
                    CleanupConnection();
                    await Task.Delay(2000); // Wait longer before retrying
                }
            }

            if (retryCount >= MaxRetries)
            {
                InfoMessage("❌ Không thể kết nối đến server sau nhiều lần thử.");
            }
        }

        private void ReceiveMessages()
        {
            try
            {
                Console.WriteLine($"[DEBUG] Starting ReceiveMessages at {DateTime.Now}");
                while (isConnected && client?.Connected == true && stream != null)
                {
                    if (!stream.CanRead)
                    {
                        Console.WriteLine($"[DEBUG] Stream cannot read at {DateTime.Now}");
                        throw new IOException("Dòng dữ liệu không thể đọc được.");
                    }

                    string messageType = reader.ReadString();
                    Console.WriteLine($"[DEBUG] Received messageType={messageType} at {DateTime.Now}");

                    if (messageType == "ClientList")
                    {
                        int clientCount = reader.ReadInt32();
                        Console.WriteLine($"[DEBUG] Received clientCount={clientCount} at {DateTime.Now}");
                        for (int i = 0; i < clientCount; i++)
                        {
                            string clientInfo = reader.ReadString();
                            InfoMessage(clientInfo);
                        }
                    }
                    else if (messageType == "Message")
                    {
                        string message = reader.ReadString();
                        Console.WriteLine($"[DEBUG] Received message={message} at {DateTime.Now}");
                        if (!string.IsNullOrEmpty(message))
                        {
                            // Format message to show sender
                            string prefix = message.StartsWith(idUser) ? "Bạn: " : $"{targetId}: ";
                            InfoMessage(prefix + message);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"[DEBUG] Unknown messageType={messageType} at {DateTime.Now}");
                        InfoMessage($"Loại tin nhắn không xác định: {messageType}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"[DEBUG] IOException in ReceiveMessages: {ex.Message} at {DateTime.Now}");
                if (isConnected)
                {
                    InfoMessage("⚠️ Mất kết nối tạm thời, đang thử kết nối lại...");
                    isConnected = false;
                    Task.Run(() => ConnectToServerWithRetryAsync());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DEBUG] Error in ReceiveMessages: {ex.Message} - StackTrace: {ex.StackTrace} at {DateTime.Now}");
                if (isConnected)
                {
                    InfoMessage("⚠️ Lỗi không xác định, đang thử kết nối lại...");
                    isConnected = false;
                    Task.Run(() => ConnectToServerWithRetryAsync());
                }
            }
            finally
            {
                Console.WriteLine($"[DEBUG] ReceiveMessages thread exiting at {DateTime.Now}");
                CleanupConnection();
            }
        }

        private void CleanupConnection()
        {
            try
            {
                stream?.Close();
                reader?.Dispose();
                writer?.Dispose();
                client?.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DEBUG] Error in CleanupConnection: {ex.Message} at {DateTime.Now}");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                InfoMessage("❗ Bạn chưa kết nối đến server, đang thử kết nối lại...");
                Task.Run(() => ConnectToServerWithRetryAsync());
                return;
            }

            string text = tbMessage.Text.Trim();
            if (string.IsNullOrEmpty(text)) return;

            try
            {
                writer.Write(text); // Match the working code's protocol
                Console.WriteLine($"[DEBUG] Sent message: {text} at {DateTime.Now}");
                tbMessage.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DEBUG] Error sending message: {ex.Message} at {DateTime.Now}");
                InfoMessage("⚠️ Lỗi gửi, đang thử kết nối lại...");
                isConnected = false;
                Task.Run(() => ConnectToServerWithRetryAsync());
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
            Console.WriteLine($"[DEBUG] ChatRoom_Leave triggered for idUser={idUser}, targetId={targetId} at {DateTime.Now}");
            try
            {
                if (isConnected && client?.Connected == true)
                {
                    writer.Write("disconnect");
                    Console.WriteLine($"[DEBUG] Sent disconnect signal at {DateTime.Now}");
                }
                isConnected = false;

                if (receiveThread != null && receiveThread.IsAlive)
                {
                    receiveThread.Join(1000);
                    receiveThread = null;
                    Console.WriteLine($"[DEBUG] receiveThread joined at {DateTime.Now}");
                }

                CleanupConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DEBUG] Error in ChatRoom_Leave: {ex.Message} at {DateTime.Now}");
                InfoMessage("⚠️ Lỗi ngắt kết nối: " + ex.Message);
            }
        }

        private void InfoMessage(string message)
        {
            if (lvMessages.IsDisposed || this.IsDisposed) return;

            if (lvMessages.InvokeRequired)
            {
                try
                {
                    lvMessages.Invoke(new Action<string>(InfoMessage), message);
                }
                catch (ObjectDisposedException)
                {
                    Console.WriteLine($"[DEBUG] InfoMessage failed: Control disposed at {DateTime.Now}");
                }
            }
            else
            {
                lvMessages.Items.Add(message);
                lvMessages.EnsureVisible(lvMessages.Items.Count - 1);
            }
        }
    }
}