using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp27
{
    public partial class CoffeeRecomend : Form
    {
        public CoffeeRecomend()
        {
            InitializeComponent();
            this.Location = new Point(this.Location.X, this.Location.Y + 15);
        }

        private void iconButton1_MouseEnter(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.White;
            iconButton1.ForeColor = Color.White;
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.Black;
            iconButton1.ForeColor = Color.Black;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
