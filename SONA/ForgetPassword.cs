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
using System.IO;
using System.Net.Sockets;

namespace SONA
{
    public partial class ForgetPassword: UserControl
    {
        SONA S;
        public ForgetPassword(SONA s)
        {
            InitializeComponent();
            S = s;
        }

        // Hàm kiểm tra mật khẩu có hợp lệ hay không
        private bool CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            bool checkNum = false;
            bool checkLetter = false;
            bool checkSpecial = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                    checkNum = true;
                else if (char.IsLetter(password[i]))
                    checkLetter = true;
                else if (password[i] == '@' || password[i] == '#' || password[i] == '!' || password[i] == '?')
                    checkSpecial = true;
            }

            if (!checkNum || !checkLetter || !checkSpecial)
            {
                return false;
            }

            return true;
        }

        // Phương thức yêu cầu mã OTP từ Server
        private void getOTP()
        {
            lblCheckEmail.Text = lblCheckOTP.Text = lblCheckConfirmPass.Text = "";
            lblCheckPass.ForeColor = Color.FromArgb(102, 102, 102);

            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                lblCheckEmail.Text = "Vui lòng nhập địa chỉ Email của bạn!";
                return;
            }

            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("forgetPassword");
                    writer.Write("email");
                    writer.Write(tbEmail.Text);
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        lblCheckOTP.Text = "Mã OTP đã được gửi tới email của bạn!";
                    }
                    else
                    {
                        lblCheckEmail.Text = response;
                    }
                    S.Activate();
                }
            }
            catch (Exception ex)
            {
                lblCheckEmail.Text = "Lỗi: " + ex.Message;
            }
        }

        // Phương thức yêu cầu mã OTP mới từ Server
        private void btnRefreshOTP_Click(object sender, EventArgs e)
        {
            lblCheckEmail.Text = lblCheckOTP.Text = lblCheckConfirmPass.Text = "";
            lblCheckPass.ForeColor = Color.FromArgb(102, 102, 102);
            
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                lblCheckEmail.Text = "Vui lòng nhập địa chỉ Email của bạn!";
                return;
            }

            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("forgetPassword");
                    writer.Write("refreshOTP");
                    writer.Write(tbEmail.Text);
                    
                    string response = reader.ReadString();
                    lblCheckOTP.Text = response;
                    S.Activate();
                }
            }
            catch (Exception ex)
            {
                lblCheckEmail.Text = "Lỗi: " + ex.Message;
            }
        }

        // Phương thức đặt mật khẩu mới cho người dùng và cập nhật cho Server
        private void setNewPassword()
        {
            lblCheckEmail.Text = lblCheckOTP.Text = lblCheckConfirmPass.Text = "";
            lblCheckPass.ForeColor = Color.FromArgb(102, 102, 102);

            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                lblCheckEmail.Text = "Vui lòng nhập địa chỉ Email của bạn!";
                return;
            }

            if (string.IsNullOrEmpty(tbOTP.Text))
            {
                lblCheckOTP.Text = "Vui lòng nhập mã OTP!";
                return;
            }

            if (!CheckPassword(tbPass.Text))
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

            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("forgetPassword");
                    writer.Write("setPassword");
                    writer.Write(tbEmail.Text);
                    writer.Write(tbOTP.Text);
                    writer.Write(tbPass.Text);
                    
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        Login login = new Login(S);
                        S.pnLogin.Controls.Clear();
                        S.pnLogin.Controls.Add(login);
                    }
                    else
                    {
                        lblCheckOTP.Text = response;
                    }
                    S.Activate();
                }
            }
            catch (Exception ex)
            {
                lblCheckOTP.Text = "Lỗi: " + ex.Message;
            }
        }

        // Hàm quay lại form đăng nhập Login
        private void lblLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login(S);
            S.pnLogin.Controls.Clear();
            S.pnLogin.Controls.Add(login);
        }

        private void ForgetPassword_Load(object sender, EventArgs e)
        {
            lblCheckEmail.Text = lblCheckOTP.Text = lblCheckConfirmPass.Text = "";
            lblCheckPass.ForeColor = Color.FromArgb(102, 102, 102);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            setNewPassword();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            getOTP();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            S.Close();
        }
    }
}
