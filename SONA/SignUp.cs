using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class SignUp : UserControl
    {
        SONA S;
        private SupabaseService supabaseService;

        public SignUp(SONA s)
        {
            InitializeComponent();
            S = s;
            supabaseService = new SupabaseService();
        }

        // Hàm để quay lại form đăng nhập
        private void lbDangnhap_Click(object sender, EventArgs e)
        {
            Login info = new Login(S);
            S.pnLogin.Controls.Clear();
            S.pnLogin.Controls.Add(info);
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            lblCheck.Text = "";
        }

        // Hàm để kiểm tra xem email đã có trong cơ sở dữ liệu chưa, nếu chưa thì di chuyển đến form đăng ký thông tin
        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                lblCheck.Text = "Vui lòng nhập địa chỉ Email của bạn!";
                return;
            }

            try
            {
                await supabaseService.InitializeAsync(); // Khởi tạo kết nối tới Supabase
                var userInfos = await supabaseService.GetUserInfosAsync(); // Lấy danh sách người dùng từ Supabase

                if (userInfos.Any(u => u.email == tbEmail.Text)) // Kiểm tra email đã tồn tại chưa, nếu rồi thì thông báo
                {
                    lblCheck.Text = "Email đã tồn tại!";
                    return;
                }

                // Nếu email chưa tồn tại, chuyển sang form đăng ký thông tin SignUpInfor
                SignUpInfor signUpInfor = new SignUpInfor(S, tbEmail.Text);
                S.pnLogin.Controls.Clear();
                S.pnLogin.Controls.Add(signUpInfor);
            }
            catch (Exception ex)
            {
                lblCheck.Text = "Lỗi: " + ex.Message;
            }
        }

        // Gọi hàm btnSignUp_Click khi nhấn phím Enter trong textbox tbEmail
        private void tbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignUp_Click(sender, e);
            }
        }

        // Hàm để đóng form đăng ký
        private void btnClose_Click(object sender, EventArgs e)
        {
            S.Close();
        }

        private async void btnSignUpGoogle_Click(object sender, EventArgs e)
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
                    await supabaseService.InitializeAsync();
                    var userInfos = await supabaseService.GetUserInfosAsync();

                    // Kiểm tra email đã tồn tại chưa
                    if (userInfos.Any(u => u.email == email))
                    {
                        this.Invoke(new Action(() =>
                        {
                            lblCheck.Text = "Email đã tồn tại!";
                            S.BringToFront(); // Đảm bảo form chính hiển thị lại
                            S.Activate();     // Kích hoạt form
                        }));
                        return;
                    }

                    // Nếu email chưa tồn tại, chuyển sang form SignUpInfor để nhập thêm thông tin
                    SignUpInfor signUpInfor = new SignUpInfor(S, email);
                    S.pnLogin.Controls.Clear();
                    S.pnLogin.Controls.Add(signUpInfor);

                    // Đảm bảo form chính hiển thị lại
                    this.Invoke(new Action(() =>
                    {
                        S.BringToFront();
                        S.Activate();
                    }));
                }
            }
            catch (Exception ex)
            {
                lblCheck.Text = "Lỗi đăng ký Google: " + ex.Message;
            }
        }
    }
}