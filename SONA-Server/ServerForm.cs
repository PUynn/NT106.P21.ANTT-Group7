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

namespace SONA_Server
{
    public partial class ServerForm : Form
    {
        private const string AppId = "984538890449740";
        private const string AppSecret = "1f3490111b9ddddbf4010a67954a1522";

        string connString = "Host=aws-0-ap-southeast-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.bzjfiynoyelxlpowlhty;Password=laptrinhmang;SSL Mode=Require;Trust Server Certificate=true"; // Chuỗi kết nối tới cơ sở dữ liệu PostgreSQL trên Supabase
        private SupabaseService supabaseService; // Đối tượng kết nối với Supabase
        DataRow dr; // Biến lưu thông tin người dùng đăng nhập

        private TcpListener server; // Đối tượng TcpListener để lắng nghe kết nối từ client
        private List<ClientInfor> chatClients; // Lưu danh sách client trong nhóm chat
        private Thread clientListener; // Luồng lắng nghe kết nối từ client
        private object chatLock = new object(); // Khóa để đồng bộ hóa truy cập vào danh sách client
        bool isRunning = false; // Biến kiểm tra trạng thái server

        private Dictionary<string, (string otp, DateTime createdTime)> otpStore;
        bool isForgetPassword = false;

        private string srcEmail = "";
        private string generatedOTP; // Lưu mã OTP đã gửi
        private DateTime lastOTPSentTime; // Lưu thời gian gửi OTP cuối cùng
        private DateTime otpCreatedTime; // Lưu thời gian tạo OTP
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

                if (requestType == "loginUser")
                {
                    // Đọc thông tin username và password nhập từ client
                    string usernameLogin = reader.ReadString();
                    string password = reader.ReadString();

                    string loginSuccess = Task.Run(async () => // Sử dụng Task.Run để thực hiện phương thức bất đồng bộ CheckUserLogin
                    {
                        return await CheckUserLogin(usernameLogin, password); // Gọi phương thức CheckUserLogin để kiểm tra thông tin đăng nhập
                    }).Result;

                    writer.Write(loginSuccess); // Ghi kết quả đăng nhập về client
                }
                else if (requestType == "loginGoogle")
                {
                    string result = Task.Run(async () => // Sử dụng Task.Run để thực hiện phương thức bất đồng bộ CheckLoginGoogle
                    {
                        return await CheckLoginGoogle(); // Gọi phương thức CheckLoginGoogle để kiểm tra thông tin đăng nhập Google
                    }).Result;
                    writer.Write(result); // Ghi kết quả đăng nhập về client
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
                    else if (type == "setpass")
                    {
                        string email = reader.ReadString();
                        string otp = reader.ReadString();
                        string newPassword = reader.ReadString();
                        string result = Task.Run(async () =>
                        {
                            return await SetNewPassword(email, otp, newPassword);
                        }).Result;
                        writer.Write(result);
                    }
                    isForgetPassword = false;
                }
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
                        string result = Task.Run(async () =>
                        {
                            return await CheckOTP(email, otp);
                        }).Result;
                        writer.Write(result);
                    }
                    else if (type == "refreshOTP")
                    {
                        string email = reader.ReadString();
                        string result = Task.Run(async () =>
                        {
                            return await RefreshOTP(email); // Gọi phương thức RefreshOTP để gửi lại mã OTP
                        }).Result;
                        writer.Write(result);
                    }
                }
                else if (requestType == "singupGoogle")
                {
                    string result = Task.Run(async () => // Sử dụng Task.Run để thực hiện phương thức bất đồng bộ CheckSignUpGoogle
                    {
                        return await CheckSignUpGoogle(); // Gọi phương thức CheckSignUpGoogle để kiểm tra thông tin đăng ký Google
                    }).Result;
                    writer.Write(result); // Ghi kết quả đăng ký về client
                    writer.Write(srcEmail);
                }

                else if (requestType == "signupInfo")
                {
                    string usernameSignup = reader.ReadString();
                    string password = reader.ReadString();
                    string phone = reader.ReadString();
                    string email = reader.ReadString();

                    string result = Task.Run(async () =>
                    {
                        return await CheckSignUpInfo(usernameSignup, password, phone, email); // Gọi phương thức CheckSignUp để kiểm tra thông tin đăng ký
                    }).Result;

                    writer.Write(result); // Ghi kết quả đăng ký về client
                }
                else if (requestType == "userInfo")
                {
                    string email = reader.ReadString(); // Đọc địa chỉ email từ client
                    try
                    {
                        // Kiểm tra email trên Supabase bằng cách lấy đối tượng email từ table users và so sánh
                        await supabaseService.InitializeAsync();
                        var userInfos = await supabaseService.GetUserInfosAsync();
                        var userFind = userInfos.FirstOrDefault(u => u.email == email); // Tìm người dùng theo email

                        if (userFind != null)
                        {
                            writer.Write("OK"); // Nếu email tồn tại thì trả về OK
                            writer.Write(userFind.id_user.ToString());
                            writer.Write(userFind.name_user);
                            writer.Write(userFind.password_tk);
                            writer.Write(userFind.create_at);
                            writer.Write(userFind.sdt);
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi tạo người dùng: " + ex.Message);
                    }
                }
                else if (requestType == "getSongs")
                {
                    try
                    {
                        await supabaseService.InitializeAsync();
                        var songs = await supabaseService.GetSongsAsync();

                        if (songs == null || songs.Count == 0)
                        {
                            writer.Write("NoSongs"); // Gửi tín hiệu không có bài hát
                        }
                        else
                        {
                            writer.Write("SongsFound"); // Gửi tín hiệu có bài hát
                            writer.Write(songs.Count); // Gửi số lượng bài hát
                            foreach (var song in songs)
                            {
                                // Gửi từng bài hát dưới dạng chuỗi
                                writer.Write(song.id_song.ToString());
                                writer.Write(song.picture_song ?? "");
                                writer.Write(song.name_song ?? "");
                                writer.Write(song.am_thanh ?? "");
                                writer.Write(song.id_singer.ToString());
                                writer.Write(song.name_singer ?? "");
                                writer.Write(song.picture_singer ?? "");
                                writer.Write(song.the_loai ?? "");
                                writer.Write(song.duration.ToString());
                                writer.Write(song.luot_nghe.ToString());
                                writer.Write(song.danh_gia.ToString());
                                writer.Write(song.volume.ToString());
                                writer.Write(song.birthdate ?? "");
                                writer.Write(song.nationality ?? "");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writer.Write("Lỗi lấy bài hát: " + ex.Message);
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

        // Hàm tạo mã OTP ngẫu nhiên (6 chữ số)
        private string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
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

                var mailMessage = new MailMessage // Tạo đối tượng MailMessage để gửi email với nội dung
                {
                    From = new MailAddress("sona.feelthemusic@gmail.com"), // Địa chỉ email gửi đi
                    Subject = "Mã OTP xác nhận đăng ký tài khoản SONA", // Tiêu đề email
                    Body = $"Mã OTP của bạn là: <strong>{otp}</strong><br>Vui lòng nhập mã này để hoàn tất đăng ký. Mã có hiệu lực trong {OTPExpirationMinutes} phút.", // Nội dung email chứa mã OTP
                    IsBodyHtml = true, // Cho phép định dạng HTML
                };
                mailMessage.To.Add(email); // Địa chỉ email nhận

                await smtpClient.SendMailAsync(mailMessage); // Gửi email bất đồng bộ
                lastOTPSentTime = DateTime.Now; // Lưu thời gian gửi OTP
                otpCreatedTime = DateTime.Now; // Lưu thời gian tạo OTP
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Hàm kiểm tra và xử lý đăng ký
        private async Task<string> GetOTPfromEmail(string email)
        {
            try
            {
                // Kiểm tra email trên Supabase bằng cách lấy đối tượng email từ table users và so sánh
                await supabaseService.InitializeAsync();
                var userInfos = await supabaseService.GetUserInfosAsync();
                var userFind = userInfos.FirstOrDefault(u => u.email == email);

                if (!isForgetPassword)
                {
                    if (userFind != null)
                        return "Tài khoản Email đã tồn tại!";
                }
                else
                {
                    if (userFind == null)
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

        private async Task<string> CheckOTP(string email, string otp)
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
            // Kiểm tra email trên Supabase bằng cách lấy đối tượng email từ table users và so sánh
            await supabaseService.InitializeAsync();
            var userInfos = await supabaseService.GetUserInfosAsync();
            var userFind = userInfos.FirstOrDefault(u => u.email == email);
            if (!isForgetPassword)
            {
                if (userFind != null)
                    return "Tài khoản Email đã tồn tại!";
            }
            else
            {
                if (userFind == null)
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

        private async Task<string> SetNewPassword(string email, string otp, string newPassword)
        {
            try
            {
                // Kiểm tra email trên Supabase bằng cách lấy đối tượng email từ table users và so sánh
                await supabaseService.InitializeAsync();
                var userInfos = await supabaseService.GetUserInfosAsync();
                var userFind = userInfos.FirstOrDefault(u => u.email == email);
                if (!isForgetPassword)
                {
                    if (userFind != null)
                        return "Tài khoản Email đã tồn tại!";
                }
                else
                {
                    if (userFind == null)
                        return "Tài khoản Email không tồn tại!";
                }

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

                // Kiểm tra mật khẩu có phù hợp với yêu cầu không
                bool checkNum = false;
                bool checkLetter = false;
                bool checkSpecial = false;

                for (int i = 0; i < newPassword.Length; i++)
                {
                    if (char.IsDigit(newPassword[i]))
                        checkNum = true;
                    else if (char.IsLetter(newPassword[i]))
                        checkLetter = true;
                    else if (newPassword[i] == '@' || newPassword[i] == '#' || newPassword[i] == '!' || newPassword[i] == '?')
                        checkSpecial = true;
                }

                if (!checkNum || !checkLetter || !checkSpecial)
                {
                    return "Mật khẩu đặt không hợp lệ!";
                }

                await supabaseService.UpdateUserPasswordAsync(email, newPassword);
                otpStore.Remove(email); // Xóa OTP sau khi sử dụng thành công
                return "OK";
            }
            catch (Exception ex)
            {
                return "Lỗi đặt mật khẩu mới: " + ex.Message;
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

                    // Khởi tạo kết nối Supabase
                    await supabaseService.InitializeAsync();
                    var userInfos = await supabaseService.GetUserInfosAsync();

                    // Kiểm tra email đã tồn tại chưa
                    if (userInfos.Any(u => u.email == email))
                    {
                        return "Email đã được đăng kí, vui lòng đăng nhập!";
                    }

                    srcEmail = email;
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
        private async Task<string> CheckSignUpInfo(string username, string password, string phone, string email)
        {
            try
            {
                await supabaseService.InitializeAsync(); // Khởi tạo kết nối tới Supabase
                var user = await supabaseService.GetUserInfosAsync(); // Lấy danh sách người dùng từ Supabase

                if (user.Any(u => u.sdt == phone)) // Kiểm tra số điện thoại đã tồn tại chưa bằng cách so sánh thuộc tính sdt của user với kết quả đã nhập từ textbox
                {
                    return "Số điện thoại đã tồn tại";
                }

                // Chuẩn bị đối tượng UserInfo để thêm vào Supabase
                var newUser = new UserInfo // Tạo một đối tượng mới của lớp UserInfo
                {
                    // Set các thuộc tính của user tương ứng với các thông tin đã nhập ở textbox
                    name_user = username,
                    sdt = phone,
                    email = email,
                    password_tk = password,
                    create_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") // Lưu thời gian hiện tại
                };
                await supabaseService.InsertUserAsync(newUser); // Thêm người dùng vào Supabase bằng cách gọi hàm InsertUserAsync ở trong SupabaseService
                return "OK";
            }
            catch (Exception ex)
            {
                return "Lỗi thông tin người dùng: " + ex.Message;
            }
        }

        // Phương thức kiểm tra thông tin đăng nhập người dùng
        private async Task<string> CheckUserLogin(string username, string password)
        {
            try
            {
                await supabaseService.InitializeAsync(); // Khởi tạo kết nối với Supabase
                var userInfos = await supabaseService.GetUserInfosAsync(); // Lấy danh sách người dùng từ bảng table user trên Supabase

                var user = userInfos.FirstOrDefault(u => u.email == username); // Tìm người dùng theo email

                if (user != null) // Nếu tìm thấy người dùng
                {
                    if (user.password_tk == password) // Kiểm tra thuộc tính mật khẩu của user đó có trùng với mật khẩu đã nhập không
                        return "OK"; // Nếu trùng thì trả về Ok
                    else
                        return "Mật khẩu chưa chính xác!";
                }
                else // Thông báo người dùng không tồn tại nếu không tìm thấy
                {
                    return "Không tồn tại tài khoản Email này!";
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

                    // Khởi tạo kết nối Supabase
                    supabaseService = new SupabaseService();
                    await supabaseService.InitializeAsync();

                    var userSupa = await supabaseService.GetUserInfosAsync();
                    var userInfo = userSupa.FirstOrDefault(u => u.email == email); // Tìm người dùng theo email

                    // Kiểm tra email đã tồn tại chưa
                    if (userInfo != null)
                    {
                        return "OK";
                    }
                    else
                    {
                        return "Email chưa tồn tại. Vui lòng đăng kí tài khoản!";
                    }
                }
                return "Lỗi xác thực Google: Không thể lấy thông tin người dùng.";
            }
            catch (Exception ex)
            {
                return "Lỗi đăng nhập bằng Google: " + ex.Message;
            }
        }

        // Phương thức lấy địa chỉ IP cục bộ
        private string GetLocalIPAddress()
        {
            string localIP = "Unknown";
            try
            {
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    // Chỉ lấy giao diện đang hoạt động và không phải loopback
                    if (ni.OperationalStatus == OperationalStatus.Up && ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    {
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                localIP = ip.Address.ToString();
                                return localIP; // Trả về IP đầu tiên tìm thấy (không phải loopback)
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
                using (var conn = new NpgsqlConnection(connString)) // Tạo kết nối tới cơ sở dữ liệu PostgreSQL
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
