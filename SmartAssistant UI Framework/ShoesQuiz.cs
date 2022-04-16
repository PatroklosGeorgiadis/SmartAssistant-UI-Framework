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
using System.Diagnostics;
using Microsoft.Win32;

namespace WindowsFormsApp27
{
    public partial class ShoesQuiz : Form
    {
        private SoundPlayer sound = new SoundPlayer("button-press.wav");
        private SoundPlayer sound2 = new SoundPlayer("scroll.wav");
        public String nth;
        private Random rd = new Random();
        List<Bitmap> list = new List<Bitmap> { Properties.Resources.shoe1, Properties.Resources.shoe2, Properties.Resources.shoe3 };
        public ShoesQuiz(String n)
        {
            InitializeComponent();
            nth = n;
            int ind = rd.Next(0, 2);
            pictureBox4.Image = list[ind];
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            sound2.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sound.Play();
            DialogResult dialog = MessageBox.Show("Είστε σίγουροι οτι θέλετε να διαλέξετε αυτά τα παπούτσια;", "Έλεγχος επιλογής", MessageBoxButtons.YesNo);
            if(dialog == DialogResult.Yes)
            {
                Confirm conf = new Confirm();
                conf.ShowDialog();
                label1.Visible = false;
                label2.Visible = true;
                label2.Text = "Tα παπούτσια σας για τον "+nth+"o προορισμό";
                button1.Visible = false;
                button2.Visible = false;

            }
            else if(dialog == DialogResult.No)
            {
                //do nothing
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sound.Play();
            DialogResult dialog = MessageBox.Show("Είστε σίγουροι οτι θέλετε να διαλέξετε άλλα παπούτσια;", "Έλεγχος επιλογής", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                label1.Visible = false;
                pictureBox4.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                label2.Visible = true;
                panel1.Visible = true;
            }
            else if (dialog == DialogResult.No)
            {
                //do nothing
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Image final = pictureBox1.Image;
            pictureboxShow(final);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Image final = pictureBox2.Image;
            pictureboxShow(final);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Image final = pictureBox3.Image;
            pictureboxShow(final);
        }

        private void pictureboxShow(Image final)
        {
            sound.Play();
            DialogResult dialog = MessageBox.Show("Είστε σίγουροι οτι θέλετε να διαλέξετε αυτά τα παπούτσια;", "Έλεγχος επιλογής", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Confirm conf = new Confirm();
                conf.ShowDialog();
                label1.Visible = false;
                label2.Visible = true;
                label2.Text = "Tα παπούτσια σας για τον " + nth + "o προορισμό";
                panel1.Visible = false;
                pictureBox4.Image = final;
                pictureBox4.Visible = true;

            }
            else if (dialog == DialogResult.No)
            {
                //do nothing
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string key = @"htmlfile\shell\open\command";
            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(key, false);
            string default_browser = ((string)registryKey.GetValue(null, null)).Split('"')[1];
            Process proc = new Process();
            proc.StartInfo.FileName = default_browser;
            proc.StartInfo.Arguments = "https://www.saintsoles.com/vans?utm_source=google&utm_medium=cpc&utm_campaign=1_Brand_Vans&gclid=Cj0KCQiAmpyRBhC-ARIsABs2EAqTcfbx3gqJHjv15YPX2rZ_XbTCwy6dQyez1sBcO_KMcwBeQM_sYyMaAkXsEALw_wcB#/%CE%B5%CE%AF%CE%B4%CE%BF%CF%82-%CF%80%CE%B1%CF%80%CE%BF%CF%85%CF%84%CF%83%CE%B9%CE%B1-f35-v1287/sort=p.sort_order/order=ASC/limit=40";
            proc.Start();
            proc.WaitForExit();
            pictureboxShow(Properties.Resources.shoe1);
        }
    }
}
