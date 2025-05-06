using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class SignUp : UserControl
    {
        SONA S;
        ConnectSQL connectSQL;

        public SignUp(SONA s )
        {
            InitializeComponent();
            S = s;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            S.Close();  
        }

        private void lbDangnhap_Click(object sender, EventArgs e)
        {
            Login info = new Login(S);
            S.pnLogin.Controls.Clear();
            S.pnLogin.Controls.Add(info);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                label5.Text = "Vui lòng nhập địa chỉ Email của bạn!";
                return;
            }

            try
            {
                connectSQL = new ConnectSQL();
                string queryEmail = $"SELECT * FROM USERS WHERE EMAIL = '{tbEmail.Text}'";
                DataTable dt = connectSQL.Query(queryEmail);

                if (dt.Rows.Count > 0)
                {
                    label5.Text = "Email đã tồn tại!";
                    return;
                }

                SignUpInfor signUpInfor = new SignUpInfor(S, tbEmail.Text);
                S.pnLogin.Controls.Clear();
                S.pnLogin.Controls.Add(signUpInfor);
            }
            catch (Exception ex)
            {
                label5.Text = "Lỗi: " + ex.Message;
            }


        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(tbEmail.Text))
                    guna2Button4_Click(sender, e);
                else
                    label5.Text = "Vui lòng nhập địa chỉ Email của bạn!";
            }
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            label5.Text = "";
        }
    }
}
