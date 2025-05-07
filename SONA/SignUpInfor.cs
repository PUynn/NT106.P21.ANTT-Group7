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
using System.Diagnostics.Eventing.Reader;

namespace SONA
{
    public partial class SignUpInfor : UserControl
    {
        SONA S;
        ConnectSQL connectSQL;
        string srcEmail;

        public SignUpInfor(SONA s, string email)
        {
            InitializeComponent();
            S = s;
            srcEmail = email;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private bool checkSignUpInfor()
        {
            lblName.Text = lblSdt.Text = lblConfirm.Text = "";
            lblPass.ForeColor = Color.FromArgb(102, 102, 102);

            if (string.IsNullOrEmpty(tbUser.Text))
            {
                lblName.Text = "Tên người dùng không được để trống!";
                return false;
            }

            if (string.IsNullOrEmpty(tbSdt.Text))
            {
                lblSdt.Text = "Vui lòng nhập số điện thoại!";
                return false;
            }

            if (string.IsNullOrEmpty(tbPass.Text))
            {
                lblPass.ForeColor = Color.Red;
                return false;
            }

            for (int i = 0; i < tbSdt.Text.Length; i++)
            {
                if (!char.IsDigit(tbSdt.Text[i]))
                {
                    lblSdt.Text = "Số điện thoại không hợp lệ!";
                    return false;
                }
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
                lblPass.ForeColor = Color.Red;
                return false;
            }

            if (string.IsNullOrEmpty(tbConfirm.Text))
            {
                lblConfirm.Text = "Vui lòng xác nhận mật khẩu!";
                return false;
            }

            if (tbPass.Text != tbConfirm.Text)
            {
                lblConfirm.Text = "Mật khẩu nhập lại chưa chính xác!";
                return false;
            }

            return true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (checkSignUpInfor())
            {
                try
                {
                    connectSQL = new ConnectSQL();
                    string queryPhone = $"SELECT * FROM USERS WHERE SDT = '{tbSdt.Text}'";
                    DataTable dtb = connectSQL.Query(queryPhone);

                    if (dtb.Rows.Count > 0)
                    {
                        lblSdt.Text = "Số điện thoại đã tồn tại!";
                        return;
                    }

                    string queryInsert = $"INSERT INTO USERS (NAME_USER, SDT, EMAIL, PASSWORD_TK) VALUES ('{tbUser.Text}', '{tbSdt.Text}', '{srcEmail}', '{tbPass.Text}')";
                    connectSQL.ExecuteQuery(queryInsert);

                    S.ShowHome();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            S.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp(S);
            S.pnLogin.Controls.Clear();
            S.pnLogin.Controls.Add(signUp);
        }

        private void setAvatar()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                btnAvatar.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            setAvatar();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            setAvatar();
        }

        private void SignUpInfor_Load(object sender, EventArgs e)
        {
            lblName.Text = lblSdt.Text = lblConfirm.Text = "";
        }

        private void tbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void tbSdt_KeyDown(object sender, KeyEventArgs e)
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

        private void tbConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }
    }
}