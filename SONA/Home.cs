using NAudio.Dsp;
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

        private void MyClick()
        {
            pnMyLibrary.FillColor = Color.FromArgb(17, 17, 17);
            btnDiscover.Checked = false;
            btnHome.Checked = false;
            btnSearch.Checked = false;
            txtSearch.Visible = false;
            btnSearch.Visible = true;
        }



        private void guna2Button29_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            HomeContent h = new HomeContent(this);
            h.Dock = DockStyle.Fill;
            panel1.Controls.Add(h);
        }


        private void btnPlaylists_Click(object sender, EventArgs e)
        {
            MyClick();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            MyClick();
        }

        private void btnLibrary_Click(object sender, EventArgs e)
        {
            pnMyLibrary.FillColor = Color.FromArgb(17, 17, 17);

        }

        private void btnFavorited_Click(object sender, EventArgs e)
        {
            MyClick();
        }

        private void btnAlbums_Click(object sender, EventArgs e)
        {
            MyClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MenuClick();
            txtSearch.Visible = true;
            btnSearch.Visible = false;
        }

        private void MenuClick()
        {
            pnMyLibrary.FillColor = Color.FromArgb(39, 39, 39);
            btnAlbums.Checked = false;
            btnPlaylists.Checked = false;
            btnLibrary.Checked = false;
            btnFavorited.Checked = false;
            btnChat.Checked = false;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MenuClick();    
            txtSearch.Visible = false;
            btnSearch.Visible = true;
        }

        private void btnDiscover_Click(object sender, EventArgs e)
        {
            MenuClick();
            txtSearch.Visible = false;
            btnSearch.Visible = true;
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            MyClick();
        }

        private void btnArtists_Click(object sender, EventArgs e)
        {
            MyClick();
        }

        private void pnMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            S.Close();
        }
    }
}
