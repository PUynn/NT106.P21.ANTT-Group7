using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using Supabase.Gotrue;
using System.Text.RegularExpressions;
using SONA;
using System.IO;
using System.Net.Sockets;
using NAudio.Wave;
using System.Net.Http;

namespace SONA
{
    public partial class UserInfor : UserControl
    {
        private string idUser;
        private string avatarPath = null; // Lưu đường dẫn ảnh tạm thời
        private bool hasCustomAvatar = false; // Kiểm tra xem người dùng có chọn ảnh không
        private SONA S;

        public UserInfor(SONA s, string idUser)
        {
            S = s;
            this.idUser = idUser;
            InitializeComponent();
            getUserInfor();
            getAvatarUser();
        }

        private void getUserInfor()
        {
            lblCheckName.Text = lblCheckSdt.Text = lblCheckEmail.Text = lblCheckConfirm.Text = lblStatus.Text = "";
            lblcheckPass.ForeColor = Color.FromArgb(137, 137, 137);

            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getUserInfor");
                    writer.Write(idUser);
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        tbNameUser.Text = lblNameUser.Text = reader.ReadString();
                        tbEmail.Text = lblEmail.Text = reader.ReadString();
                        tbSdt.Text = reader.ReadString();
                        tbPass.Text =tbConfirmPass.Text = reader.ReadString();
                    }
                    else
                    {
                        MessageBox.Show(response);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private async void getAvatarUser()
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getAvatarUser");
                    writer.Write(idUser);

                    string response = reader.ReadString(); // Nhận phản hồi từ server
                    if (response == "OK")
                    {
                        string pictureUrl = reader.ReadString(); // Lấy đường dẫn URL của hình ảnh trên supabase
                        if (!string.IsNullOrEmpty(pictureUrl))  // Nếu có tồn tại đường dẫn tới file hình ảnh
                        {
                            using (var htppClient = new HttpClient()) // Tạo HttpClient để tải hình ảnh
                            {
                                var imageData = await htppClient.GetByteArrayAsync(pictureUrl); // Tải hình ảnh từ URL bằng phương thức GetByteArrayAsync
                                using (var ms = new MemoryStream(imageData)) // Tạo MemoryStream dể lấy dữ liệu hình ảnh
                                {
                                    cpbAvatar.Image = Image.FromStream(ms); // Chuyển đổi MemoryStream thành Image
                                }
                            }
                        }
                        else
                        {
                            cpbAvatar.Image = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show(response);
                        cpbAvatar.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

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

        private bool checkUserInfo()
        {
            lblCheckName.Text = lblCheckSdt.Text = lblCheckEmail.Text = lblCheckConfirm.Text = lblStatus.Text = "";
            lblcheckPass.ForeColor = Color.FromArgb(137, 137, 137);

            if (string.IsNullOrWhiteSpace(tbNameUser.Text))
            {
                lblCheckName.Text = "Tên người dùng không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbSdt.Text))
            {
                lblCheckSdt.Text = "Số điện thoại không được để trống!";
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

            if (string.IsNullOrWhiteSpace(tbPass.Text))
            {
                lblcheckPass.ForeColor = Color.Red;
                return false;
            }

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
            if (string.IsNullOrWhiteSpace(tbConfirmPass.Text))
            {
                lblCheckConfirm.Text = "Vui lòng xác nhận mật khẩu!";
                return false;
            }
            if (tbPass.Text != tbConfirmPass.Text)
            {
                lblCheckConfirm.Text = "Mật khẩu nhập lại chưa chính xác!";
                return false;
            }

            return true;
        }

        private void cpbAvatar_Click(object sender, EventArgs e)
        {
            setAvatar();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!checkUserInfo()) return;

            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("updateUserInfor");
                    writer.Write(tbEmail.Text);
                    writer.Write(tbNameUser.Text);
                    writer.Write(tbSdt.Text);
                    writer.Write(tbPass.Text);

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
                        getAvatarUser();
                        getUserInfor();
                        lblStatus.Text = "Cập nhật thông tin thành công!";
                    }
                    else if (response == "Số điện thoại đã tồn tại!")
                        lblCheckSdt.Text = response;
                    else
                        lblStatus.Text = response;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getUserInfor();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            S.ShowLogin();
        }
    }
}