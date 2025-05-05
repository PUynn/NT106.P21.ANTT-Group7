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
            var listenMusic = guna2Panel2.Controls.OfType<ListenMusic>().FirstOrDefault();
            if (listenMusic != null)
            {
                listenMusic.StopMusicAndDispose();
            }

            Home home = new Home(S);
            S.pnMain.Controls.Clear();
            S.pnMain.Controls.Add(home);
            home.Dock = DockStyle.Fill;
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

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            ListenMusic listenMusic = new ListenMusic(S, 0);

            guna2Panel2.Controls.Clear();
            guna2Panel2.Controls.Add(listenMusic);
            listenMusic.Dock = DockStyle.Fill;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            try
            {
                connect = new SqlConnection(connectString);
                connect.Open();

                command = new SqlCommand("SELECT * FROM SONGS", connect);
                adapter = new SqlDataAdapter(command);
                dtb = new DataTable();

                adapter.Fill(dtb);

                var buttons = new[] { guna2Button17, guna2Button18, guna2Button19, guna2Button20, guna2Button21, guna2Button22, guna2Button33 };
                var labels = new[] { guna2HtmlLabel4, guna2HtmlLabel5, guna2HtmlLabel6, guna2HtmlLabel7, guna2HtmlLabel8, guna2HtmlLabel9, guna2HtmlLabel10};

                for (int i = 0; i < buttons.Length && i < dtb.Rows.Count; i++)
                {
                    string srcPicture = dtb.Rows[i]["PICTURE_SONG"].ToString();
                    string srcName = dtb.Rows[i]["NAME_SONG"].ToString();

                    if (System.IO.File.Exists(srcPicture))
                    {
                        buttons[i].Image = Image.FromFile(srcPicture);
                        buttons[i].ImageSize = new Size(226, 208);

                        labels[i].Text = srcName;
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading song images: " + ex.Message);
            }
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            ListenMusic listenMusic = new ListenMusic(S, 1);
            guna2Panel2.Controls.Clear();
            guna2Panel2.Controls.Add(listenMusic);
            listenMusic.Dock = DockStyle.Fill;
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            ListenMusic listenMusic = new ListenMusic(S, 2);
            guna2Panel2.Controls.Clear();
            guna2Panel2.Controls.Add(listenMusic);
            listenMusic.Dock = DockStyle.Fill;
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            ListenMusic listenMusic = new ListenMusic(S, 3);
            guna2Panel2.Controls.Clear();
            guna2Panel2.Controls.Add(listenMusic);
            listenMusic.Dock = DockStyle.Fill;
        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            ListenMusic listenMusic = new ListenMusic(S, 4);
            guna2Panel2.Controls.Clear();
            guna2Panel2.Controls.Add(listenMusic);
            listenMusic.Dock = DockStyle.Fill;
        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            ListenMusic listenMusic = new ListenMusic(S, 5);
            guna2Panel2.Controls.Clear();
            guna2Panel2.Controls.Add(listenMusic);
            listenMusic.Dock = DockStyle.Fill;
        }

        private void guna2Button33_Click(object sender, EventArgs e)
        {
            ListenMusic listenMusic = new ListenMusic(S, 6);
            guna2Panel2.Controls.Clear();
            guna2Panel2.Controls.Add(listenMusic);
            listenMusic.Dock = DockStyle.Fill;
        }
    }
}
