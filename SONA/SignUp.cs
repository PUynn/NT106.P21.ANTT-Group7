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
using System.Net.Mail;
using System.Net;

namespace SONA
{
    public partial class SignUp : UserControl
    {
        SONA S;
        private SupabaseService supabaseService;
        private string generatedOTP; // Lưu mã OTP đã gửi
        private DateTime lastOTPSentTime; // Lưu thời gian gửi OTP cuối cùng
        private DateTime otpCreatedTime; // Lưu thời gian tạo OTP
        private const int OTPResendCooldown = 60; // Giới hạn 60 giây
        private const int OTPExpirationMinutes = 5; // OTP hết hạn sau 5 phút

        public SignUp(SONA s)
        {
            InitializeComponent();
            S = s;
            supabaseService = new SupabaseService();
            lastOTPSentTime = DateTime.MinValue;
        }

        // Hàm tạo mã OTP ngẫu nhiên (6 chữ số)
        private string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        // Hàm gửi email chứa mã OTP
        private async Task SendOTPEmail(string email, string otp)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("sona.feelthemusic@gmail.com", "sxiz nqtc ddko izzj"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("sona.feelthemusic@gmail.com"), // Phải khớp với email trong Credentials
                    Subject = "Mã OTP xác nhận đăng ký tài khoản SONA",
                    Body = $"Mã OTP của bạn là: <strong>{otp}</strong><br>Vui lòng nhập mã này để hoàn tất đăng ký. Mã có hiệu lực trong {OTPExpirationMinutes} phút.",
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);
                lastOTPSentTime = DateTime.Now;
                otpCreatedTime = DateTime.Now; // Lưu thời gian tạo OTP
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        // Hàm kiểm tra và xử lý đăng ký
        private async void SignUpEnter()
        {
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                lblCheck.Text = "Vui lòng nhập địa chỉ Email của bạn!";
                return;
            }

            try
            {
                // Kiểm tra email trên Supabase
                await supabaseService.InitializeAsync();
                var userInfos = await supabaseService.GetUserInfosAsync();

                if (userInfos.Any(u => u.email == tbEmail.Text))
                {
                    lblCheck.Text = "Email đã tồn tại!";
                    return;
                }

                // Nếu chưa gửi OTP lần nào, gửi OTP
                if (generatedOTP == null)
                {
                    generatedOTP = GenerateOTP();
                    await SendOTPEmail(tbEmail.Text, generatedOTP);
                    lblCheck.Text = "Mã OTP đã được gửi tới email của bạn!";
                    return;
                }

                // Kiểm tra mã OTP
                if (string.IsNullOrEmpty(tbOTP.Text))
                {
                    lblCheck.Text = "Vui lòng nhập mã OTP của bạn!";
                    return;
                }

                // Kiểm tra thời gian hiệu lực OTP
                if ((DateTime.Now - otpCreatedTime).TotalMinutes > OTPExpirationMinutes)
                {
                    lblCheck.Text = "Mã OTP đã hết hạn! Vui lòng yêu cầu mã mới.";
                    generatedOTP = null; // Reset để yêu cầu gửi lại
                    return;
                }

                // Kiểm tra mã OTP có khớp không
                if (tbOTP.Text != generatedOTP)
                {
                    lblCheck.Text = "Mã OTP không chính xác!";
                    return;
                }

                // Nếu OTP hợp lệ, chuyển sang form SignUpInfor
                SignUpInfor signUpInfor = new SignUpInfor(S, tbEmail.Text);
                S.pnLogin.Controls.Clear();
                S.pnLogin.Controls.Add(signUpInfor);
                generatedOTP = null; // Reset OTP sau khi đăng ký thành công
            }
            catch (Exception ex)
            {
                lblCheck.Text = "Lỗi: " + ex.Message;
            }
        }

        private void tbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SignUpEnter();
            }
        }

        private void tbOTP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SignUpEnter();
            }
        }

        private async void btnRefreshOTP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                lblCheck.Text = "Vui lòng nhập địa chỉ Email của bạn!";
                return;
            }

            try
            {
                // Kiểm tra thời gian gửi lại
                TimeSpan timeSinceLastSent = DateTime.Now - lastOTPSentTime;
                if (timeSinceLastSent.TotalSeconds < OTPResendCooldown)
                {
                    lblCheck.Text = $"Vui lòng chờ {Math.Ceiling(OTPResendCooldown - timeSinceLastSent.TotalSeconds)} giây trước khi gửi lại!";
                    return;
                }

                // Tạo và gửi mã OTP mới
                generatedOTP = GenerateOTP();
                await SendOTPEmail(tbEmail.Text, generatedOTP);
                lblCheck.Text = "Mã OTP mới đã được gửi tới email của bạn!";
            }
            catch (Exception ex)
            {
                lblCheck.Text = "Lỗi: " + ex.Message;
            }
        }

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

                    await supabaseService.InitializeAsync();
                    var userInfos = await supabaseService.GetUserInfosAsync();

                    if (userInfos.Any(u => u.email == email))
                    {
                        this.Invoke(new Action(() =>
                        {
                            lblCheck.Text = "Email đã tồn tại!";
                            S.BringToFront();
                            S.Activate();
                        }));
                        return;
                    }

                    SignUpInfor signUpInfor = new SignUpInfor(S, email);
                    S.pnLogin.Controls.Clear();
                    S.pnLogin.Controls.Add(signUpInfor);

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