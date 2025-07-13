using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Util.Store;
using System.Net.Mail;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Supabase;
using Supabase.Storage;
using System.Runtime.Remoting.Lifetime;
using Supabase.Gotrue;
using System.Xml.Linq;

namespace SONA_Server
{
    public partial class ServerForm : Form
    {
        // Chuỗi kết nối tới cơ sở dữ liệu PostgreSQL trên Supabase
        string connIP = "Host=aws-0-ap-southeast-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.ebrkvdctytawbdqmtrsk;Password=laptrinhmang;SSL Mode=Require;Trust Server Certificate=true";
        string connSona = "Host=aws-0-ap-southeast-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.lgnvhovprubrxohnhwph;Password=laptrinhmang;SSL Mode=Require;Trust Server Certificate=true";
        //string connSona = "Host=aws-0-ap-southeast-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.ebrkvdctytawbdqmtrsk;Password=laptrinhmang;SSL Mode=Require;Trust Server Certificate=true";

        private TcpListener server; // Đối tượng TcpListener để lắng nghe kết nối từ client
        private List<ClientInfor> chatClients; // Lưu danh sách client trong nhóm chat
        private Thread clientListener; // Luồng lắng nghe kết nối từ client
        private object chatLock = new object(); // Khóa để đồng bộ hóa truy cập vào danh sách client
        bool isRunning = false; // Biến kiểm tra trạng thái server

        private Dictionary<string, (string otp, DateTime createdTime)> otpStore; // Lưu trữ mã OTP và thời gian tạo mã của người dùng tương ứng
        bool isForgetPassword = false;

        private string userEmail = "";
        private const int OTPResendCooldown = 60; // Giới hạn thời gian gửi là 60 giây
        private const int OTPExpirationMinutes = 5; // OTP hết hạn sau 5 phút

        public ServerForm()
        {
            InitializeComponent();
            chatClients = new List<ClientInfor>();
            otpStore = new Dictionary<string, (string otp, DateTime createdTime)>();

            lvManageMess.Columns.Add("Activity", -2);
            AddToListView($"Server khởi động với IP là {GetLocalIPAddress()}:5000"); // Thêm thông tin server khi khởi tạo
        }

        // Phương thức hiển thị thông tin lên giao diện List View
        private void AddToListView(string message)
        {
            if (lvManageMess.InvokeRequired)
            {
                lvManageMess.Invoke(new Action<string>(AddToListView), message);
            }
            else
            {
                lvManageMess.Items.Add(message);
                lvManageMess.EnsureVisible(lvManageMess.Items.Count - 1);
            }
        }

        // Phương thức lắng nghe kết nối từ client
        private void Listen()
        {
            try
            {
                while (isRunning)
                {
                    TcpClient client = server.AcceptTcpClient(); // Chấp nhận kết nối từ client trả về một TcpClient

                    //// Lấy địa chỉ IP của client và thêm vào ListView
                    //string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).ToString();
                    //AddToListView($"New client connected from: {clientIP}");

                    // Tạo một luồng mới để xử lý client qua phương thức HandleClient
                    Thread clientThread = new Thread(HandleClient);
                    clientThread.IsBackground = true;
                    clientThread.Start(client);
                }
            }
            catch (Exception ex) // Nếu lỗi xảy ra thì dừng server hiện tại và khởi động lại trên cổng 5000
            {
                if (isRunning)
                {
                    MessageBox.Show("Lỗi trong Listen: " + ex.Message);
                    if (server != null)
                    {
                        server.Stop();
                    }
                    server = new TcpListener(IPAddress.Any, 5000);
                    server.Start();
                }
            }
        }

        // Phương thức nhận và xử lý kết nối từ client
        private void HandleClient(object obj)
        {
            TcpClient client = obj as TcpClient; // Chuyển đổi đối tượng obj thành TcpClient

            // Khởi tạo luồng và đối tượng để đọc/ghi dữ liệu từ client
            NetworkStream stream = null;
            BinaryReader reader = null;
            BinaryWriter writer = null;

            // Lưu thông tin client
            string username = null;
            string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).ToString();
            ClientInfor clientInfor = null;
            Console.WriteLine($"[Server] Kết nối mới từ {clientIP} tại {DateTime.Now}");

            try
            {
                stream = client.GetStream(); // Lấy luồng mạng từ client
                Console.WriteLine($"[Server] Mở stream cho {clientIP} tại {DateTime.Now}");
                reader = new BinaryReader(stream); // Tạo đối tượng BinaryReader để đọc dữ liệu từ luồng
                writer = new BinaryWriter(stream); // Tạo đối tượng BinaryWriter để ghi dữ liệu vào luồng

                string requestType = reader.ReadString(); // Đọc loại yêu cầu từ client (login, signup, chat)
                Console.WriteLine($"[Server] Nhận requestType={requestType} từ {clientIP} tại {DateTime.Now}");

                #region Login
                if (requestType == "loginUser")
                {
                    // Đọc thông tin username và password nhập từ client
                    string name = reader.ReadString();
                    string password = reader.ReadString();

                    string loginSuccess = CheckUserLogin(name, password); // Gọi phương thức CheckUserLogin để kiểm tra thông tin đăng nhập
                    writer.Write(loginSuccess); // Ghi kết quả đăng nhập về client
                }
                else if (requestType == "loginGoogle")
                {
                    string email = reader.ReadString();
                    if (IsEmailExists(email)) writer.Write("OK");
                    else writer.Write("Tài khoản email chưa tồn tại! Vui lòng đăng kí tài khoản");
                }
                else if (requestType == "forgetPassword")
                {
                    isForgetPassword = true;
                    string type = reader.ReadString();
                    if (type == "email")
                    {
                        string email = reader.ReadString();
                        string result = Task.Run(async () =>
                        {
                            return await GetOTPfromEmail(email);
                        }).Result;
                        writer.Write(result);
                    }
                    else if (type == "refreshOTP")
                    {
                        string email = reader.ReadString();
                        string result = Task.Run(async () =>
                        {
                            return await RefreshOTP(email);
                        }).Result;
                        writer.Write(result);
                    }
                    else if (type == "setPassword")
                    {
                        string email = reader.ReadString();
                        string otp = reader.ReadString();
                        string newPassword = reader.ReadString();

                        string result = SetNewPassword(email, otp, newPassword);
                        writer.Write(result);
                    }
                    isForgetPassword = false;
                }
                #endregion

                #region SignUp
                else if (requestType == "signupUser")
                {
                    string type = reader.ReadString();
                    if (type == "email")
                    {
                        string email = reader.ReadString();
                        string result = Task.Run(async () =>
                        {
                            return await GetOTPfromEmail(email);
                        }).Result;
                        writer.Write(result);
                    }
                    else if (type == "otp")
                    {
                        string email = reader.ReadString();
                        string otp = reader.ReadString();
                        string result = CheckOTP(email, otp);

                        writer.Write(result);
                    }
                    else if (type == "refreshOTP")
                    {
                        string email = reader.ReadString();
                        string result = Task.Run(async () =>
                        {
                            return await RefreshOTP(email);
                        }).Result;
                        writer.Write(result);
                    }
                }
                else if (requestType == "signupGoogle")
                {
                    string email = reader.ReadString();
                    if (!IsEmailExists(email)) writer.Write("OK");
                    else writer.Write("Tài khoản email đã tồn tại! Vui lòng đăng nhập");
                }

                else if (requestType == "signupInfo")
                {
                    string name = reader.ReadString();
                    string password = reader.ReadString();
                    string phone = reader.ReadString();
                    string email = reader.ReadString();

                    string pictureUrl = "https://lgnvhovprubrxohnhwph.supabase.co/storage/v1/object/public/picture/Users/BaseAvatar.png";
                    string pathBucket = "picture/Users";
                    string hasAvatar = reader.ReadString();

                    if (hasAvatar == "hasAvatar")
                    {
                        int imageLength = reader.ReadInt32();
                        byte[] imageData = reader.ReadBytes(imageLength);
                        string result = Task.Run(async () =>
                        {
                            return await UploadImageToSupabase(email, imageData, pathBucket);
                        }).Result;
                        pictureUrl = result;
                    }

                    try
                    {
                        if (IsPhoneNumberExists(phone))
                        {
                            writer.Write("Số điện thoại đã tồn tại");
                            return;
                        }

                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "INSERT INTO users (name_user, email, phone_number, password, picture_user) VALUES (@name_user, @email, @phone_number, @password, @picture_user)";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@name_user", name);
                                cmd.Parameters.AddWithValue("@email", email);
                                cmd.Parameters.AddWithValue("@phone_number", phone);
                                cmd.Parameters.AddWithValue("@password", password);
                                cmd.Parameters.AddWithValue("@picture_user", pictureUrl);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        writer.Write("OK");
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi thông tin người dùng: " + ex.Message);
                    }
                }
                #endregion

                else if (requestType == "getIDSong")
                {
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT id_song FROM songs ORDER BY RANDOM()";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    List<string> songIds = new List<string>();

                                    while (readerdb.Read())
                                    {
                                        songIds.Add(readerdb["id_song"].ToString());
                                    }

                                    writer.Write("OK");
                                    writer.Write(songIds.Count);

                                    foreach (var id in songIds)
                                    {
                                        writer.Write(id);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy id bài hát: " + ex.Message);
                    }
                }
                else if (requestType == "getIDSinger")
                {
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT id_singer FROM singer ORDER BY RANDOM()";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    List<string> singerIds = new List<string>();
                                    while (readerdb.Read())
                                    {
                                        singerIds.Add(readerdb["id_singer"].ToString());
                                    }

                                    writer.Write("OK");
                                    writer.Write(singerIds.Count);

                                    foreach (var id in singerIds)
                                    {
                                        writer.Write(id);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy id nghệ sĩ: " + ex.Message);
                    }
                }
                else if (requestType == "getIDAlbum")
                {
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT id_album FROM albums ORDER BY RANDOM()";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    List<string> albumIds = new List<string>();
                                    while (readerdb.Read())
                                    {
                                        albumIds.Add(readerdb["id_album"].ToString());
                                    }
                                    writer.Write("OK");
                                    writer.Write(albumIds.Count);
                                    foreach (var id in albumIds)
                                    {
                                        writer.Write(id);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy id album: " + ex.Message);
                    }
                }    
                else if (requestType == "getIDUser")
                {
                    string email = reader.ReadString();
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT id_user FROM users WHERE email = @email";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@email", email);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    if (readerdb.Read())
                                    {
                                        string id = readerdb["id_user"].ToString();
                                        writer.Write("OK");
                                        writer.Write(id);
                                        Console.WriteLine($"[DEBUG] Fetched id_user from DB for email {email}: {id}");
                                    }
                                    else
                                    {
                                        writer.Write("ERROR: User not found");
                                        Console.WriteLine($"[DEBUG] User not found for email: {email}");
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("ERROR: " + ex.Message);
                        Console.WriteLine($"[DEBUG] Error in getIDUser for email {email}: {ex.Message} - StackTrace: {ex.StackTrace}");
                    }
                }
                else if (requestType == "getIDAlbum")
                {
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT id_album FROM albums ORDER BY RANDOM()";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    List<string> albumIds = new List<string>();
                                    while (readerdb.Read())
                                    {
                                        albumIds.Add(readerdb["id_album"].ToString());
                                    }

                                    writer.Write("OK");
                                    writer.Write(albumIds.Count);
                                    foreach (var id in albumIds)
                                    {
                                        writer.Write(id);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy id album: " + ex.Message);
                    }
                }
                else if (requestType == "albumForm")
                {
                    try
                    {
                        int id_album = int.Parse(reader.ReadString());
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT name_album, description, picture_album FROM albums WHERE id_album = @id_album";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_album", id_album);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    if (readerdb.Read())
                                    {
                                        writer.Write("OK");
                                        writer.Write(readerdb["name_album"].ToString());
                                        writer.Write(readerdb["description"].ToString());
                                        writer.Write(readerdb["picture_album"].ToString());
                                    }
                                    else
                                        writer.Write("Không tìm thấy album với ID: " + id_album);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy album: " + ex.Message);
                    }
                }
                else if (requestType == "getIdSongFromAlbum")
                {
                    try
                    {
                        int id_album = int.Parse(reader.ReadString());
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT id_song FROM album_songs WHERE id_album = @id_album";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_album", id_album);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    List<string> songIds = new List<string>();
                                    while (readerdb.Read())
                                    {
                                        songIds.Add(readerdb["id_song"].ToString());
                                    }

                                    writer.Write("OK");
                                    writer.Write(songIds.Count);
                                    foreach (var id in songIds)
                                    {
                                        writer.Write(id);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy id bài hát từ album: " + ex.Message);
                    }
                }
                else if (requestType == "getIDPlaylist")
                {
                    try
                    {
                        int id_user = int.Parse(reader.ReadString());
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT id_playlist FROM playlists where id_user = @id_user";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_user", id_user);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    List<string> playlistIds = new List<string>();
                                    while (readerdb.Read())
                                    {
                                        playlistIds.Add(readerdb["id_playlist"].ToString());
                                    }

                                    writer.Write("OK");
                                    writer.Write(playlistIds.Count);
                                    foreach (var id in playlistIds)
                                    {
                                        writer.Write(id);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy id playlist: " + ex.Message);
                    }
                }
                else if (requestType == "getPlaylistInfor")
                {
                    try
                    {
                        int id_playlist = int.Parse(reader.ReadString());
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT name_playlist, picture_playlist FROM playlists WHERE id_playlist = @id_playlist";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_playlist", id_playlist);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    if (readerdb.Read())
                                    {
                                        writer.Write("OK");
                                        writer.Write(readerdb["name_playlist"].ToString());
                                        writer.Write(readerdb["picture_playlist"].ToString());
                                    }
                                    else
                                        writer.Write("Không tìm thấy playlist với ID: " + id_playlist);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy thông tin playlist: " + ex.Message);
                    }
                }
                else if (requestType == "addPlaylist")
                {
                    int idUser = int.Parse(reader.ReadString());
                    string email = reader.ReadString();
                    string namePlaylist = reader.ReadString();
                    string hasAvatar = reader.ReadString();

                    string pictureUrl = "https://lgnvhovprubrxohnhwph.supabase.co/storage/v1/object/public/picture/Playlists/BasePlaylist.jpeg";
                    string pathBucket = "picture/Playlists";

                    if (hasAvatar == "hasAvatar")
                    {
                        int imageLength = reader.ReadInt32();
                        byte[] imageData = reader.ReadBytes(imageLength);
                        string result = Task.Run(async () =>
                        {
                            return await UploadImageToSupabase(email, imageData, pathBucket);
                        }).Result;
                        pictureUrl = result;
                    }

                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "INSERT INTO playlists (id_user, name_playlist, picture_playlist) VALUES (@id_user, @name_playlist, @picture_playlist)";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_user", idUser);
                                cmd.Parameters.AddWithValue("@name_playlist", namePlaylist);
                                cmd.Parameters.AddWithValue("@picture_playlist", pictureUrl);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        writer.Write("OK");
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi không thể tạo Playlist: " + ex.Message);
                    }
                }
                else if (requestType == "playlistForm")
                {
                    try
                    {
                        int id_playlist = int.Parse(reader.ReadString());
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT name_playlist, picture_playlist FROM playlists WHERE id_playlist = @id_playlist";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_playlist", id_playlist);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    if (readerdb.Read())
                                    {
                                        writer.Write("OK");
                                        writer.Write(readerdb["name_playlist"].ToString());
                                        writer.Write(readerdb["picture_playlist"].ToString());
                                    }
                                    else
                                        writer.Write("Không tìm thấy playlist với ID: " + id_playlist);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy playlist: " + ex.Message);
                    }
                }
                else if (requestType == "deletePlaylist")
                {
                    try
                    {
                        int id_playlist = int.Parse(reader.ReadString());
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "DELETE FROM playlists WHERE id_playlist = @id_playlist";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_playlist", id_playlist);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        writer.Write("OK");
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi xóa playlist: " + ex.Message);
                    }
                }
                else if (requestType == "getIdSongFromPlaylist")
                {
                    try
                    {
                        int id_playlist = int.Parse(reader.ReadString());
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT id_song FROM playlist_songs WHERE id_playlist = @id_playlist";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_playlist", id_playlist);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    List<string> songIds = new List<string>();
                                    while (readerdb.Read())
                                    {
                                        songIds.Add(readerdb["id_song"].ToString());
                                    }
                                    writer.Write("OK");
                                    writer.Write(songIds.Count);
                                    foreach (var id in songIds)
                                    {
                                        writer.Write(id);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy id bài hát từ playlist: " + ex.Message);
                    }
                }
                else if (requestType == "insertSongToPlaylist")
                {
                    int id_playlist = int.Parse(reader.ReadString());
                    int id_song = int.Parse(reader.ReadString());
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "INSERT INTO playlist_songs (id_playlist, id_song) VALUES (@id_playlist, @id_song)";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_playlist", id_playlist);
                                cmd.Parameters.AddWithValue("@id_song", id_song);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        writer.Write("OK");
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi thêm bài hát vào playlist: " + ex.Message);
                    }
                }
                else if (requestType == "deleteSongFromPlaylist")
                {
                    int id_playlist = int.Parse(reader.ReadString());
                    int id_song = int.Parse(reader.ReadString());
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "DELETE FROM playlist_songs WHERE id_playlist = @id_playlist AND id_song = @id_song";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_playlist", id_playlist);
                                cmd.Parameters.AddWithValue("@id_song", id_song);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        writer.Write("OK");
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi xóa bài hát khỏi playlist: " + ex.Message);
                    }
                }
                else if (requestType == "checkSongInPlaylist")
                {
                    int id_playlist = int.Parse(reader.ReadString());
                    int id_song = int.Parse(reader.ReadString());

                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT COUNT(*) FROM playlist_songs WHERE id_song = @id_song AND id_playlist = @id_playlist";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_playlist", id_playlist);
                                cmd.Parameters.AddWithValue("@id_song", id_song);
                                long count = (long)cmd.ExecuteScalar();

                                if (count > 0)
                                {
                                    writer.Write("Exists");
                                }
                                else
                                {
                                    writer.Write("Nothing");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi kiểm tra bài hát trong playlist: " + ex.Message);
                    }
                }
                else if (requestType == "getIDSearchSong")
                {
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string keyword = reader.ReadString();
                            string query = "SELECT id_song FROM songs WHERE name_song ILIKE @keyword";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    List<string> songIds = new List<string>();

                                    while (readerdb.Read())
                                    {
                                        songIds.Add(readerdb["id_song"].ToString());
                                    }

                                    writer.Write("OK");
                                    writer.Write(songIds.Count);

                                    foreach (var id in songIds)
                                    {
                                        writer.Write(id);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy id bài hát: " + ex.Message);
                    }
                }
                else if (requestType == "getIDSearchSongFavourite")
                {
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string keyword = reader.ReadString();
                            string query = "SELECT favourites.id_song FROM favourites INNER JOIN songs ON favourites.id_song = songs.id_song WHERE name_song ILIKE @keyword";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    List<string> songIds = new List<string>();

                                    while (readerdb.Read())
                                    {
                                        songIds.Add(readerdb["id_song"].ToString());
                                    }

                                    writer.Write("OK");
                                    writer.Write(songIds.Count);

                                    foreach (var id in songIds)
                                    {
                                        writer.Write(id);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy id bài hát yêu thích: " + ex.Message);
                    }
                }    
                else if (requestType == "getIDSearchArtis")
                {
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string keyword = reader.ReadString();
                            string query = "SELECT id_singer FROM singer WHERE name_singer ILIKE @keyword";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    List<string> singerIds = new List<string>();
                                    while (readerdb.Read())
                                    {
                                        singerIds.Add(readerdb["id_singer"].ToString());
                                    }

                                    writer.Write("OK");
                                    writer.Write(singerIds.Count);

                                    foreach (var id in singerIds)
                                    {
                                        writer.Write(id);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy id nghệ sĩ: " + ex.Message);
                    }
                }
                else if (requestType == "getAllSongName")
                {
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT name_song FROM songs";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    List<string> songName = new List<string>();

                                    while (readerdb.Read())
                                    {
                                        songName.Add(readerdb["name_song"].ToString());
                                    }
                                    writer.Write("OK");
                                    writer.Write(songName.Count);

                                    foreach (var name in songName)
                                    {
                                        writer.Write(name);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy tên bài hát: " + ex.Message);
                    }
                }
                else if (requestType == "getAllSongFavouriteName")
                {
                    try
                    {
                        int id_user = int.Parse(reader.ReadString());
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT name_song FROM songs INNER JOIN favourites ON songs.id_song = favourites.id_song WHERE id_user = @id_user";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_user", id_user);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    List<string> songName = new List<string>();

                                    while (readerdb.Read())
                                    {
                                        songName.Add(readerdb["name_song"].ToString());
                                    }
                                    writer.Write("OK");
                                    writer.Write(songName.Count);

                                    foreach (var name in songName)
                                    {
                                        writer.Write(name);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy tên bài hát yêu thích: " + ex.Message);
                    }
                }
                else if (requestType == "getAllSingerName")
                {
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT name_singer FROM singer";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    List<string> singerName = new List<string>();

                                    while (readerdb.Read())
                                    {
                                        singerName.Add(readerdb["name_singer"].ToString());
                                    }
                                    writer.Write("OK");
                                    writer.Write(singerName.Count);

                                    foreach (var name in singerName)
                                    {
                                        writer.Write(name);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy tên bài hát: " + ex.Message);
                    }
                }
                else if (requestType == "songForm")
                {
                    try
                    {
                        int id_song = int.Parse(reader.ReadString());
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT name_song, picture_song FROM songs WHERE id_song = @id_song";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_song", id_song);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    if (readerdb.Read())
                                    {
                                        writer.Write("OK");
                                        writer.Write(readerdb["name_song"].ToString());
                                        writer.Write(readerdb["picture_song"].ToString());
                                    }
                                    else
                                        writer.Write("Không tìm thấy bài hát với ID: " + id_song);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy bài hát: " + ex.Message);
                    }
                }
                else if (requestType == "artistForm")
                {
                    try
                    {
                        int id_singer = int.Parse(reader.ReadString());
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT name_singer, picture_singer FROM singer WHERE id_singer = @id_singer";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_singer", id_singer);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    if (readerdb.Read())
                                    {
                                        writer.Write("OK");
                                        writer.Write(readerdb["name_singer"].ToString());
                                        writer.Write(readerdb["picture_singer"].ToString());
                                    }
                                    else
                                        writer.Write("Không tìm thấy nghệ sĩ với ID: " + id_singer);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy nghệ sĩ: " + ex.Message);
                    }
                }
                else if (requestType == "listenMusic")
                {
                    try
                    {
                        int id_song = int.Parse(reader.ReadString());
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT singer.id_singer, name_singer, picture_singer, birthdate, picture_song, am_thanh FROM songs INNER JOIN singer ON songs.id_singer = singer.id_singer WHERE id_song = @id_song";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_song", id_song);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    if (readerdb.Read())
                                    {
                                        writer.Write("OK");
                                        writer.Write(readerdb["id_singer"].ToString());
                                        writer.Write(readerdb["name_singer"].ToString());
                                        writer.Write(readerdb["picture_singer"].ToString());
                                        writer.Write(readerdb["birthdate"].ToString());

                                        writer.Write(readerdb["picture_song"].ToString());

                                    }
                                    else
                                        writer.Write("Không tìm thấy bài hát với ID: " + id_song);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy bài hát: " + ex.Message);
                    }
                }
                else if (requestType == "musicBar")
                {
                    try
                    {
                        int id_song = int.Parse(reader.ReadString());
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT name_song, am_thanh FROM songs WHERE id_song = @id_song";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_song", id_song);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    if (readerdb.Read())
                                    {
                                        writer.Write("OK");
                                        writer.Write(readerdb["am_thanh"].ToString());
                                        writer.Write(readerdb["name_song"].ToString());

                                    }
                                    else
                                        writer.Write("Không tìm thấy bài hát với ID: " + id_song);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy bài hát: " + ex.Message);
                    }
                }
                else if (requestType == "artistInfor")
                {
                    try
                    {
                        int id_singer = int.Parse(reader.ReadString());
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            // Lấy thông tin cơ bản của nghệ sĩ
                            string querySinger = "SELECT id_singer, name_singer, picture_singer, birthdate, nationality FROM singer WHERE id_singer = @id_singer";
                            string name_singer = "", picture_singer = "", birthdate = "", nationality = "";
                            using (var cmdSinger = new NpgsqlCommand(querySinger, conn))
                            {
                                cmdSinger.Parameters.AddWithValue("@id_singer", id_singer);
                                using (var readerdb = cmdSinger.ExecuteReader())
                                {
                                    if (readerdb.Read())
                                    {
                                        name_singer = readerdb["name_singer"].ToString();
                                        picture_singer = readerdb["picture_singer"].ToString();
                                        birthdate = readerdb["birthdate"].ToString();
                                        nationality = readerdb["nationality"].ToString();
                                    }
                                    else
                                    {
                                        writer.Write("Không tìm thấy nghệ sĩ với ID: " + id_singer);
                                        return;
                                    }
                                }
                            }

                            // Gửi thông tin nghệ sĩ
                            writer.Write("OK");
                            writer.Write(id_singer.ToString());
                            writer.Write(name_singer);
                            writer.Write(picture_singer);
                            writer.Write(birthdate);
                            writer.Write(nationality);

                            // Lấy danh sách bài hát của nghệ sĩ
                            string querySongs = "SELECT id_song FROM songs WHERE id_singer = @id_singer";
                            using (var cmdSongs = new NpgsqlCommand(querySongs, conn))
                            {
                                cmdSongs.Parameters.AddWithValue("@id_singer", id_singer);
                                using (var readerSongs = cmdSongs.ExecuteReader())
                                {
                                    List<string> songIds = new List<string>();
                                    while (readerSongs.Read())
                                    {
                                        songIds.Add(readerSongs["id_song"].ToString());
                                    }

                                    writer.Write(songIds.Count);
                                    foreach (var id in songIds)
                                    {
                                        writer.Write(id);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy nghệ sĩ: " + ex.Message);
                    }
                }
                else if (requestType == "songSearch")
                {
                    try
                    {
                        int id_song = int.Parse(reader.ReadString());
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT name_song, picture_song, songs.id_singer, name_singer FROM songs INNER JOIN singer ON songs.id_singer = singer.id_singer WHERE id_song = @id_song";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_song", id_song);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    if (readerdb.Read())
                                    {
                                        writer.Write("OK");
                                        writer.Write(readerdb["name_song"].ToString());
                                        writer.Write(readerdb["picture_song"].ToString());
                                        writer.Write(readerdb["id_singer"].ToString());
                                        writer.Write(readerdb["name_singer"].ToString());
                                    }
                                    else
                                        writer.Write("Không tìm thấy bài hát với ID: " + id_song);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy bài hát: " + ex.Message);
                    }
                }
                else if (requestType == "songChoice")
                {
                    try
                    {
                        int id_song = int.Parse(reader.ReadString());
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT name_song, name_singer FROM songs INNER JOIN singer ON songs.id_singer = singer.id_singer WHERE id_song = @id_song";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_song", id_song);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    if (readerdb.Read())
                                    {
                                        writer.Write("OK");
                                        writer.Write(readerdb["name_song"].ToString());
                                        writer.Write(readerdb["name_singer"].ToString());
                                    }
                                    else
                                        writer.Write("Không tìm thấy bài hát với ID: " + id_song);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy bài hát: " + ex.Message);
                    }
                }
                else if (requestType == "chatForm")
                {
                    try
                    {
                        string email = reader.ReadString();
                        Console.WriteLine($"Received chatForm request with email: {email}");

                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT id_user, name_user FROM users WHERE email = @email";
                            Console.WriteLine($"Executing query: {query} with email = {email}");
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@email", email);

                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    if (readerdb.Read())
                                    {
                                        string id = readerdb["id_user"].ToString();
                                        string name = readerdb["name_user"].ToString();
                                        Console.WriteLine($"Raw data: id_user={readerdb["id_user"]}, name_user={readerdb["name_user"]}");
                                        writer.Write("OK");
                                        writer.Write(name);
                                        writer.Write(id);
                                        Console.WriteLine($"Returning user: name={name}, id={id}");
                                    }
                                    else
                                    {
                                        writer.Write("ERROR: User not found");
                                        Console.WriteLine("User not found for email: {email}");
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error in chatForm: {ex.GetType()} - {ex.Message} - StackTrace: {ex.StackTrace}");
                        writer.Write("ERROR: " + ex.Message);
                    }
                }
                else if (requestType == "chatRoom")
                {
                    username = reader.ReadString();

                    lock (chatLock) // Lock đảm bảo rằng chỉ một luồng có thể thêm client vào chatClients tại một thời điểm
                    {
                        clientInfor = new ClientInfor(username, clientIP, client); // Đối tượng để lưu thông tin client bao gồm tên, địa chỉ IP và đối tượng TcpClient
                        chatClients.Add(clientInfor);
                        AddToListView($"{clientIP}: Người dùng {username} vào nhóm chat"); // Thông báo người dùng đã vào nhóm chat trong ListView
                    }

                    // Ghi danh sách các client trong nhóm chat cho client
                    writer.Write("ClientList");
                    writer.Write(chatClients.Count);
                    foreach (var c in chatClients)
                    {
                        writer.Write($"{c.Username} ({c.IPAddress})");
                    }

                    while (true)
                    {
                        string message = reader.ReadString(); // Đọc tin nhắn từ client
                        if (string.IsNullOrEmpty(message) || message == "disconnect")
                            break;

                        // Ghi tin nhắn vào ListView và gửi cho tất cả client khác
                        string fullMessage = $"{clientIP}: {username}: {message}";
                        AddToListView(fullMessage);
                        BroadcastMessage(fullMessage);
                    }
                }
                else if (requestType == "searchUsers")
                {
                    try
                    {
                        string keyword = reader.ReadString();
                        int id_user = int.Parse(reader.ReadString());
                        Console.WriteLine($"Received search: keyword={keyword}, id_user={id_user}");

                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = @"
                SELECT id_user, name_user
                FROM users 
                WHERE LOWER(name_user) LIKE '%' || LOWER(@keyword) || '%'
                  AND id_user != @id_user";
                            Console.WriteLine($"Executing query: {query} with keyword={keyword}, id_user={id_user}");
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@keyword", keyword);
                                cmd.Parameters.AddWithValue("@id_user", id_user);

                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    List<string> users = new List<string>();
                                    while (readerdb.Read())
                                    {
                                        string id = readerdb["id_user"].ToString();
                                        string name = readerdb["name_user"].ToString();
                                        users.Add($"{id}|{name}");
                                    }

                                    writer.Write("OK");
                                    writer.Write(users.Count);
                                    Console.WriteLine($"Returning {users.Count} users");
                                    foreach (var user in users)
                                    {
                                        writer.Write(user);
                                        Console.WriteLine($"[Server] Gửi {user} đến {clientIP} tại {DateTime.Now}");
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error in searchUsers: {ex.GetType()} - {ex.Message} - StackTrace: {ex.StackTrace}");
                        writer.Write("ERROR: " + ex.Message);
                        writer.Write(0); // Gửi count = 0 để client xử lý
                    }
                }
                else if (requestType == "sendMessage")
                {
                    string senderId = reader.ReadString();
                    string receiverId = reader.ReadString();
                    string message = reader.ReadString();

                    string roomId = int.Parse(senderId) < int.Parse(receiverId)
                        ? $"{senderId}-{receiverId}"
                        : $"{receiverId}-{senderId}";

                    using (var conn = new NpgsqlConnection(connSona))
                    {
                        conn.Open();
                        string insertQuery = @"
                                INSERT INTO chat_messages (created_at, sender, message, room_id)
                                VALUES (NOW(), @sender, @message, @room_id)";

                        using (var cmd = new NpgsqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@sender", senderId);
                            cmd.Parameters.AddWithValue("@message", message);
                            cmd.Parameters.AddWithValue("@room_id", roomId);
                            cmd.ExecuteNonQuery();
                        }

                        writer.Write("OK");
                    }
                }
                else if (requestType == "getMessages")
                {
                    int id_user = int.Parse(reader.ReadString());
                    int target_id = int.Parse(reader.ReadString());

                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = @"
                SELECT message 
                FROM chat_messages 
                WHERE (sender = @id_user AND room_id LIKE @room_id) 
                   OR (sender = @target_id AND room_id LIKE @room_id_reverse)
                ORDER BY created_at"; // Giả sử có cột created_at

                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                string room_id = $"{id_user}-{target_id}";
                                string room_id_reverse = $"{target_id}-{id_user}";
                                cmd.Parameters.AddWithValue("@id_user", id_user);
                                cmd.Parameters.AddWithValue("@target_id", target_id);
                                cmd.Parameters.AddWithValue("@room_id", $"%{room_id}%");
                                cmd.Parameters.AddWithValue("@room_id_reverse", $"%{room_id_reverse}%");

                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    var messages = new List<string>();
                                    while (readerdb.Read())
                                    {
                                        messages.Add(readerdb["message"].ToString());
                                    }

                                    writer.Write("OK");
                                    writer.Write(messages.Count);
                                    foreach (var msg in messages)
                                    {
                                        writer.Write(msg);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Server] Lỗi getMessages: {ex.Message} tại {DateTime.Now}");
                        writer.Write("Lỗi getMessages: " + ex.Message);
                    }
                }
                if (requestType == "getRecentChats")
                {
                    try
                    {
                        int id_user = int.Parse(reader.ReadString());
                        Console.WriteLine($"[Server] Nhận id_user={id_user} từ {clientIP} tại {DateTime.Now}");

                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            Console.WriteLine($"[Server] Mở kết nối DB cho {clientIP} tại {DateTime.Now}");

                            string query = @"
                        SELECT DISTINCT 
                            CASE 
                                WHEN POSITION('-' IN room_id) > 0 THEN 
                                    CASE 
                                        WHEN SPLIT_PART(room_id, '-', 1)::integer = @id_user THEN SPLIT_PART(room_id, '-', 2)::integer
                                        ELSE SPLIT_PART(room_id, '-', 1)::integer
                                    END
                                ELSE NULL
                            END AS other_user
                        FROM chat_messages
                        WHERE (sender = @id_user OR room_id LIKE @like_id)
                          AND room_id IS NOT NULL";

                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_user", id_user);
                                cmd.Parameters.AddWithValue("@like_id", "%" + id_user.ToString() + "%");
                                Console.WriteLine($"[Server] Thực thi truy vấn cho id_user={id_user} tại {DateTime.Now}");

                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    HashSet<string> otherUsers = new HashSet<string>();
                                    while (readerdb.Read())
                                    {
                                        string otherUser = readerdb["other_user"].ToString();
                                        if (!string.IsNullOrEmpty(otherUser) && otherUser != id_user.ToString())
                                        {
                                            otherUsers.Add(otherUser);
                                        }
                                    }
                                    Console.WriteLine($"[Server] Tìm thấy {otherUsers.Count} người dùng khác cho id_user={id_user} tại {DateTime.Now}");

                                    writer.Write("OK");
                                    writer.Write(otherUsers.Count);
                                    Console.WriteLine($"[Server] Gửi OK và count={otherUsers.Count} đến {clientIP} tại {DateTime.Now}");

                                    foreach (var uid in otherUsers)
                                    {
                                        string queryUser = "SELECT name_user FROM users WHERE id_user = @uid";
                                        using (var cmdUser = new NpgsqlCommand(queryUser, conn))
                                        {
                                            cmdUser.Parameters.AddWithValue("@uid", int.Parse(uid));
                                            using (var r = cmdUser.ExecuteReader())
                                            {
                                                if (r.Read())
                                                {
                                                    string name = r["name_user"].ToString();
                                                    writer.Write($"{uid}|{name}");
                                                    Console.WriteLine($"[Server] Gửi {uid}|{name} đến {clientIP} tại {DateTime.Now}");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Server] Lỗi getRecentChats: {ex.Message} - StackTrace: {ex.StackTrace} tại {DateTime.Now}");
                        writer.Write("Lỗi getRecentChats: " + ex.Message);
                    }
                }
                else if (requestType == "addFavourite")
                {
                    int id_user = int.Parse(reader.ReadString());
                    int id_song = int.Parse(reader.ReadString());
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "INSERT INTO favourites (id_user, id_song) VALUES (@id_user, @id_song)";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_user", id_user);
                                cmd.Parameters.AddWithValue("@id_song", id_song);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        writer.Write("OK");
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi thêm bài hát vào yêu thích: " + ex.Message);
                    }
                }
                else if (requestType == "removeFavourite")
                {
                    int id_user = int.Parse(reader.ReadString());
                    int id_song = int.Parse(reader.ReadString());
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "DELETE FROM favourites WHERE id_user = @id_user AND id_song = @id_song";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_user", id_user);
                                cmd.Parameters.AddWithValue("@id_song", id_song);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        writer.Write("OK");
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi xóa bài hát khỏi yêu thích: " + ex.Message);
                    }
                }
                else if (requestType == "songFavourite")
                {
                    int id_user = int.Parse(reader.ReadString());
                    int id_song = int.Parse(reader.ReadString());

                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT COUNT(*) FROM favourites WHERE id_user = @id_user AND id_song = @id_song";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_user", id_user);
                                cmd.Parameters.AddWithValue("@id_song", id_song);
                                long count = (long)cmd.ExecuteScalar();

                                if (count > 0)
                                {
                                    writer.Write("Exists");
                                }
                                else
                                {
                                    writer.Write("Nothing");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi kiểm tra bài hát yêu thích: " + ex.Message);
                    }
                }
                else if (requestType == "Favourite")
                {
                    int id_user = int.Parse(reader.ReadString());
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT id_song FROM favourites WHERE id_user = @id_user";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_user", id_user);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    List<string> favouriteSongs = new List<string>();
                                    while (readerdb.Read())
                                    {
                                        favouriteSongs.Add(readerdb["id_song"].ToString());
                                    }
                                    writer.Write("OK");
                                    writer.Write(favouriteSongs.Count);
                                    foreach (var songId in favouriteSongs)
                                    {
                                        writer.Write(songId);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy danh sách yêu thích: " + ex.Message);
                    }
                }
                else if (requestType == "getUserInfor")
                {
                    int id_user = int.Parse(reader.ReadString());
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT name_user, email, phone_number, password FROM users WHERE id_user = @id_user";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_user", id_user);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    if (readerdb.Read())
                                    {
                                        writer.Write("OK");
                                        writer.Write(readerdb["name_user"].ToString());
                                        writer.Write(readerdb["email"].ToString());
                                        writer.Write(readerdb["phone_number"].ToString());
                                        writer.Write(readerdb["password"].ToString());
                                    }
                                    else
                                    {
                                        writer.Write("Không tìm thấy người dùng với ID: " + id_user);
                                    }
                                }
                            }
                        }
                    }
                    catch (NpgsqlException ex)
                    {
                        if (ex.Message.Contains("duplicate key value violates unique constraint"))
                        {
                            if (ex.Message.Contains("phone_number"))
                                writer.Write("Số điện thoại đã tồn tại!");
                        }
                        else
                        {
                            writer.Write("Lỗi khi cập nhật dữ liệu: " + ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy thông tin người dùng: " + ex.Message);
                    }
                }
                else if (requestType == "getAvatarUser")
                {
                    int id_user = int.Parse(reader.ReadString());
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT picture_user FROM users WHERE id_user = @id_user";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_user", id_user);
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    if (readerdb.Read())
                                    {
                                        writer.Write("OK");
                                        writer.Write(readerdb["picture_user"].ToString());
                                    }
                                    else
                                    {
                                        writer.Write("Không tìm thấy người dùng với ID: " + id_user);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy hình ảnh người dùng: " + ex.Message);
                    }
                }
                else if (requestType == "updateUserInfor")
                {
                    string email = reader.ReadString();
                    string name_user = reader.ReadString();
                    string phone_number = reader.ReadString();
                    string password = reader.ReadString();

                    string pictureUrl = "https://lgnvhovprubrxohnhwph.supabase.co/storage/v1/object/public/picture/Users/BaseAvatar.png";
                    string pathBucket = "picture/Users";
                    string hasAvatar = reader.ReadString();


                    if (hasAvatar == "hasAvatar")
                    {
                        int imageLength = reader.ReadInt32();
                        byte[] imageData = reader.ReadBytes(imageLength);
                        string result = Task.Run(async () =>
                        {
                            return await UploadImageToSupabase(email, imageData, pathBucket);
                        }).Result;
                        pictureUrl = result;
                    }

                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "UPDATE users SET name_user = @name_user, phone_number = @phone_number, password = @password, picture_user = @pictureUrl WHERE email = @email";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@email", email);
                                cmd.Parameters.AddWithValue("@name_user", name_user);
                                cmd.Parameters.AddWithValue("@phone_number", phone_number);
                                cmd.Parameters.AddWithValue("@password", password);
                                cmd.Parameters.AddWithValue("@pictureUrl", pictureUrl);

                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                    writer.Write("OK");
                                else
                                    writer.Write("Không tìm thấy người dùng với Email: " + email);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi cập nhật thông tin người dùng: " + ex.Message);
                    }
                }
                else
                {
                    writer.Write("Yêu cầu không hợp lệ!");
                }
            }
            catch (Exception ex)
            {
                if (clientInfor != null)
                {
                    lock (chatLock)
                    {
                        chatClients.Remove(clientInfor); // Xóa client khỏi danh sách khi có lỗi xảy ra
                        AddToListView($"{clientIP}: Người dùng {username} rời khỏi nhóm chat");
                    }
                }
            }
            finally
            {
                // Giải phóng tài nguyên
                stream?.Close();
                reader?.Close();
                writer?.Close();
                client?.Close();
            }
        }

        #region Chat
        // Phương thức gửi tin nhắn đến tất cả client trong nhóm chat
        private void BroadcastMessage(string message)
        {
            lock (chatLock)
            {
                foreach (var clientInfo in chatClients.ToList()) // Sử dụng ToList() để tránh lỗi khi xóa client trong vòng lặp
                {
                    try
                    {
                        NetworkStream stream = clientInfo.TcpClient.GetStream(); // Lấy luồng mạng từ client
                        BinaryWriter writer = new BinaryWriter(stream); // Đối tượng BinaryWriter để ghi dữ liệu vào luồng

                        // Gửi tín hiệu cho client và ghi nội dung tin nhắn
                        writer.Write("Message");
                        writer.Write(message);
                    }
                    catch
                    {
                        chatClients.Remove(clientInfo); // Xóa client khỏi danh sách nếu có lỗi xảy ra
                        AddToListView($"{clientInfo.IPAddress}: Người dùng {clientInfo.Username} rời khỏi nhóm chat");
                    }
                }
            }
        }
        #endregion

        #region SignUp
        // Hàm tạo mã OTP ngẫu nhiên (6 chữ số)
        private string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        // Hàm kiểm tra email đã tồn tại trong cơ sở dữ liệu chưa
        private bool IsEmailExists(string email)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connSona))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE email = @email";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Hàm kiểm tra số điện thoại đã tồn tại trong cơ sở dữ liệu chưa
        private bool IsPhoneNumberExists(string phoneNumber)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connSona))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE phone_number = @phone_number";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@phone_number", phoneNumber);
                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                return false;
            }
        }

        // Hàm gửi email chứa mã OTP
        private async Task<bool> SendOTPEmail(string email, string otp)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com") // Đối tượng sử dụng Gmail SMTP server
                {
                    Port = 587, // Cổng SMTP cho Gmail
                    Credentials = new NetworkCredential("sona.feelthemusic@gmail.com", "sxiz nqtc ddko izzj"), // Thông tin của gmail Server dùng để gửi mail
                    EnableSsl = true, // Bật SSL
                };

                string content = isForgetPassword ? "đổi mật khẩu" : "đăng ký";

                var mailMessage = new MailMessage // Tạo đối tượng MailMessage để gửi email với nội dung
                {
                    From = new MailAddress("sona.feelthemusic@gmail.com"), // Địa chỉ email gửi đi
                    Subject = $"Mã OTP xác nhận {content} tài khoản SONA", // Tiêu đề email
                    Body = $"Mã OTP của bạn là: <strong>{otp}</strong><br>Vui lòng nhập mã này để hoàn tất {content}. Mã có hiệu lực trong {OTPExpirationMinutes} phút.", // Nội dung email chứa mã OTP
                    IsBodyHtml = true, // Cho phép định dạng HTML
                };
                mailMessage.To.Add(email); // Địa chỉ email nhận

                await smtpClient.SendMailAsync(mailMessage); // Gửi email bất đồng bộ
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async Task<string> GetOTPfromEmail(string email)
        {
            try
            {
                if (!isForgetPassword)
                {
                    if (IsEmailExists(email))
                        return "Tài khoản Email đã tồn tại!";
                }
                else
                {
                    if (!IsEmailExists(email))
                        return "Tài khoản Email không tồn tại!";
                }

                if (otpStore.ContainsKey(email))
                {
                    var otpData = otpStore[email];
                    if ((DateTime.Now - otpData.createdTime).TotalSeconds < OTPResendCooldown)
                    {
                        return $"Vui lòng chờ {Math.Ceiling(OTPResendCooldown - (DateTime.Now - otpData.createdTime).TotalSeconds)} giây trước khi gửi lại!";
                    }
                }

                string newOTP = GenerateOTP();
                if (await SendOTPEmail(email, newOTP))
                {
                    otpStore[email] = (newOTP, DateTime.Now);
                    return "OK";
                }
                else
                {
                    return "Lỗi gửi mã OTP. Địa chỉ Email không hợp lệ!";
                }
            }
            catch (Exception ex)
            {
                return "Lỗi gửi mã OTP: " + ex.Message;
            }
        }

        private string CheckOTP(string email, string otp)
        {
            try
            {
                if (!otpStore.ContainsKey(email))
                {
                    return "Mã OTP không tồn tại! Vui lòng yêu cầu mã mới.";
                }

                var otpData = otpStore[email];
                if ((DateTime.Now - otpData.createdTime).TotalMinutes > OTPExpirationMinutes)
                {
                    otpStore.Remove(email);
                    return "Mã OTP đã hết hạn! Vui lòng yêu cầu mã mới.";
                }

                if (otp != otpData.otp)
                {
                    return "Mã OTP không chính xác!";
                }

                otpStore.Remove(email); // Xóa OTP sau khi kiểm tra thành công
                return "OK";
            }
            catch (Exception ex)
            {
                return "Lỗi kiểm tra OTP: " + ex.Message;
            }
        }

        private async Task<string> RefreshOTP(string email)
        {
            if (!isForgetPassword)
            {
                if (IsEmailExists(email))
                    return "Tài khoản Email đã tồn tại!";
            }
            else
            {
                if (!IsEmailExists(email))
                    return "Tài khoản Email không tồn tại!";
            }

            try
            {
                if (otpStore.ContainsKey(email))
                {
                    var otpData = otpStore[email];
                    if ((DateTime.Now - otpData.createdTime).TotalSeconds < OTPResendCooldown)
                    {
                        return $"Vui lòng chờ {Math.Ceiling(OTPResendCooldown - (DateTime.Now - otpData.createdTime).TotalSeconds)} giây trước khi gửi lại!";
                    }
                }

                string newOTP = GenerateOTP();
                if (await SendOTPEmail(email, newOTP))
                {
                    otpStore[email] = (newOTP, DateTime.Now);
                    return "Mã OTP mới đã được gửi tới Email của bạn!";
                }
                else
                {
                    return "Lỗi gửi mã OTP mới. Địa chỉ Email không hợp lệ!";
                }
            }
            catch (Exception ex)
            {
                return "Lỗi gửi lại OTP: " + ex.Message;
            }
        }

        private async Task<string> UploadImageToSupabase(string email, byte[] imageData, string pathBucket)
        {
            try
            {
                // Khởi tạo client Supabase
                var supabase = new Supabase.Client(
                    "https://lgnvhovprubrxohnhwph.supabase.co",
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImxnbnZob3ZwcnVicnhvaG5od3BoIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTc0NjcxMzMwNywiZXhwIjoyMDYyMjg5MzA3fQ.l4pWH6PRKYHL1BXzsnbN1opJxqlSbR0bPFkysR39e_4"
                );

                // Tạo tên tệp duy nhất
                string fileName = $"{email}_{DateTime.Now:yyyyMMddHHmmss}.jpg";
                var bucket = supabase.Storage.From(pathBucket); // Lấy bucket

                // Upload ảnh (bất đồng bộ)
                var fileObject = await bucket.Upload(imageData, fileName, new Supabase.Storage.FileOptions
                {
                    CacheControl = "3600", // Tuổi thọ bộ nhớ cache
                    ContentType = "image/jpeg", // Định dạng MIME
                    Upsert = true // Cho phép ghi đè nếu tệp đã tồn tại
                });

                // Nếu không có ngoại lệ, coi như upload thành công
                string publicUrl = bucket.GetPublicUrl(fileName);
                return publicUrl;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải ảnh lên Supabase: " + ex.Message);
                return "https://lgnvhovprubrxohnhwph.supabase.co/storage/v1/object/public/picture/Users/BaseAvatar.png";
            }
        }
        #endregion

        #region Login
        // Phương thức kiểm tra thông tin đăng nhập người dùng
        private string CheckUserLogin(string username, string password)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connSona))
                {
                    conn.Open();
                    string query = "SELECT id_user, email FROM users WHERE email = @email AND password = @password";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userEmail = reader["email"].ToString();
                                return "OK";
                            }
                            else
                            {
                                return "Email hoặc mật khẩu không đúng!";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Lỗi đăng nhập: " + ex.Message;
            }
        }
        private string SetNewPassword(string email, string otp, string newPassword)
        {
            try
            {
                if (!isForgetPassword)
                {
                    if (IsEmailExists(email))
                        return "Tài khoản Email đã tồn tại!";
                }
                else
                {
                    if (!IsEmailExists(email))
                        return "Tài khoản Email không tồn tại!";
                }

                if (!otpStore.ContainsKey(email))
                    return "Mã OTP không tồn tại! Vui lòng yêu cầu mã mới.";

                var otpData = otpStore[email];
                if ((DateTime.Now - otpData.createdTime).TotalMinutes > OTPExpirationMinutes)
                {
                    otpStore.Remove(email);
                    return "Mã OTP đã hết hạn! Vui lòng yêu cầu mã mới.";
                }

                if (otp != otpData.otp)
                {
                    return "Mã OTP không chính xác!";
                }

                using (var conn = new NpgsqlConnection(connSona))
                {
                    conn.Open();
                    string query = "UPDATE users SET password = @password WHERE email = @email";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@password", newPassword);
                        cmd.Parameters.AddWithValue("@email", email);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            otpStore.Remove(email);
                            return "OK";
                        }
                        else
                        {
                            return "Không tìm thấy tài khoản để đổi mật khẩu.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Lỗi đặt mật khẩu mới: " + ex.Message;
            }
        }
        #endregion

        // Phương thức lấy địa chỉ IP cục bộ
        private string GetLocalIPAddress()
        {
            string localIP = "Unknown";
            try
            {
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    // Chỉ lấy adapter đang hoạt động, không phải loopback, và có tên gợi ý là WiFi
                    if (ni.OperationalStatus == OperationalStatus.Up &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        (ni.Name.ToLower().Contains("wi-fi") || ni.Description.ToLower().Contains("wireless")))
                    {
                        var ipProps = ni.GetIPProperties();
                        foreach (UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                return ip.Address.ToString(); // Trả về IPv4 của adapter WiFi
                            }
                        }
                    }
                }

                // Nếu không tìm thấy theo tên, thì thử tìm adapter có Gateway IPv4
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.OperationalStatus == OperationalStatus.Up &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    {
                        var ipProps = ni.GetIPProperties();
                        if (ipProps.GatewayAddresses.Any(g => g.Address.AddressFamily == AddressFamily.InterNetwork))
                        {
                            foreach (UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
                            {
                                if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                                {
                                    return ip.Address.ToString(); // Trả về IPv4 của adapter có Gateway
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy địa chỉ IP: " + ex.Message);
            }
            return localIP;
        }

        // Phương thức xóa toàn bộ dữ liệu trong bảng IP và thêm địa chỉ IP mới vào bảng
        private void ClearAndInsertIP()
        {
            string localIP = GetLocalIPAddress();
            try
            {
                using (var conn = new NpgsqlConnection(connIP)) // Tạo kết nối tới cơ sở dữ liệu PostgreSQL
                {
                    conn.Open();

                    // Xóa toàn bộ dữ liệu trong bảng IP
                    using (var deleteCmd = new NpgsqlCommand("DELETE FROM ip", conn))
                    {
                        deleteCmd.ExecuteNonQuery();
                    }

                    // Thêm IP mới
                    using (var insertCmd = new NpgsqlCommand("INSERT INTO IP (address) VALUES (@ip)", conn))
                    {
                        insertCmd.Parameters.AddWithValue("ip", localIP);
                        insertCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Đã cập nhật IP: " + localIP);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật IP: " + ex.Message);
            }
        }

        // Phương thức khởi động server
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                btnStart.Enabled = false;
                ClearAndInsertIP();

                // Khởi tạo đối tượng TcpListener để lắng nghe kết nối từ client
                server = new TcpListener(IPAddress.Any, 5000);
                server.Start();
                isRunning = true; // Đặt trạng thái server là đang chạy

                // Khởi động luồng lắng nghe kết nối từ client
                clientListener = new Thread(Listen);
                clientListener.IsBackground = true;
                clientListener.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi động server: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                // Đặt trạng thái dừng server
                isRunning = false;
                btnStart.Enabled = true;

                // Dừng TcpListener
                if (server != null)
                {
                    server.Stop();
                    server = null;
                    AddToListView("Server đã dừng lắng nghe kết nối.");
                }

                // Đóng tất cả kết nối client
                lock (chatLock)
                {
                    foreach (var clientInfo in chatClients.ToList())
                    {
                        try
                        {
                            clientInfo.TcpClient?.Close();
                            AddToListView($"{clientInfo.IPAddress}: Người dùng {clientInfo.Username} đã ngắt kết nối.");
                        }
                        catch (Exception ex)
                        {
                            AddToListView($"Lỗi khi đóng kết nối của {clientInfo.IPAddress}: {ex.Message}");
                        }
                    }
                    chatClients.Clear(); // Xóa danh sách client
                }

                // Đợi luồng Listen kết thúc (nếu cần)
                if (clientListener != null && clientListener.IsAlive)
                {
                    clientListener.Join(1000); // Đợi tối đa 1 giây để luồng kết thúc
                    clientListener = null;
                }

                MessageBox.Show("Server đã dừng thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi dừng server: " + ex.Message);
            }
        }
    }
}