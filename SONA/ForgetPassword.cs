using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace SONA
{
    public partial class ForgetPassword: UserControl
    {
        SONA S;
        private SupabaseService supabaseService;
        private string generatedOTP; // Lưu mã OTP đã gửi
        private DateTime lastOTPSentTime; // Lưu thời gian gửi OTP cuối cùng
        private DateTime otpCreatedTime; // Lưu thời gian tạo OTP
        private const int OTPResendCooldown = 60; // Giới hạn thời gian gửi là 60 giây
        private const int OTPExpirationMinutes = 5; // OTP hết hạn sau 5 phút
        public ForgetPassword(SONA s)
        {
            InitializeComponent();
            S = s;
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
                var smtpClient = new SmtpClient("smtp.gmail.com") // Đối tượng sử dụng Gmail SMTP server
                {
                    Port = 587, // Cổng SMTP cho Gmail
                    Credentials = new NetworkCredential("sona.feelthemusic@gmail.com", "sxiz nqtc ddko izzj"), // Thông tin của gmail Server dùng để gửi mail
                    EnableSsl = true, // Bật SSL
                };

                var mailMessage = new MailMessage // Tạo đối tượng MailMessage để gửi email với nội dung
                {
                    From = new MailAddress("sona.feelthemusic@gmail.com"), // Địa chỉ email gửi đi
                    Subject = "Mã OTP xác nhận đổi mật khẩu tài khoản SONA", // Tiêu đề email
                    Body = $"Mã OTP của bạn là: <strong>{otp}</strong><br>Vui lòng nhập mã này để hoàn tất đăng ký. Mã có hiệu lực trong {OTPExpirationMinutes} phút.", // Nội dung email chứa mã OTP
                    IsBodyHtml = true, // Cho phép định dạng HTML
                };
                mailMessage.To.Add(email); // Địa chỉ email nhận

                await smtpClient.SendMailAsync(mailMessage); // Gửi email bất đồng bộ
                lastOTPSentTime = DateTime.Now; // Lưu thời gian gửi OTP
                otpCreatedTime = DateTime.Now; // Lưu thời gian tạo OTP
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async void btnRefreshOTP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                lblCheckOTP.Text = "Vui lòng nhập địa chỉ Email của bạn!";
                return;
            }

            try
            {
                TimeSpan timeSinceLastSent = DateTime.Now - lastOTPSentTime; // Kiểm tra thời gian gửi lại
                if (timeSinceLastSent.TotalSeconds < OTPResendCooldown) // Nếu thời gian gửi lại chưa đủ 60 giây sẽ thông báo
                {
                    lblCheckOTP.Text = $"Vui lòng chờ {Math.Ceiling(OTPResendCooldown - timeSinceLastSent.TotalSeconds)} giây trước khi gửi lại!";
                    return;
                }

                // Tạo và gửi mã OTP mới
                generatedOTP = GenerateOTP();
                await SendOTPEmail(tbEmail.Text, generatedOTP);
                lblCheckOTP.Text = "Mã OTP mới đã được gửi tới email của bạn!";
            }
            catch (Exception ex)
            {
                lblCheckOTP.Text = "Lỗi: " + ex.Message;
            }
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login(S);
            S.pnLogin.Controls.Clear();
            S.pnLogin.Controls.Add(login);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            S.Close();
        }

        private void ForgetPassword_Load(object sender, EventArgs e)
        {
            lblCheckEmail.Text = lblCheckOTP.Text = lblCheckConfirmPass.Text = "";
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            lblCheckPass.ForeColor = Color.FromArgb(102, 102, 102);
            lblCheckEmail.Text = lblCheckOTP.Text = lblCheckConfirmPass.Text = "";

            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                lblCheckEmail.Text = "Vui lòng nhập địa chỉ Email của bạn!";
                return;
            }
            try
            {
                // Kiểm tra email trên Supabase bằng cách lấy đối tượng email từ table users và so sánh
                supabaseService = new SupabaseService();
                await supabaseService.InitializeAsync();
                var userInfos = await supabaseService.GetUserInfosAsync();

                var user = userInfos.FirstOrDefault(u => u.email == tbEmail.Text);
                if (user == null)
                {
                    lblCheckEmail.Text = "Tài khoản Email chưa được tạo!";
                    return;
                }

                // Nếu chưa gửi OTP lần nào thì thực hiện gửi OTP
                if (generatedOTP == null)
                {
                    generatedOTP = GenerateOTP();
                    await SendOTPEmail(tbEmail.Text, generatedOTP);
                    lblCheckOTP.Text = "Mã OTP đã được gửi tới email của bạn!";
                    return;
                }

                // Kiểm tra mã OTP có được nhập không
                if (string.IsNullOrEmpty(tbOTP.Text))
                {
                    lblCheckOTP.Text = "Vui lòng nhập mã OTP của bạn!";
                    return;
                }

                // Kiểm tra thời gian hiệu lực OTP bằng cách so sánh thời gian hiện tại với thời gian tạo OTP có lớn hơn 5 phút không
                if ((DateTime.Now - otpCreatedTime).TotalMinutes > OTPExpirationMinutes)
                {
                    lblCheckOTP.Text = "Mã OTP đã hết hạn! Vui lòng yêu cầu mã mới.";
                    generatedOTP = null; // Reset để yêu cầu gửi lại
                    return;
                }

                // Kiểm tra mã OTP có khớp không
                if (tbOTP.Text != generatedOTP)
                {
                    lblCheckOTP.Text = "Mã OTP không chính xác!";
                    return;
                }

                // Kiểm tra mật khẩu có phù hợp với yêu cầu không
                bool checkNum = false;
                bool checkLetter = false;
                bool checkSpecial = false;

                for (int i = 0; i < tbPass.Text.Length; i++)
                {
                    if (char.IsDigit(tbPass.Text[i]))
                        checkNum = true;
                    else if (char.IsLetter(tbPass.Text[i]))
                        checkLetter = true;
                    else if (tbPass.Text[i] == '@' || tbPass.Text[i] == '#' || tbPass.Text[i] == '!' || tbPass.Text[i] == '?')
                        checkSpecial = true;
                }

                if (!checkNum || !checkLetter || !checkSpecial)
                {
                    lblCheckPass.ForeColor = Color.Red;
                    return;
                }

                if (string.IsNullOrEmpty(tbConfirmPass.Text))
                {
                    lblCheckConfirmPass.Text = "Vui lòng xác nhận mật khẩu!";
                    return;
                }

                if (tbPass.Text != tbConfirmPass.Text)
                {
                    lblCheckConfirmPass.Text = "Mật khẩu nhập lại chưa chính xác!";
                    return;
                }

                // Cập nhật mật khẩu mới vào Supabase
                await supabaseService.UpdateUserPasswordAsync(tbEmail.Text, tbPass.Text);

                // Nếu tất cả thông tin hợp lệ, chuyển sang form Login để đăng nhập lại
                Login login = new Login(S);
                S.pnLogin.Controls.Clear();
                S.pnLogin.Controls.Add(login);
                generatedOTP = null; // Reset OTP sau khi thay đổi mật khẩu thành công
            }
            catch (Exception ex)
            {
                lblCheckEmail.Text = "Lỗi: " + ex.Message;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnConfirm_Click(sender, e);
        }

        private void tbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm_Click(sender, e);
            }
        }

        private void tbOTP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm_Click(sender, e);
            }
        }

        private void tbPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm_Click(sender, e);
            }
        }

        private void tbConfirmPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm_Click(sender, e);
            }
        }
    }
}
