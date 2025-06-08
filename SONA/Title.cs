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
    public partial class Title: UserControl
    {
        public Title(string text)
        {
            InitializeComponent();
            lblText.Text = text;
        }
    }
}
