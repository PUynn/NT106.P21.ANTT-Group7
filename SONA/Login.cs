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

namespace SONA
{
    public partial class Login : UserControl
    {
        private const string AppId = "984538890449740";
        private const string AppSecret = "1f3490111b9ddddbf4010a67954a1522";
        private const string RedirectUri = "http://localhost:8000/facebook-signin";
        private const string AuthUrl = "https://www.facebook.com/v20.0/dialog/oauth?client_id={0}&redirect_uri={1}&response_type=code&scope=public_profile";
        SONA S;
        ConnectSQL connectSQL;

        private HttpListener httpListener;

        public Login(SONA s)
        {
            InitializeComponent();
            S = s;
        }

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
                    this.Invoke(new Action(() =>
                    {
                        OpenHomeForm();
                        S.Activate();
                    }));
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
                connectSQL = new ConnectSQL();
                string queryEmail = $"SELECT * FROM USERS WHERE EMAIL = '{tbEmail.Text}'";
                DataTable dt = connectSQL.Query(queryEmail);

                if (dt.Rows.Count > 0)
                {
                    string password = dt.Rows[0]["PASSWORD_TK"].ToString();
                    if (password == tbPass.Text)
                    {
                        S.Activate();
                        OpenHomeForm();
                    }
                    else
                        lblCheck.Text = "Mật khẩu không chính xác!";
                }
                else
                    lblCheck.Text = "Email không tồn tại!";
            }
            catch (Exception ex)
            {
                lblCheck.Text = "Lỗi đăng nhập: " + ex.Message;
            }
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
    }
}