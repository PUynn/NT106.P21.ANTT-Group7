using System;
using System.Windows.Forms;

namespace SONA
{
    public partial class RoomForm : UserControl
    {
        private string roomId;
        private string userId;
        private string role; // "host" hoặc "client"
        private string userName;
        private ListenMusic listenMusicControl;
        private ChatRoom chatRoomControl;

        public RoomForm(string roomId, string userId, string role, string userName)
        {
            InitializeComponent();
            this.roomId = roomId;
            this.userId = userId;
            this.role = role;
            this.userName = userName;

            // TODO: Lấy id_song đầu tiên và danh sách bài hát của phòng nếu cần
            string id_song = "";
            var songIds = new System.Collections.Generic.List<string>();

            listenMusicControl = new ListenMusic(null, id_song, userId, songIds);
            chatRoomControl = new ChatRoom();

            listenMusicControl.Dock = DockStyle.Top;
            chatRoomControl.Dock = DockStyle.Fill;
            this.Controls.Add(listenMusicControl);
            this.Controls.Add(chatRoomControl);

            listenMusicControl.SetHostMode(role == "host");
        }
    }
}
