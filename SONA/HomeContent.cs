using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Guna.UI2.WinForms;

namespace SONA
{
    public partial class HomeContent : UserControl
    {
        Home H;
        string connectString = @"Data Source=(local);Initial Catalog=MUSIC_APP;Integrated Security=True";
        SqlConnection connect;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable dtb;
        public HomeContent(Home h)
        {
            InitializeComponent();
            H = h;
        }

        private void HomeContent_Load(object sender, EventArgs e)
        {

            try
            {
                connect = new SqlConnection(connectString);
                connect.Open();

                command = new SqlCommand("SELECT * FROM SONGS", connect);
                adapter = new SqlDataAdapter(command);
                dtb = new DataTable();
                adapter.Fill(dtb);

                foreach (DataRow dr in dtb.Rows)
                {
                    SongForm songForm = new SongForm(H, dr["NAME_SONG"].ToString(), (dr["PICTURE_SONG"].ToString()), dr["AM_THANH"].ToString());
                    flpSongs.Controls.Add(songForm);
                }

                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading song images: " + ex.Message);
            }
        }
    }
}
