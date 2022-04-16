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
    public partial class SettingsPage : Form
    {
        public Form parent;
        private SoundPlayer sound = new SoundPlayer("button-press.wav");
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            sound.Play();
            this.Hide();
            parent.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if(iconButton1.IconChar == FontAwesome.Sharp.IconChar.VolumeUp)
            {
                label2.Text = "Πατήστε για Κατάργηση:";
                iconButton1.IconChar = FontAwesome.Sharp.IconChar.VolumeOff;
                
            }
            else
            {
                label2.Text = "Πατήστε για Σίγαση:";
                iconButton1.IconChar = FontAwesome.Sharp.IconChar.VolumeUp;
            }
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

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
                Closing closing = new Closing();
                closing.Show();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Ενεργές";
            }
            else
            {
                checkBox1.Text = "Ανενεργές";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox2.Text = "Ενεργό";
            }
            else
            {
                checkBox2.Text = "Ανενεργό";
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

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "SA_guide.chm", HelpNavigator.TopicId, "18");
        }
    }
}
