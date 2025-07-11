using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;

namespace SONA
{
    public partial class RoomForm : UserControl
    {
        private string roomId;
        private string userId;
        private string role; // "host" hoặc "client"
        private string userName;
        private TcpClient client;
        private NetworkStream stream;
        private ListenMusic listenMusicControl;
        private ChatBox chatBoxControl;
        private Thread listenThread;
        private bool isClosing = false;

        public RoomForm(string roomId, string userId, string role, string userName)
        {
            InitializeComponent();
            this.roomId = roomId;
            this.userId = userId;
            this.role = role;
            this.userName = userName;

            // Kết nối TCP riêng cho phòng
            client = new TcpClient(IPAddressServer.serverIP, 5000);
            stream = client.GetStream();

            // TODO: Lấy id_song đầu tiên và danh sách bài hát của phòng từ server nếu cần
            string id_song = "1"; // Tạm thời hardcode, bạn có thể lấy từ server
            var songIds = new System.Collections.Generic.List<string> { "1", "2", "3" }; // Tạm thời hardcode

            // Tạo ListenMusic và ChatBox, truyền stream, roomId, role
            listenMusicControl = new ListenMusic(null, id_song, userId, songIds, stream, roomId, role == "host");
            chatBoxControl = new ChatBox(roomId, userId, userName);

            listenMusicControl.Dock = DockStyle.Top;
            chatBoxControl.Dock = DockStyle.Fill;
            this.Controls.Add(chatBoxControl);
            this.Controls.Add(listenMusicControl);

            listenMusicControl.SetHostMode(role == "host");

            // Thread lắng nghe tín hiệu đồng bộ nhạc từ server
            listenThread = new Thread(ListenRoom);
            listenThread.IsBackground = true;
            listenThread.Start();

            this.Disposed += RoomForm_Disposed;
        }

        private void ListenRoom()
        {
            try
            {
                using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
                {
                    while (!isClosing)
                    {
                        string type = reader.ReadString();
                        if (type == "musicSync")
                        {
                            string syncRoomId = reader.ReadString();
                            string action = reader.ReadString(); // "play", "pause", "next", ...
                            string syncSongId = reader.ReadString();
                            double position = reader.ReadDouble();
                            if (syncRoomId == roomId)
                            {
                                this.Invoke((MethodInvoker)(() => listenMusicControl.SyncPlayback(action, position)));
                            }
                        }
                        // Có thể mở rộng thêm các loại tín hiệu khác (chat, member join/leave, ...)
                    }
                }
            }
            catch { }
        }

        private void RoomForm_Disposed(object sender, EventArgs e)
        {
            try
            {
                isClosing = true;
                // Gửi tín hiệu rời phòng cho server nếu muốn
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
                {
                    writer.Write("leaveRoom");
                    writer.Write(roomId);
                    writer.Write(userId);
                }
                listenThread?.Abort();
                stream?.Close();
                client?.Close();
            }
            catch { }
        }
    }
}
