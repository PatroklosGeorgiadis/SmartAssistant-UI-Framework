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
    public partial class Shoes : Form
    {
        private SoundPlayer sound = new SoundPlayer("button-press.wav");
        public Shoes()
        {
            InitializeComponent();
        }

        private void ShoePickDisplay(object sender, EventArgs e)
        {
            sound.Play();
            Button btn = (Button)sender;
            panel1.Controls.Clear();
            foreach (ShoesQuiz a in Application.OpenForms.OfType<ShoesQuiz>())
            {
                if(a.nth == btn.Name)
                {
                    a.Dock = DockStyle.Fill;
                    a.Visible = true;
                    a.TopLevel = false;
                    panel1.Controls.Add(a);
                    break;
                }
            }
        }

        private void Shoes_Load(object sender, EventArgs e)
        {
            foreach (FinalPlan stop in Application.OpenForms.OfType<FinalPlan>())
            {
                Button button = new Button();
                button.Parent = flowLayoutPanel1;
                button.Dock = DockStyle.Top;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = Color.FromArgb(140, 140, 255);
                button.Cursor = Cursors.Hand;
                button.Text = stop.element + "ος Προορισμός";
                button.Name = stop.element;
                button.Size = new Size(80, 40);
                //button.Click += new EventHandler(this.ShoePickDisplay);
                button.Click += new EventHandler(ShoePickDisplay);
                flowLayoutPanel1.Controls.Add(button);
            }
        }
    }
}
