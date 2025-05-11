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
    public partial class SONA : Form
    {
        private Home home;
        private Login login;
        public SONA()
        {
            InitializeComponent();
            SignUp login = new SignUp(this);
            pnLogin.Controls.Add(login);
        }

        private void SONA_Deactivate(object sender, EventArgs e)
        {
            //if (home != null && this.WindowState != FormWindowState.Minimized)
            //{
            //    home.btnMinimize_Click(this, EventArgs.Empty);
            //}
        }

        public void ShowHome()
        {
            if (home == null)
            {
                home = new Home(this);
                home.Dock = DockStyle.Fill;
            }

            pnLogin.Controls.Clear();
            pnLogin.Visible = false;
            pnMain.Controls.Clear();
            pnMain.Controls.Add(home);
            pnMain.Visible = true;
            home.Visible = true;
            this.Activate();
        }
    }
}