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
        public SONA()
        {
            InitializeComponent();
            SignUp login = new SignUp(this);
            pnLogin.Controls.Add(login);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}