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
    public partial class Menu : Form
    {
        Random random = new Random();
        Random rand = new Random();
        List<string> list = new List<string> { "Η γάτα σας έκανε μία ζημιά", "Το χρυσόψαρο σας χτυπάει την γυάλα" };
        private SoundPlayer sound = new SoundPlayer("button-press.wav");
        private SoundPlayer notification = new SoundPlayer("Notification.wav");
        public Menu()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int ind = rand.Next(1, 4);
            if (ind == 1)
            {
                if (Application.OpenForms.OfType<PetNotification>().Count() == 1)
                {
                    Application.OpenForms.OfType<PetNotification>().First().Close();
                }
                notification.Play();
                int index = random.Next(list.Count);
                PetNotification petNotification = new PetNotification(list[index]);
                petNotification.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
                Closing closing = new Closing();
                closing.Show();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            sound.Play();
            if (Application.OpenForms.OfType<Planner>().Any())
            {
                Application.OpenForms.OfType<Planner>().First().Show();
            }
            else
            {
                Planner planner = new Planner();
                planner.parent = this;
                planner.Show();
            }
            this.Hide();
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            sound.Play();
            UI_Side_menu.HomeSystem home = new UI_Side_menu.HomeSystem();
            home.parent = this;
            this.Hide();
            home.Show();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            sound.Play();
            Pets pets = new Pets();
            pets.parent = this;
            this.Hide();
            pets.Show();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            sound.Play();
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            sound.Play();
            SettingsPage settingsPage = new SettingsPage();
            settingsPage.parent = this;
            this.Hide();
            settingsPage.Show();
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

        private void iconButton2_MouseEnter(object sender, EventArgs e)
        {
            iconButton2.IconColor = Color.White;
            iconButton2.ForeColor = Color.White;
        }

        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {
            iconButton2.IconColor = Color.Black;
            iconButton2.ForeColor = Color.Black;
        }

        private void iconButton3_MouseEnter(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.White;
            iconButton3.ForeColor = Color.White;
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.Black;
            iconButton3.ForeColor = Color.Black;
        }

        private void iconButton4_MouseEnter_1(object sender, EventArgs e)
        {
            iconButton4.IconColor = Color.White;
            iconButton4.ForeColor = Color.White;
        }

        private void iconButton4_MouseLeave_1(object sender, EventArgs e)
        {
            iconButton4.IconColor = Color.Black;
            iconButton4.ForeColor = Color.Black;
        }

        private void iconButton9_MouseEnter(object sender, EventArgs e)
        {
            iconButton9.IconColor = Color.White;
            iconButton9.ForeColor = Color.White;
        }

        private void iconButton9_MouseLeave(object sender, EventArgs e)
        {
            iconButton9.IconColor = Color.Black;
            iconButton9.ForeColor = Color.Black;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "SA_guide.chm", HelpNavigator.TopicId, "11");
        }
    }
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
