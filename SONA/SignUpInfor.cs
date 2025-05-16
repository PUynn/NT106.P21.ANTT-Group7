using System;
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
        SONA S;
        DataRow dr;
        private SupabaseService supabaseService;
        string srcEmail;

        public SignUpInfor(SONA s, string email)
        {
            InitializeComponent();
            S = s;
            srcEmail = email;
            supabaseService = new SupabaseService();
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

        // Hàm đóng cửa sổ
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            S.Close();
        }

        // Hàm chuyển sang form đăng nhập
        private void lblLogin_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp(S);
            S.pnLogin.Controls.Clear();
            S.pnLogin.Controls.Add(signUp);
        }

        // Hàm để chọn ảnh đại diện bằng cách mở file ảnh trong thư mục
        private void setAvatar()
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    // Chuyển đổi ảnh thành base64 để lưu vào Supabase
            //    using (var ms = new MemoryStream())
            //    {
            //        Image.FromFile(openFileDialog.FileName).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //        string base64Image = Convert.ToBase64String(ms.ToArray());
            //        btnAvatar.Image = Image.FromFile(openFileDialog.FileName); // Hiển thị ảnh
            //    }
            //}
        }

        private void btnAvatar_Click(object sender, EventArgs e)
        {
            setAvatar();
        }

        private void lblAvatar_Click(object sender, EventArgs e)
        {
            setAvatar();
        }

        private void SignUpInfor_Load(object sender, EventArgs e)
        {
            lblCheckName.Text = lblCheckSdt.Text = lblCheckConfirm.Text = "";
            lblcheckPass.ForeColor = Color.FromArgb(102, 102, 102);
        }

        // Các hàm gọi hàm btnSignUp_Click khi nhấn phím Enter trong các textbox
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

        // Hàm để kiểm tra thông tin đăng ký và thêm vào cơ sở dữ liệu
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (checkSignUpInfor())
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("signupInfo");
                    writer.Write(tbUser.Text); // Ghi tên người dùng vào luồng
                    writer.Write(tbPass.Text);
                    writer.Write(tbSdt.Text);
                    writer.Write(srcEmail);
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        S.ShowHome(srcEmail);
                    }
                    else
                    {
                        lblCheckSdt.Text = response;
                    }
                }
            }
        }
    }
}