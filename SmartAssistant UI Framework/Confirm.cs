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
    public partial class Confirm : Form
    {
        private SoundPlayer sound = new SoundPlayer("ui-confirm.wav");
        public Confirm()
        {
            InitializeComponent();
            this.BringToFront();
        }

        private void Confirm_Load(object sender, EventArgs e)
        {
            sound.Play();
            timer1.Interval = 4000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
