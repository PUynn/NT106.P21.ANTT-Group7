using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class Home : UserControl
    {
        SONA S;
        string connectString = @"Data Source=(local);Initial Catalog=MUSIC_APP;Integrated Security=True";
        SqlConnection connect;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable dtb;

        public Home(SONA s)
        {
            InitializeComponent();
            S = s;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }


        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button29_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

  

        private void Home_Load(object sender, EventArgs e)
        {

        }



        private void btnPlaylists_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {

        }
    }
}
