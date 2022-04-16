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
    public partial class Feeding : Form
    {
        private SoundPlayer sound = new SoundPlayer("button-press.wav");
        private String animal;
        public Feeding(String Animal)
        {
            InitializeComponent();
            animal = Animal;
            if (animal == "goldfish")
            {
                axWindowsMediaPlayer1.URL = "goldfish-fish.gif";
                axWindowsMediaPlayer1.uiMode = "none";
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                label1.Text = "Χρυσόψαρο";
                label3.Text = "Πατήστε εάν επιθυμείτε να καθαρίσετε την γυάλα";
                iconButton3.Text = "Καθάρισμα";
                pictureBox2.Image = WindowsFormsApp27.Properties.Resources.dirty_tank;
                pictureBox1.Image = WindowsFormsApp27.Properties.Resources.idle_fish;
                richTextBox1.AppendText("Το χρυσόψαρο σας έφαγε την τροφή του" + Environment.NewLine + "Η γυάλα χρεάζεται καθάρισμα", Color.Maroon);
            }
            else
            {
                richTextBox1.AppendText("Η γάτα σας σκόρπισε την τροφή της" + Environment.NewLine + "H γάτα σας ήπιε νερό", Color.Maroon);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            sound.Play();
            if (animal == "cat")
            {
                pictureBox1.Image = WindowsFormsApp27.Properties.Resources.full_bowl;
                richTextBox1.AppendText(Environment.NewLine + "Προσθέσατε πλήρη μερίδα τροφής στην γάτα σας");
                iconButton1.Enabled = false;
                iconButton2.Enabled = false;
                iconButton1.BackColor = Color.Gray;
                iconButton2.BackColor = Color.Gray;
            }
            else
            {
                axWindowsMediaPlayer1.Visible = true;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                richTextBox1.AppendText(Environment.NewLine + "Προσθέσατε πλήρη μερίδα τροφής στο χρυσόψαρό σας");
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            sound.Play();
            if (animal == "cat")
            {
                pictureBox1.Image = WindowsFormsApp27.Properties.Resources.semi_full_bowl;
                richTextBox1.AppendText(Environment.NewLine + "Προσθέσατε μισή μερίδα τροφής στην γάτα σας");
                iconButton2.Enabled = false;
                iconButton2.BackColor = Color.Gray;
            }
            else
            {
                axWindowsMediaPlayer1.Visible = true;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                richTextBox1.AppendText(Environment.NewLine + "Προσθέσατε μισή μερίδα τροφής στο χρυσόψαρο σας");
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            sound.Play();
            if (animal == "cat")
            {
                pictureBox2.Image = WindowsFormsApp27.Properties.Resources.full_water;
                richTextBox1.AppendText(Environment.NewLine + "Προστέθηκε νερό στο δοχείο");
                iconButton3.Enabled = false;
                iconButton3.BackColor = Color.Gray;
            }
            else
            {
                pictureBox2.Image = WindowsFormsApp27.Properties.Resources.clean_tank;
                richTextBox1.AppendText(Environment.NewLine + "H γυάλα καθαρίστηκε επιτυχώς");
                iconButton3.Enabled = false;
                iconButton3.BackColor = Color.Gray;
            }
        }

    }
}
