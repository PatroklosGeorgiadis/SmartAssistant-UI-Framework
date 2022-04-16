using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp27;
using System.Media;

namespace UI_Side_menu
{
    public partial class HomeSystem : Form
    {
        private String currentSystem;
        public Form parent;
        private Form currentUtility;
        private Image image2check = WindowsFormsApp27.Properties.Resources.living;
        private SoundPlayer sound = new SoundPlayer("button-press.wav");
        public HomeSystem()
        {
            InitializeComponent();
        }

        private void ViewUtility(Form utility) 
        { 
            if(currentUtility!= null) 
            {
                currentUtility.Close();
            }
            currentUtility = utility;
            utility.TopLevel = false;
            utility.FormBorderStyle = FormBorderStyle.None;
            utility.Dock = DockStyle.Fill;
            panel6.Controls.Add(utility);
            panel6.Tag = utility;
            utility.BringToFront();
            utility.Show();
        }

        private void ReviewUtility()
        {
            if(currentSystem == "lights")
            {
                ViewUtility(new Lights(image2check));
            }
            else if (currentSystem == "temperature")
            {
                ViewUtility(new Temperature(image2check));
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            sound.Play();
            currentSystem = "lights";
            ViewUtility(new Lights(image2check));
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            sound.Play();
            currentSystem = "temperature";
            ViewUtility(new Temperature(image2check));
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            sound.Play();
            currentSystem = "appliances";
            if (Application.OpenForms.OfType<Shoes>().Any())
            {
                ViewUtility(Application.OpenForms.OfType<Shoes>().First());
            }
            else
            {
                ViewUtility(new Shoes());
            }
        }

        private void iconButton1_MouseHover(object sender, EventArgs e)
        {
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            //iconButton1.Font = new Font(iconButton1.Font,FontStyle.Bold);
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Regular;
            //iconButton1.Font = new Font(iconButton1.Font, FontStyle.Regular);
        }

        private void iconButton2_MouseHover(object sender, EventArgs e)
        {
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.ThermometerFull;
        }

        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.ThermometerHalf;
        }

        private void iconButton3_MouseHover(object sender, EventArgs e)
        {
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Solid;
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Regular;
        }

        private void iconButton5_MouseHover(object sender, EventArgs e)
        {
            iconButton5.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
        }

        private void iconButton5_MouseLeave(object sender, EventArgs e)
        {
            iconButton5.IconChar = FontAwesome.Sharp.IconChar.DoorClosed;
        }

        private void HomeSystem_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
                Closing closing = new Closing();
                closing.Show();
            }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            sound.Play();
            this.Hide();
            parent.Show();
        }

        private void roomButton1_Click(object sender, EventArgs e)
        {
            sound.Play();
            image2check = WindowsFormsApp27.Properties.Resources.living;
            ReviewUtility();
        }

        private void roomButton2_Click(object sender, EventArgs e)
        {
            sound.Play();
            image2check = WindowsFormsApp27.Properties.Resources.kitchen;
            ReviewUtility();
        }

        private void roomButton3_Click(object sender, EventArgs e)
        {
            sound.Play();
            image2check = WindowsFormsApp27.Properties.Resources.bath;
            ReviewUtility();
        }

        private void roomButton4_Click(object sender, EventArgs e)
        {
            sound.Play();
            image2check = WindowsFormsApp27.Properties.Resources.bed;
            ReviewUtility();
        }

        private void roomButton5_Click(object sender, EventArgs e)
        {
            sound.Play();
            image2check = WindowsFormsApp27.Properties.Resources.garage;
            ReviewUtility();
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
            Help.ShowHelp(this, "SA_guide.chm", HelpNavigator.TopicId, "13");
        }
    }
}
