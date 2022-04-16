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
    public partial class Temperature : Form
    {
        private SoundPlayer sound = new SoundPlayer("button-press.wav");
        private SoundPlayer sound2 = new SoundPlayer("scroll.wav");
        private int temp;
        public Temperature(Image OriginalImage)
        {
            InitializeComponent();
            pictureBox1.Image = OriginalImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sound.Play();
            if (button1.Enabled)
            {
                button1.Enabled = false;
                button1.BackColor = Color.Gray;
                trackBar1.Enabled = false;
                trackBar1.BackColor = Color.Gray;
                numericUpDown1.Enabled = false;
                button2.Enabled = true;
                button2.BackColor = Color.Red;
                temp = trackBar1.Value;
                trackBar1.Value = 20;
                numericUpDown1.Value = 20;
                label1.Text = "20";
            }
            else
            {
                button1.Enabled = true;
                button1.BackColor = Color.Lime;
                trackBar1.Enabled = true;
                trackBar1.BackColor = Color.Red;
                numericUpDown1.Enabled = true;
                button2.Enabled = false;
                button2.BackColor = Color.Gray;
                trackBar1.Value = temp;
                numericUpDown1.Value = temp;
                label1.Text = temp.ToString();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            sound2.Play();
            label1.Text = trackBar1.Value.ToString();
            numericUpDown1.Value = trackBar1.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = numericUpDown1.Value.ToString();
            trackBar1.Value = (int)numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sound.Play();
            button1.Enabled = false;
            button1.BackColor = Color.Gray;
            trackBar1.Enabled = false;
            trackBar1.BackColor = Color.Gray;
            numericUpDown1.Enabled = false;
            button2.Enabled = true;
            button2.BackColor = Color.Red;
            temp = trackBar1.Value;
            trackBar1.Value = 20;
            numericUpDown1.Value = 20;
            label1.Text = "20";   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sound.Play();
            button1.Enabled = true;
            button1.BackColor = Color.Lime;
            trackBar1.Enabled = true;
            trackBar1.BackColor = Color.Red;
            numericUpDown1.Enabled = true;
            button2.Enabled = false;
            button2.BackColor = Color.Gray;
            trackBar1.Value = temp;
            numericUpDown1.Value = temp;
            label1.Text = temp.ToString();
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            if(trackBar1.Value <= 21)
            {
                label1.ForeColor = Color.RoyalBlue;
                label2.ForeColor = Color.RoyalBlue;
            }
            else if (trackBar1.Value > 21 && trackBar1.Value < 25)
            {
                label1.ForeColor = Color.OrangeRed;
                label2.ForeColor = Color.OrangeRed;
            }
            else
            {
                label1.ForeColor = Color.Red;
                label2.ForeColor = Color.Red;
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            sound2.Play();
        }
    }
}
