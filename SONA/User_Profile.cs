using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class User_Profile : UserControl
    {
        SONA S;
        private string idUser;
        private string name_user, email, phone_number, password, created_at;

        public User_Profile(SONA s, string idUser)
        {
            InitializeComponent();
            this.idUser = idUser;
            S = s;
            LoadUserDataAsync();
        }

        bool isPasswordVerified = false;

        private void tbResetPassword_Click(object sender, EventArgs e)
        {
            if (isPasswordVerified)
            {
                tbResetPassword.ReadOnly = false;
                tbResetPassword.Focus();
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập mật khẩu hiện tại để tiếp tục", "Xác thực", "");

            if (string.IsNullOrEmpty(input))
            {
                // Người dùng nhấn Cancel hoặc để trống → không hiện lỗi, không làm gì
                return;
            }

            if (input != password) // password đã lấy từ Supabase
            {
                MessageBox.Show("Mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                isPasswordVerified = true;

                tbResetPassword.ReadOnly = false;
                tbResetPassword.Focus();

                // ✅ Bây giờ mới cho nhập Confirm Password
                tbConfirmPassword.ReadOnly = false;
                tbConfirmPassword.BackColor = Color.White; // Nếu bị xám trước đó
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string newName = tbNameUser.Text.Trim();
            string newPassword = tbResetPassword.Text.Trim();
            string confirmPassword = tbConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Tên người dùng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isPasswordVerified)
            {
                MessageBox.Show("Vui lòng xác thực mật khẩu trước khi thay đổi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (TcpClient client = new TcpClient())
                {
                    await client.ConnectAsync(IPAddressServer.serverIP, 5000);
                    using (NetworkStream stream = client.GetStream())
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        writer.Write("updateUserProfile");
                        writer.Write(idUser);
                        writer.Write(newName);
                        writer.Write(newPassword);

                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            password = newPassword; // Cập nhật lại biến password hiện tại
                            isPasswordVerified = false;
                            tbResetPassword.ReadOnly = true;
                            tbConfirmPassword.ReadOnly = true;
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi cập nhật: " + response, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối tới server: " + ex.Message);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private async void LoadUserDataAsync()
        {
            await getUserDataAsync();
            displayUserData();
        }

        private async Task getUserDataAsync()
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    await client.ConnectAsync(IPAddressServer.serverIP, 5000);
                    using (NetworkStream stream = client.GetStream())
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        writer.Write("getUserProfile");
                        writer.Write(idUser);
                        string response = reader.ReadString();

                        if (response == "OK")
                        {
                            name_user = reader.ReadString();
                            email = reader.ReadString();
                            phone_number = reader.ReadString();
                            password = reader.ReadString();
                            created_at = reader.ReadString();
                        }
                        else
                        {
                            MessageBox.Show(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private void displayUserData()
        {
            tbNameUser.Text = name_user;
            tbEmail.Text = email;
            tbSDT.Text = string.IsNullOrEmpty(phone_number) ? "Chưa cập nhật" : phone_number;
            tbCreated.Text = created_at;
            tbResetPassword.Text = password;
            tbResetPassword.UseSystemPasswordChar = true; // Ẩn mật khẩu
            tbConfirmPassword.Text = password;
            tbConfirmPassword.UseSystemPasswordChar = true; // Ẩn mật khẩu
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            S.ShowLogin();
        }

    }
}
