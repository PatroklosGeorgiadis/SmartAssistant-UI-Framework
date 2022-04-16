using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace WindowsFormsApp27
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="carlitos"&&textBox2.Text==("1234"))
            {
                Confirm confirm = new Confirm();
                confirm.ShowDialog();
                Menu form1 = new Menu();
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Λάθος username/password. Προσπαθήστε ξανά");
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
                Closing closing = new Closing();
                closing.Show();
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
                iconButton7.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                iconButton7.IconChar = FontAwesome.Sharp.IconChar.Square;
            }
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "SA_guide.chm");
        }
    }
}
