using Guna.UI2.WinForms;
using System;
using System.IO;
using System.Windows.Forms;
using System.Net.Sockets;

namespace SONA
{
    public partial class SignUp : UserControl
    {
        SONA S;
        public SignUp(SONA s)
        {
            InitializeComponent();
            S = s;
        }

        // Phương thức quay lại form Login
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

        // Phương thức yêu cầu đăng ký bằng Google
        private void btnSignUpGoogle_Click(object sender, EventArgs e)
        {
            lblCheck.Text = "";
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("singupGoogle");
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        string email = reader.ReadString();
                        SignUpInfor signUpInfor = new SignUpInfor(S, email);
                        S.pnLogin.Controls.Clear();
                        S.pnLogin.Controls.Add(signUpInfor);
                    }
                    else
                    {

                        lblCheck.Text = response;
                    }
                    S.Activate();
                }
            }
            catch (Exception ex)
            {
                lblCheck.Text = "Lỗi: " + ex.Message;
            }
        }

        // Hàm lấy mã OTP từ Server
        private void getOTP()
        {
            lblCheck.Text = "";
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                lblCheck.Text = "Vui lòng nhập địa chỉ Email của bạn!";
                return;
            }

            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("signupUser");
                    writer.Write("email");
                    writer.Write(tbEmail.Text);
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        lblCheck.Text = "Mã OTP đã được gửi tới email của bạn!";
                    }
                    else
                    {
                        lblCheck.Text = response;
                    }
                    S.Activate();
                }
            }
            catch (Exception ex)
            {
                lblCheck.Text = "Lỗi: " + ex.Message;
            }
        }

        // Phương thức lấy mã OTP mới từ Server
        private void btnRefreshOTP_Click(object sender, EventArgs e)
        {
            lblCheck.Text = "";
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                lblCheck.Text = "Vui lòng nhập địa chỉ Email của bạn!";
                return;
            }
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("signupUser");
                    writer.Write("refreshOTP");
                    writer.Write(tbEmail.Text);

                    string response = reader.ReadString();
                    lblCheck.Text = response;
                    S.Activate();
                }
            }
            catch (Exception ex)
            {
                lblCheck.Text = "Lỗi: " + ex.Message;
            }
        }

        // Hàm xác nhận mã OTP từ Server
        private void confirmOTP()
        {
            lblCheck.Text = "";

            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                lblCheck.Text = "Vui lòng nhập địa chỉ Email của bạn!";
                return;
            }

            if (string.IsNullOrEmpty(tbOTP.Text))
            {
                lblCheck.Text = "Vui lòng nhập mã OTP!";
                return;
            }
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("signupUser");
                    writer.Write("otp");
                    writer.Write(tbEmail.Text);
                    writer.Write(tbOTP.Text);
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        SignUpInfor signUpInfor = new SignUpInfor(S, tbEmail.Text);
                        S.pnLogin.Controls.Clear();
                        S.pnLogin.Controls.Add(signUpInfor);
                    }
                    else
                    {
                        lblCheck.Text = response;
                    }
                    S.Activate();
                }
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

        private void tbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getOTP();
            }
        }

        private void tbOTP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                confirmOTP();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            getOTP();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            confirmOTP();
        }
    }
}