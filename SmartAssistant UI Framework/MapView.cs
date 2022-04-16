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
    public partial class MapView : Form
    {
        public MapView(String map)
        {
            InitializeComponent();
            pictureBox1.ImageLocation = map;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_MouseEnter(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.White;
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.DarkRed;
        }
    }
}
