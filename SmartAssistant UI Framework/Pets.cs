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
    public partial class Pets : Form
    {
        public Form parent;
        private SoundPlayer sound = new SoundPlayer("button-press.wav");
        private Form currentUtility;
        public Pets()
        {
            InitializeComponent();
            panel3.Visible = false;
        }

        private void ViewUtility(Form utility)
        {
            if (currentUtility != null)
            {
                currentUtility.Close();
            }
            currentUtility = utility;
            utility.TopLevel = false;
            utility.FormBorderStyle = FormBorderStyle.None;
            utility.Dock = DockStyle.Fill;
            if(panel6.Visible == true)
            {
                panel6.Controls.Add(utility);
                panel6.Tag = utility;
            }
            else
            {
                panel5.Controls.Add(utility);
                panel5.Tag = utility;
            }
            utility.BringToFront();
            utility.Show();
        }

        private void Pets_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
                Closing closing = new Closing();
                closing.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sound.Play();
            panel6.Visible = false;
            ViewUtility(new Feeding("cat"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sound.Play();
            panel6.Visible = false;
            ViewUtility(new Feeding("goldfish"));
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            sound.Play();
            panel6.Visible = true;
            panel5.Controls.Clear();
            panel5.BackColor = Color.FromArgb(128,255,128);
            if (Application.OpenForms.OfType<PetNotification>().Any())
            {
                label2.Visible = false;
                ViewUtility(Application.OpenForms.OfType<PetNotification>().First());
            }
            else
            {
                label2.Visible = true;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            sound.Play();
            if (panel3.Visible)
            {
                panel3.Visible = false;
            }
            else
            {
                panel3.Visible = true;
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            sound.Play();
            this.Hide();
            parent.Show();
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void iconButton5_MouseEnter(object sender, EventArgs e)
        {
            iconButton5.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
        }

        private void iconButton5_MouseLeave(object sender, EventArgs e)
        {
            iconButton5.IconChar = FontAwesome.Sharp.IconChar.DoorClosed;
        }

        private void iconButton2_MouseEnter(object sender, EventArgs e)
        {
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.Utensils;
        }

        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.DrumstickBite;
        }

        private void iconButton1_MouseEnter(object sender, EventArgs e)
        {
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Regular;
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Solid;
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "SA_guide.chm", HelpNavigator.TopicId, "17");
        }
    }
}
