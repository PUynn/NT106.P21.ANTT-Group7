﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Dsp;
using System.Net.Http;
using System.IO;
using System.Net.Sockets;

namespace SONA
{
    public partial class SignUpInfor : UserControl
    {
        private SONA S;
        private string emailUser;
        private string avatarPath = null; // Lưu đường dẫn ảnh tạm thời
        private bool hasCustomAvatar = false; // Kiểm tra xem người dùng có chọn ảnh không

        public SignUpInfor(SONA s, string email)
        {
            InitializeComponent();
            S = s;
            emailUser = email;
        }

        // Hàm kiểm tra thông tin đăng nhập và báo lỗi nếu không hợp lệ
        private bool checkSignUpInfor()
        {
            // Đặt các giá trị mặc định ban đầu cho các label thông báo
            lblCheckName.Text = lblCheckSdt.Text = lblCheckConfirm.Text = "";
            lblcheckPass.ForeColor = Color.FromArgb(102, 102, 102);

            // Kiểm tra các trường thông tin có trống hay không
            if (string.IsNullOrEmpty(tbUser.Text))
            {
                lblCheckName.Text = "Tên người dùng không được để trống!";
                return false;
            }

            if (string.IsNullOrEmpty(tbSdt.Text))
            {
                lblCheckSdt.Text = "Vui lòng nhập số điện thoại!";
                return false;
            }

            for (int i = 0; i < tbSdt.Text.Length; i++)
            {
                if (!char.IsDigit(tbSdt.Text[i]))
                {
                    lblCheckSdt.Text = "Số điện thoại không hợp lệ!";
                    return false;
                }
            }

            if (string.IsNullOrEmpty(tbPass.Text))
            {
                lblcheckPass.ForeColor = Color.Red;
                return false;
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
                lblcheckPass.ForeColor = Color.Red;
                return false;
            }

            if (string.IsNullOrEmpty(tbConfirm.Text))
            {
                lblCheckConfirm.Text = "Vui lòng xác nhận mật khẩu!";
                return false;
            }

            if (tbPass.Text != tbConfirm.Text)
            {
                lblCheckConfirm.Text = "Mật khẩu nhập lại chưa chính xác!";
                return false;
            }

            return true;
        }

        // Hàm để yêu cầu Server thêm người dùng mới đăng kí vào cơ sở dữ liệu
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (checkSignUpInfor())
            {
                try
                {
                    using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                    using (NetworkStream stream = client.GetStream())
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        writer.Write("signupInfo");
                        writer.Write(tbUser.Text);
                        writer.Write(tbPass.Text);
                        writer.Write(tbSdt.Text);
                        writer.Write(emailUser);

                        if (hasCustomAvatar && avatarPath != null)
                        {
                            writer.Write("hasAvatar");
                            using (var fs = new FileStream(avatarPath, FileMode.Open, FileAccess.Read))
                            {
                                byte[] imageData = new byte[fs.Length];
                                fs.Read(imageData, 0, imageData.Length);
                                writer.Write(imageData.Length);
                                writer.Write(imageData);
                            }
                        }
                        else
                        {
                            writer.Write("noAvatar");
                        }

                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            S.ShowHome(emailUser);
                        }
                        else
                        {
                            lblCheckName.Text = response;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblCheckName.Text = "Lỗi: " + ex.Message;
                }
            }
        }

        // Hàm quay lại form đăng nhập
        private void lblLogin_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp(S);
            S.pnLogin.Controls.Clear();
            S.pnLogin.Controls.Add(signUp);
        }

        // Hàm để chọn ảnh đại diện bằng cách mở file ảnh trong thư mục
        private void setAvatar()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                cpbAvatar.Image = Image.FromFile(openFileDialog.FileName);
                avatarPath = openFileDialog.FileName; // Lưu đường dẫn ảnh
                hasCustomAvatar = true; // Đánh dấu ảnh được chọn
            }
        }

        private void SignUpInfor_Load(object sender, EventArgs e)
        {
            lblCheckName.Text = lblCheckSdt.Text = lblCheckConfirm.Text = "";
            lblcheckPass.ForeColor = Color.FromArgb(102, 102, 102);
        }

        private void lblAvatar_Click(object sender, EventArgs e)
        {
            setAvatar();
        }

        private void cpbAvatar_Click(object sender, EventArgs e)
        {
            setAvatar();
        }

        private void tbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignUp_Click(sender, e);
            }
        }

        private void tbSdt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignUp_Click(sender, e);
            }
        }

        private void tbPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignUp_Click(sender, e);
            }
        }

        private void tbConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignUp_Click(sender, e);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            S.Close();
        }
    }
}