using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class Album : UserControl
    {
        DataRow dr;
        public Album(Home h)
        {
            InitializeComponent();
        }

        private void Album_Paint(object sender, PaintEventArgs e)
        {
            Color colorStart = Color.FromArgb(51, 56, 66);
            Color colorEnd = Color.FromArgb(0, 0, 0);

            LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                colorStart,
                colorEnd,
                LinearGradientMode.Vertical); // Hướng từ trên xuống dưới

            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

    }
}
