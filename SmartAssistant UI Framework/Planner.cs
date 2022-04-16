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
    public partial class Planner : Form
    {
        public Form parent;
        private Boolean inprogress = false;
        private SoundPlayer sound = new SoundPlayer("button-press.wav");
        public Planner()
        {
            InitializeComponent();
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

        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (inprogress)
            {
                Closing close = new Closing();
                close.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void Planner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (inprogress)
            {
                
            }
            else if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
                Closing closing = new Closing();
                closing.Show();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            sound.Play();
            SurveyDisplay(1, "Σπίτι", 0);
            inprogress = true;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            sound.Play();
            FinalPlan f1 = new FinalPlan("1", "10:15", "Πανεπιστήμιο", "09:50", "Για καφέ, Φούρνος", "Καραούλη και Δημητρίου 80", "university.png", "Αυτοκίνητο");
            f1.Show();
            f1.Visible = false;
            FinalPlan f2 = new FinalPlan("2", "15:00", "Σουπερμάρκετ", "14:30", "Καμία", "Λεωφ. Καβάλας 302", "supermarket.png", "Αυτοκίνητο");
            f2.Show();
            f2.Visible = false;
            FinalPlan f3 = new FinalPlan("3", "15:30", "Σπίτι", "15:25", "Καμία", "Γκαράζ", "supermarket.png", "Αυτοκίνητο");
            f3.Show();
            f3.Visible = false;
            ShoesQuiz sq = new ShoesQuiz("1");
            sq.Show();
            sq.Visible = false;
            ShoesQuiz sq2 = new ShoesQuiz("2");
            sq2.Show();
            sq2.Visible = false;
            ShoesQuiz sq3 = new ShoesQuiz("3");
            sq3.Show();
            sq3.Visible = false;
            panel2.BringToFront();
            this.PlanDisplay();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            sound.Play();
            if (inprogress)
            {
                CancelingPlan canceling = new CancelingPlan(this,parent);
                canceling.Show();
            }
            else
            {
                this.Hide();
                parent.Show();
            } 
        }

        public void PlanDisplay()
        {
            inprogress = false;
            iconButton9.Visible = true;
            iconButton3.Visible = true;
            panel2.Controls.Clear();
            panel2.BackColor = Color.FromArgb(128, 255, 128);
            if (Application.OpenForms.OfType<FinalPlan>().Count() > 2 && Application.OpenForms.OfType<Survey>().Any())
            {
                PetReminder pr = new PetReminder();
                pr.ShowDialog();
            }
            foreach (FinalPlan stop in Application.OpenForms.OfType<FinalPlan>())
            {
                Panel paneli = new Panel();
                paneli.Size = new Size(423, 125);
                paneli.Parent = panel2;
                paneli.Dock = DockStyle.Bottom;
                stop.Visible = true;
                stop.TopLevel = false;
                stop.Dock = DockStyle.Fill;
                paneli.Controls.Add(stop);
                paneli.Tag = stop;
                //stop.BringToFront();
            }
            panel2.AutoScroll = true;
            panel2.AutoScrollMinSize = new Size(0, 1);
        }

        public void SurveyDisplay(int n, String from, long l)
        {
            Survey survey = new Survey(n, from, l);
            survey.TopLevel = false;
            survey.Dock = DockStyle.Fill;
            panel2.Controls.Add(survey);
            panel2.Tag = survey;
            survey.BringToFront();
            survey.Show();
            panel2.BringToFront();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            sound.Play();
            DeletePlan del = new DeletePlan();
            del.ShowDialog();
            if (Application.OpenForms.OfType<FinalPlan>().Any() == false)
            {
                panel2.Controls.Clear();
                panel2.SendToBack();
                panel2.AutoScroll = false;
                panel2.BackColor = Color.White;
                iconButton9.Visible = false;
                iconButton3.Visible = false;
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

        private void iconButton3_MouseEnter(object sender, EventArgs e)
        {
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Solid;
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Regular;
        }

        private void iconButton9_MouseEnter(object sender, EventArgs e)
        {
            iconButton9.IconFont = FontAwesome.Sharp.IconFont.Solid;
        }

        private void iconButton9_MouseLeave(object sender, EventArgs e)
        {
            iconButton9.IconFont = FontAwesome.Sharp.IconFont.Regular;
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "SA_guide.chm", HelpNavigator.TopicId, "12");
        }
    }
}