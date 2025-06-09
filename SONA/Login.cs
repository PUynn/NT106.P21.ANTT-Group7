using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Sockets;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Threading;

namespace SONA
{
    public partial class Login : UserControl
    {
        SONA S;
        private bool isPasswordVisible = false; // Biến trạng thái để theo dõi mật khẩu đang hiển thị hay không

        public Login(SONA s)
        {
            InitializeComponent();
            S = s;
        }

        // Phương thức mở form SignUp khi nhấn đăng ký
        private void lbDangky_Click(object sender, EventArgs e)
        {
            SignUp l = new SignUp(S);
            S.pnLogin.Controls.Clear();
            S.pnLogin.Controls.Add(l);
        }

        // Phương thức yêu cầu đăng nhập bằng Google
        private async void btnLoginGoogle_Click(object sender, EventArgs e)
        {
            lblCheck.Text = "";
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
                    string userEmail = userInfo.Email;

                    using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                    using (NetworkStream stream = client.GetStream())
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        writer.Write("loginGoogle");
                        writer.Write(userEmail);
                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            S.ShowHome(userEmail);
                            S.Activate();
                        }
                        else
                        {
                            lblCheck.Text = response;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblCheck.Text = "Lỗi đăng nhập: " + ex.Message;
            }
        }

        // Phương thức yêu cầu đăng nhập với email và mật khẩu
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            lblCheck.Text = "";
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
                    writer.Write("loginUser");
                    writer.Write(tbEmail.Text);
                    writer.Write(tbPass.Text);
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        S.ShowHome(tbEmail.Text);
                        S.Activate();
                    }
                    else
                    {
                        lblCheck.Text = response;
                    }
                }
            }
            catch (Exception ex)
            {
                lblCheck.Text = "Lỗi: " + ex.Message;
            }
        }

        // Phương thức mở form ForgetPassword khi nhấn quên mật khẩu
        private void lbQuenmatkhau_Click(object sender, EventArgs e)
        {
            ForgetPassword forgetPassword = new ForgetPassword(S);
            S.pnLogin.Controls.Clear();
            S.pnLogin.Controls.Add(forgetPassword);
        }

        // Hàm hiển thị hay ẩn mật khẩu
        private void pnViewPass_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible; // Đảo ngược trạng thái hiển thị mật khẩu
            tbPass.UseSystemPasswordChar = !isPasswordVisible; // Cập nhật thuộc tính UseSystemPasswordChar của tbPass

            // Thay đổi nội dung của lbViewPassword để phản ánh trạng thái
            lbViewPassword.Text = !isPasswordVisible ? "Ẩn" : "Hiện";
            pnViewPass.BackgroundImage = !isPasswordVisible ? Properties.Resources.icons8_hide_30 : Properties.Resources.Show;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            S.Close();
        }
    }
}