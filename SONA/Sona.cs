using Npgsql;
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
    public partial class SONA : Form
    {
        private Home home;

        string connString = "Host=aws-0-ap-southeast-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.ebrkvdctytawbdqmtrsk;Password=laptrinhmang;SSL Mode=Require;Trust Server Certificate=true"; // Chuỗi kết nối tới cơ sở dữ liệu PostgreSQL trên Supabase
        public SONA()
        {
            InitializeComponent();
            ShowLogin();
            GetIP();
        }
        private void GetIP()
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var selectCmd = new NpgsqlCommand("SELECT address FROM IP LIMIT 1", conn))
                {
                    var result = selectCmd.ExecuteScalar();
                    if (result != null)
                    {
                        IPAddressServer.serverIP = result.ToString();
                    }
                }
            }
        }

        public void ShowLogin()
        {
            Login login = new Login(this);

            pnMain.Controls.Clear();
            pnMain.Visible = false;

            pnLogin.Controls.Clear();
            pnLogin.Controls.Add(login);
            pnLogin.Visible = true;
            login.Visible = true;
            this.Activate();
        }

        public void ShowHome(string s)
        {
            home = new Home(this, s);
            home.Dock = DockStyle.Fill;

            pnLogin.Controls.Clear();
            pnLogin.Visible = false;
            
            pnMain.Controls.Clear();
            pnMain.Controls.Add(home);
            pnMain.Visible = true;
            
            home.Visible = true;
            this.Activate();
        }
    }
    public static class IPAddressServer
    {
        public static string serverIP;
    }
}