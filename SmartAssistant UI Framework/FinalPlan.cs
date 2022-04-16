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
    public partial class FinalPlan : Form
    {
        private SoundPlayer mapsound = new SoundPlayer("map-sound.wav");
        public String element;
        private SoundPlayer sound = new SoundPlayer("button-press.wav");
        public FinalPlan(String n, String time, String destination, String startTime, String stops, String parking, String map, String transport)
        {
            InitializeComponent();
            element = n;
            label1.Text = n;
            label4.Text = time;
            label3.Text = destination;
            label7.Text = startTime;
            if (stops == "")
            {
                label11.Text = "Καμία";
            }
            else
            {
                label11.Text = stops;
            }
            label12.Text = parking;
            label15.Text = transport;
            if (transport != "Αυτοκίνητο")
            {
                label9.Visible = false;
                label12.Visible = false;
                if (transport == "Μέσα Μαζικής Μεταφοράς")
                {
                    label13.Text = "Έργα στην γραμμή 2 του μετρό";
                }
                else
                {
                    label13.Text = "Πάρτε νερό μαζί σας";
                }
            }
            pictureBox1.ImageLocation = map;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mapsound.Play();
            MapView mv = new MapView(pictureBox1.ImageLocation);
            mv.ShowDialog();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            sound.Play();
            DialogResult dialog = MessageBox.Show("Είστε σίγουροι οτι θέλετε να διαγράψετε αυτό το βήμα του σημερινού πλάνου;", "Διαγραφή", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
