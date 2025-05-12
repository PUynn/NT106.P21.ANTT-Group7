using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supabase;
using Postgrest.Models;
using Postgrest.Attributes;
using Npgsql;
using System.Runtime.InteropServices.WindowsRuntime;


namespace SONA_Server
{
    public partial class ServerForm : Form
    {
        private TcpListener server;
        string connString = "Host=db.bzjfiynoyelxlpowlhty.supabase.co;Database=postgres;Username=postgres;Password=laptrinhmang;SSL Mode=Require;Trust Server Certificate=true";
        private SupabaseService supabaseService; // Đối tượng kết nối với Supabase
        public ServerForm()
        {
            InitializeComponent();
        }
        private void Listen()
        {
            try
            {
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Thread clientThread = new Thread(HandleClient);
                    clientThread.IsBackground = true;
                    clientThread.Start(client);
                }
            }
            catch
            {
                server = new TcpListener(IPAddress.Any, 5000);
                server.Start();
            }
        }
        private void HandleClient(object obj)
        {
            TcpClient client = obj as TcpClient;
            using (NetworkStream stream = client.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                try
                {
                    string requestType = reader.ReadString(); // Đọc loại yêu cầu ("login",....v.v)

                    if (requestType == "login")
                    {
                        string username = reader.ReadString();
                        string password = reader.ReadString();

                        bool loginSuccess = Task.Run(async () =>
                        {
                            return await CheckUserLogin(username, password);
                        }).Result;

                        if (loginSuccess)
                        {
                            writer.Write("OK");
                        }
                        else
                        {
                            writer.Write("failed");
                        }
                    }
                    else if (requestType == "signup")
                    {
                        string username = reader.ReadString();
                        string password = reader.ReadString();
                        string phone = reader.ReadString();
                        string email = reader.ReadString();

                        string singUpSuccess = Task.Run(async () =>
                        {
                            return await CheckSignUp(username, password, phone, email);
                        }).Result;

                        writer.Write(singUpSuccess); // Ghi kết quả đăng ký vào luồng
                    }
                    else
                    {
                        writer.Write("Unknown request type");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xử lý yêu cầu từ client: " + ex.Message);
                }
                finally
                {
                    client.Close();
                }
            }
        }
        private async Task<string> CheckSignUp(string username, string password, string phone, string email)
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
                return "Có lỗi hệ thống";
            }
        }
        private async Task<bool> CheckUserLogin(string username, string password)
        {
            await supabaseService.InitializeAsync(); // Khởi tạo kết nối với Supabase
            var userInfos = await supabaseService.GetUserInfosAsync(); // Lấy danh sách người dùng từ bảng table user trên Supabase

            var user = userInfos.FirstOrDefault(u => u.email == username); // Tìm người dùng theo email

            if (user != null) // Nếu tìm thấy người dùng
            {
                if (user.password_tk == password) // Kiểm tra thuộc tính mật khẩu của user đó có trùng với mật khẩu đã nhập không
                {
                    return true;
                }
                else
                {
                    // Thông báo mật khẩu không đúng
                    return false;
                }
            }
            else // Thông báo người dùng không tồn tại nếu không tìm thấy
            {
                return false;
            }
        }
        // Phương thức lấy địa chỉ IP cục bộ
        private string GetLocalIPAddress()
        {
            string localIP = "Unknown";
            foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }
        private void ClearAndInsertIP()
        {
            string localIP = GetLocalIPAddress();
            using (var conn = new NpgsqlConnection(connString))
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                supabaseService = new SupabaseService();
                ClearAndInsertIP();
                server = new TcpListener(IPAddress.Any, 5000);
                server.Start();

                Thread clientListener = new Thread(Listen);
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
    }
}
