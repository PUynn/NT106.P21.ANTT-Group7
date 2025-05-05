using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class SignUpInfor: UserControl
    {
        SONA S;
        public SignUpInfor(SONA s)
        {
            InitializeComponent();
            InitializeDateControls();
            S = s;
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                string text = comboBox.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    int value;
                    if (int.TryParse(text, out value))
                    {
                        if (comboBox == guna2ComboBox1 && (value < 1 || value > 31))
                        {
                            MessageBox.Show("Ngày phải từ 1 đến 31!");
                            comboBox.Text = "";
                        }
                        else if (comboBox == guna2ComboBox2 && (value < 1 || value > 12))
                        {
                            MessageBox.Show("Tháng phải từ 1 đến 12!");
                            comboBox.Text = "";
                        }
                        else if (comboBox == guna2ComboBox3 && (value < 1900 || value > 2025))
                        {
                            MessageBox.Show("Năm phải từ 1900 đến 2025!");
                            comboBox.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập số!");
                        comboBox.Text = "";
                    }
                }
            }
        }

        private void InitializeDateControls()
        {
            for (int i = 1; i <= 31; i++)
                guna2ComboBox1.Items.Add(i.ToString());

            for (int i = 1; i <= 12; i++)
                guna2ComboBox2.Items.Add(i.ToString());

            for (int i = 1900; i <= 2025; i++)
                guna2ComboBox3.Items.Add(i.ToString());
            
            guna2ComboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            guna2ComboBox2.DropDownStyle = ComboBoxStyle.DropDown;
            guna2ComboBox3.DropDownStyle = ComboBoxStyle.DropDown;

            guna2ComboBox1.TextChanged += ComboBox_TextChanged;
            guna2ComboBox2.TextChanged += ComboBox_TextChanged;
            guna2ComboBox3.TextChanged += ComboBox_TextChanged;
        }

        public string BirthDate
        {
            get
            {
                string day = guna2ComboBox1.Text;
                string month = guna2ComboBox2.Text;
                string year = guna2ComboBox3.Text;

                if (!string.IsNullOrEmpty(day) && !string.IsNullOrEmpty(month) && !string.IsNullOrEmpty(year))
                {
                    return $"{day}/{month}/{year}";
                }
                return null;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2ComboBox1.Text == "" || guna2ComboBox2.Text == "" || guna2ComboBox3.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            Home h = new Home(S);
            S.pnMain.Controls.Clear();
            S.pnMain.Controls.Add(h);

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
    }
}
