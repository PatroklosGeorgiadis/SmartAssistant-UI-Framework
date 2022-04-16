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
    public partial class PetNotification : Form
    {
        private int x, y;
        public PetNotification(String msg)
        {
            InitializeComponent();
            label1.Text = msg;
            x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            y = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            this.Location = new Point(x, y);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
