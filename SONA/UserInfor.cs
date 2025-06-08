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

namespace SONA
{
    public partial class UserInfor : UserControl
    {
        private string idUser;
        private SONA S;

        public UserInfor(SONA s, string idUser)
        {
            S = s;
            this.idUser = idUser;
            InitializeComponent();
            getUserInfor();
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
                    writer.Write(idUser);
                    writer.Write(tbNameUser.Text);
                    writer.Write(tbSdt.Text);
                    writer.Write(tbPass.Text);

                    string response = reader.ReadString();

                    if (response == "OK")
                    {
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