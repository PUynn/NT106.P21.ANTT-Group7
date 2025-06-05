using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Util.Store;
using System.Data;
using System.Net.Mail;
using Supabase.Gotrue;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;
using System.Reflection;

namespace SONA_Server
{
    public partial class ServerForm : Form
    {
        // Chuỗi kết nối tới cơ sở dữ liệu PostgreSQL trên Supabase
        string connIP = "Host=aws-0-ap-southeast-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.bzjfiynoyelxlpowlhty;Password=laptrinhmang;SSL Mode=Require;Trust Server Certificate=true";
        string connSona = "Host=aws-0-ap-southeast-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.lgnvhovprubrxohnhwph;Password=laptrinhmang;SSL Mode=Require;Trust Server Certificate=true";
        
        private SupabaseService supabaseService; // Đối tượng kết nối với Supabase

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
                lvManageMess.Invoke(new Action<string>(msg => lvManageMess.Items.Add(msg)), message);
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

                    // Lấy địa chỉ IP của client và thêm vào ListView
                    string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).ToString();
                    AddToListView($"New client connected from: {clientIP}");

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
        private async void HandleClient(object obj)
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

            try
            {
                stream = client.GetStream(); // Lấy luồng mạng từ client
                reader = new BinaryReader(stream); // Tạo đối tượng BinaryReader để đọc dữ liệu từ luồng
                writer = new BinaryWriter(stream); // Tạo đối tượng BinaryWriter để ghi dữ liệu vào luồng

                string requestType = reader.ReadString(); // Đọc loại yêu cầu từ client (login, signup, chat)
                
                #region Login
                if (requestType == "loginUser")
                {
                    // Đọc thông tin username và password nhập từ client
                    string usernameLogin = reader.ReadString();
                    string password = reader.ReadString();

                    string loginSuccess = CheckUserLogin(usernameLogin, password); // Gọi phương thức CheckUserLogin để kiểm tra thông tin đăng nhập
                    writer.Write(loginSuccess); // Ghi kết quả đăng nhập về client
                }
                else if (requestType == "loginGoogle")
                {
                    string result = Task.Run(async () =>
                    {
                        return await CheckLoginGoogle();
                    }).Result;
                    writer.Write(result);
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
                else if (requestType == "singupGoogle")
                {
                    string result = Task.Run(async () =>
                    {
                        return await CheckSignUpGoogle();
                    }).Result;
                    writer.Write(result);
                    writer.Write(userEmail);
                }

                else if (requestType == "signupInfo")
                {
                    string usernameSignup = reader.ReadString();
                    string password = reader.ReadString();
                    string phone = reader.ReadString();
                    string email = reader.ReadString();

                    string result = CheckSignUpInfo(usernameSignup, password, phone, email);
                    writer.Write(result);
                }
                #endregion

                else if (requestType == "userInfo")
                {
                    string email = reader.ReadString();
                    try
                    {
                        using (var conn = new NpgsqlConnection(connSona))
                        {
                            conn.Open();
                            string query = "SELECT * FROM users WHERE email = @email";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                using (var readerdb = cmd.ExecuteReader())
                                {
                                    cmd.Parameters.AddWithValue("@email", email);

                                    if (readerdb.Read())
                                    {
                                        writer.Write("OK");
                                        writer.Write(readerdb["name_user"].ToString());
                                        writer.Write(readerdb["password"].ToString());
                                        writer.Write(readerdb["phone_number"].ToString());
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi kết nối tới người dùng: " + ex.Message);
                    }
                }
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

                                    if (songIds.Count == 0)
                                    {
                                        writer.Write("Không tìm thấy bài hát nào trong cơ sở dữ liệu.");
                                        return;
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

                                    if (singerIds.Count == 0)
                                    {
                                        writer.Write("Không tìm thấy nghệ sĩ nào trong cơ sở dữ liệu.");
                                        return;
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
                                        writer.Write(readerdb["am_thanh"].ToString());
                                        
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

                else if (requestType == "chat")
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
                        if (string.IsNullOrEmpty(message))
                            break;

                        // Ghi tin nhắn vào ListView và gửi cho tất cả client khác
                        string fullMessage = $"{clientIP}: {username}: {message}";
                        AddToListView(fullMessage);
                        BroadcastMessage(fullMessage);
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
                            string query = "SELECT name_song, picture_song, am_thanh, name_singer FROM songs INNER JOIN singer ON songs.id_singer = singer.id_singer WHERE id_song = @id_song";
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
                                        writer.Write(readerdb["am_thanh"].ToString());
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

        // Phương thức đăng kí bằng tải khoản Google
        private async Task<string> CheckSignUpGoogle()
        {
            try
            {
                string credPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()); // Đường dẫn thư mục tạm thời để lưu trữ thông tin xác thực
                Directory.CreateDirectory(credPath); // Tạo thư mục tạm nếu chưa tồn tại

                var clientSecrets = new ClientSecrets // Thông tin xác thực của tài khoản Google Cloud Console
                {
                    ClientId = "266768311409-sa0qg8353t75tscss8c71v44usk0cimq.apps.googleusercontent.com",
                    ClientSecret = "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"
                };

                var scopes = new[] { "profile", "email" }; // Lấy quyền truy cập thông tin người dùng gồm profile và email

                var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync( // Xác thực người dùng
                    clientSecrets, // Thông tin xác thực
                    scopes, // Quyền truy cập
                    "user", // Tên người dùng
                    CancellationToken.None, // Không hủy quá trình xác thực
                    new FileDataStore(credPath, true) // Lưu trữ thông tin xác thực vào thư mục tạm
                );

                if (credential != null && credential.Token != null) // Kiểm tra xem xác thực có thành công hay không bằng cách kiểm tra token
                {
                    var oauthService = new Oauth2Service(new BaseClientService.Initializer() // Gọi dịch vụ Oauth2 để lấy thông tin người dùng
                    {
                        HttpClientInitializer = credential // Thông tin xác thực đã được cấp quyền
                    });

                    Userinfo userInfo = await oauthService.Userinfo.Get().ExecuteAsync(); // Lấy thông tin người dùng từ Google
                    string email = userInfo.Email; // Lấy địa chỉ email của người dùng

                    if (IsEmailExists(email))
                    {
                        return "Email đã được đăng kí, vui lòng đăng nhập!";
                    }

                    userEmail = email;
                    return "OK"; // Nếu chưa tồn tại thì trả về OK
                }
                return "Lỗi xác thực Google: Không thể lấy thông tin người dùng."; // Nếu không lấy được thông tin người dùng thì trả về lỗi
            }
            catch (Exception ex)
            {
                return "Lỗi đăng ký Google: " + ex.Message;
            }
        }

        // Phương thức kiểm tra thông tin đăng ký người dùng
        private string CheckSignUpInfo(string username, string password, string phone, string email)
        {
            try
            {
                if (IsPhoneNumberExists(phone))
                {
                    return "Số điện thoại đã tồn tại";
                }

                using (var conn = new NpgsqlConnection(connSona))
                {
                    conn.Open();
                    string query = "INSERT INTO users (name_user, email, phone_number, password) VALUES (@name_user, @email, @phone_number, @password)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name_user", username);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@phone_number", phone);
                        cmd.Parameters.AddWithValue("@password", password);

                        cmd.ExecuteNonQuery();       
                    }
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return "Lỗi thông tin người dùng: " + ex.Message;
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

        // Phương thức kiểm tra thông tin đăng nhập tài khoản Google
        private async Task<string> CheckLoginGoogle()
        {
            try
            {
                string credPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                Directory.CreateDirectory(credPath);

                var clientSecrets = new ClientSecrets
                {
                    ClientId = "266768311409-sa0qg8353t75tscss8c71v44usk0cimq.apps.googleusercontent.com",
                    ClientSecret = "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"
                };

                var scopes = new[] { "profile", "email" };

                var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    clientSecrets,
                    scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)
                );

                if (credential != null && credential.Token != null)
                {
                    var oauthService = new Oauth2Service(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential
                    });

                    Userinfo userGoogle = await oauthService.Userinfo.Get().ExecuteAsync();
                    string email = userGoogle.Email;

                    if (IsEmailExists(email))
                        return "OK";
                    else
                        return "Email chưa tồn tại. Vui lòng đăng kí tài khoản!";
                }
                return "Lỗi xác thực Google: Không thể lấy thông tin người dùng.";
            }
            catch (Exception ex)
            {
                return "Lỗi đăng nhập bằng Google: " + ex.Message;
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
                    using (var deleteCmd = new NpgsqlCommand("DELETE FROM IP", conn))
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
                // Khởi tạo đối tượng SupabaseService
                supabaseService = new SupabaseService();
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
