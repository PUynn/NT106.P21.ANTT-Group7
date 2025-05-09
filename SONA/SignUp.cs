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

        // Hàm để chuyển sang form đăng nhập
        private void lbDangnhap_Click(object sender, EventArgs e)
        {
            Login info = new Login(S);
            S.pnLogin.Controls.Clear();
            S.pnLogin.Controls.Add(info);

        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        // Hàm để kiểm tra xem email đã có trong cơ sở dữ liệu chưa, nếu chưa thì di chuyển đến form đăng ký thông tin
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                label5.Text = "Vui lòng nhập địa chỉ Email của bạn!";
                return;
            }

            try
            {
                connectSQL = new ConnectSQL();
                string queryEmail = $"SELECT * FROM USERS WHERE EMAIL = '{tbEmail.Text}'"; // thực hiện truy vấn để kiểm tra email đã tồn tại trong cơ sở dữ liệu chưa
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

        // Gọi hàm btnSignUp_Click khi nhấn phím Enter trong textbox tbEmail
        private void tbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignUp_Click(sender, e);
            }
        }

        // Hàm để đóng form đăng ký
        private void btnClose_Click(object sender, EventArgs e)
        {
            S.Close();
        }
    }
}
