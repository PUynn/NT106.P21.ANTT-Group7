using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Util.Store;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Google.Apis.Oauth2.v2.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net.Sockets;
using Npgsql;

namespace SONA
{
    public partial class Login : UserControl
    {
        SONA S;

        private const string AppId = "984538890449740";
        private const string AppSecret = "1f3490111b9ddddbf4010a67954a1522";
        private const string RedirectUri = "http://localhost:8000/facebook-signin";
        private const string AuthUrl = "https://www.facebook.com/v20.0/dialog/oauth?client_id={0}&redirect_uri={1}&response_type=code&scope=public_profile";
        
        private SupabaseService supabaseService; // Đối tượng kết nối với Supabase
        //private string serverIP = "127.0.0.1";
        //string connString = "Host=db.bzjfiynoyelxlpowlhty.supabase.co;Database=postgres;Username=postgres;Password=laptrinhmang;SSL Mode=Require;Trust Server Certificate=true";
        private bool isPasswordVisible = false; // Biến trạng thái để theo dõi mật khẩu đang hiển thị hay không

        private HttpListener httpListener;

        public Login(SONA s)
        {
            InitializeComponent();
            S = s;
        }

        //private void GetIP()
        //{
        //    using (var conn = new NpgsqlConnection(connString))
        //    {
        //        conn.Open();
        //        using (var selectCmd = new NpgsqlCommand("SELECT address FROM IP LIMIT 1", conn))
        //        {
        //            var result = selectCmd.ExecuteScalar();
        //            if (result != null)
        //            {
        //                serverIP = result.ToString();
        //            }
        //        }
        //    }
        //}

        private void lbDangky_Click(object sender, EventArgs e)
        {
            SignUp l = new SignUp(S);
            S.pnLogin.Controls.Clear();
            S.pnLogin.Controls.Add(l);
            httpListener?.Stop();
        }

        private void OpenHomeForm()
        {
            S.ShowHome();
        }

        private async void btnLoginGoogle_Click(object sender, EventArgs e)
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

                    Userinfo userInfo = await oauthService.Userinfo.Get().ExecuteAsync();
                    string email = userInfo.Email;

                    // Khởi tạo kết nối Supabase
                    supabaseService = new SupabaseService();
                    await supabaseService.InitializeAsync();
                    var userInfos = await supabaseService.GetUserInfosAsync();

                    // Kiểm tra email đã tồn tại chưa
                    if (userInfos.Any(u => u.email == email))
                    {
                        this.Invoke(new Action(() =>
                        {
                            OpenHomeForm();
                            S.Activate();
                        }));
                    }
                    else
                    {    
                        this.Invoke(new Action(() =>
                        {
                            lblCheck.Text = "Email chưa tồn tại, vui lòng đăng kí tài khoản!";
                            S.Activate();
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
        }

        private void btnFacebookLogin_Click(object sender, EventArgs e)
        {
            string loginUrl = string.Format(AuthUrl, AppId, Uri.EscapeDataString(RedirectUri));

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = loginUrl,
                    UseShellExecute = true
                });
                StartHttpListener();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở trình duyệt: " + ex.Message);
            }
        }

        private async void StartHttpListener()
        {
            httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:8000/");
            httpListener.Start();

            await Task.Run(async () =>
            {
                try
                {
                    var context = await httpListener.GetContextAsync();
                    var request = context.Request;
                    var response = context.Response;

                    string code = request.QueryString["code"];
                    string error = request.QueryString["error"];
                    string errorDescription = request.QueryString["error_description"];

                    if (!string.IsNullOrEmpty(error))
                    {
                        string errorResponse = $"<html><body><h1>Lỗi đăng nhập: {errorDescription}</h1></body></html>";
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(errorResponse);
                        response.ContentLength64 = buffer.Length;
                        response.OutputStream.Write(buffer, 0, buffer.Length);
                        response.Close();
                        httpListener.Stop();

                        this.Invoke(new Action(() =>
                        {
                            S.Activate();
                        }));
                        return;
                    }

                    if (!string.IsNullOrEmpty(code))
                    {
                        await GetAccessToken(code);
                        string htmlResponse = "<html><body><h1>Đăng nhập thành công! Bạn có thể đóng trang này.</h1></body></html>";
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(htmlResponse);
                        response.ContentLength64 = buffer.Length;
                        response.OutputStream.Write(buffer, 0, buffer.Length);
                    }
                    else
                    {
                        string errorResponse = "<html><body><h1>Đăng nhập thất bại! Vui lòng thử lại.</h1></body></html>";
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(errorResponse);
                        response.ContentLength64 = buffer.Length;
                        response.OutputStream.Write(buffer, 0, buffer.Length);

                        this.Invoke(new Action(() =>
                        {
                            S.Activate();
                        }));
                    }

                    response.Close();
                    httpListener.Stop();
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Lỗi khi nhận mã code: " + ex.Message);
                        S.Activate();
                    }));
                }
            });
        }

        private async Task GetAccessToken(string code)
        {
            string tokenUrl = $"https://graph.facebook.com/v20.0/oauth/access_token?client_id={AppId}&redirect_uri={Uri.EscapeDataString(RedirectUri)}&client_secret={AppSecret}&code={code}";
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(tokenUrl);
                var json = JObject.Parse(response);
                string accessToken = json["access_token"]?.ToString();

                if (!string.IsNullOrEmpty(accessToken))
                {
                    await GetUserInfo(accessToken);
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Không thể lấy access token!");
                        S.Activate();
                    }));
                }
            }
        }

        private async Task GetUserInfo(string accessToken)
        {
            string userUrl = $"https://graph.facebook.com/v20.0/me?fields=id,name&access_token={accessToken}";
            using (var client = new HttpClient())
            {
                var userInfo = await client.GetStringAsync(userUrl);
                var json = JObject.Parse(userInfo);

                string name = json["name"]?.ToString();
                this.Invoke(new Action(() =>
                {
                    OpenHomeForm();
                    S.Activate();
                }));
            }
        }

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            lblCheck.Text = ""; // Xóa thông báo lỗi trước khi kiểm tra

            if (string.IsNullOrEmpty(tbEmail.Text) || string.IsNullOrEmpty(tbPass.Text))
            {
                lblCheck.Text = "Vui lòng nhập đầy đủ email và mật khẩu!";
                return;
            }

            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("login");
                    writer.Write(tbEmail.Text);
                    writer.Write(tbPass.Text);
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        OpenHomeForm();
                        S.Activate();
                    }
                    else
                    {
                        lblCheck.Text = "Đăng nhập thất bại!";
                    }
                }
            }
            catch (Exception ex)
            {
                lblCheck.Text = "Lỗi: " + ex.Message;
            }

            //try
            //{
            //    supabaseService = new SupabaseService();
            //    await supabaseService.InitializeAsync(); // Khởi tạo kết nối với Supabase
            //    var userInfos = await supabaseService.GetUserInfosAsync(); // Lấy danh sách người dùng từ bảng table user trên Supabase

            //    var user = userInfos.FirstOrDefault(u => u.email == tbEmail.Text); // Tìm người dùng theo email

            //    if (user != null) // Nếu tìm thấy người dùng
            //    {
            //        if (user.password_tk == tbPass.Text) // Kiểm tra thuộc tính mật khẩu của user đó có trùng với mật khẩu đã nhập không
            //        {
            //            S.Activate(); // Kích hoạt form chính
            //            OpenHomeForm(); // Mở form chính
            //        }
            //        else
            //        {
            //            lblCheck.Text = "Mật khẩu không chính xác!";
            //        }
            //    }
            //    else // Thông báo người dùng không tồn tại nếu không tìm thấy
            //    {
            //        lblCheck.Text = "Email không tồn tại!";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lblCheck.Text = "Lỗi đăng nhập: " + ex.Message;
            //}
        }

        private void lbQuenmatkhau_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/viethoang.trannguyen.35");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            S.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lblCheck.Text = "";
        }

        private void tbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void tbPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void lbViewPassword_Click(object sender, EventArgs e)
        {
            pnViewPass_Click(sender, e);
        }

        private void pnViewPass_Click(object sender, EventArgs e)
        {
            // Đảo ngược trạng thái hiển thị mật khẩu
            isPasswordVisible = !isPasswordVisible;

            // Cập nhật thuộc tính UseSystemPasswordChar của tbPass
            tbPass.UseSystemPasswordChar = !isPasswordVisible;

            // Thay đổi nội dung của lbViewPassword để phản ánh trạng thái
            lbViewPassword.Text = isPasswordVisible ? "Ẩn" : "Hiện";
            pnViewPass.BackgroundImage = isPasswordVisible ? Properties.Resources.icons8_hide_30 : Properties.Resources.Show;
        }
    }
}