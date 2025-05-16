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
using System.Net.Sockets;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            S.Close();
        }

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
                        string srcEmail = reader.ReadString();
                        S.Activate();
                        SignUpInfor signUpInfor = new SignUpInfor(S, srcEmail);
                        S.pnLogin.Controls.Clear();
                        S.pnLogin.Controls.Add(signUpInfor);      
                    }
                    else
                    {
                        S.Activate();
                        lblCheck.Text = response;
                    }
                }
            }
            catch (Exception ex)
            {
                lblCheck.Text = "Lỗi: " + ex.Message;
            }
        }

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