using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp27
{
    public partial class Lights : Form
    {
        Image ogImage;
        Image newImage;
        Image darkimage;
        private SoundPlayer sound = new SoundPlayer("button-press.wav");
        private SoundPlayer sound2 = new SoundPlayer("scroll.wav");
        public Lights(Image OriginalImage)
        {
            InitializeComponent();
            ogImage = OriginalImage;
            newImage = OriginalImage;
            pictureBox1.Image = OriginalImage;
            if (ogImage.Size == Properties.Resources.living.Size)
            {
                darkimage = Properties.Resources.living_dark;
            }
            else if (ogImage.Size == Properties.Resources.kitchen.Size)
            {
                darkimage = Properties.Resources.kitchen_dark;
            }
            else if (ogImage.Size == Properties.Resources.bath.Size)
            {
                darkimage = Properties.Resources.bath_dark;
            }
            else if (ogImage.Size == Properties.Resources.bed.Size)
            {
                darkimage = Properties.Resources.bed_dark;
            }
            else
            {
                darkimage = Properties.Resources.garage_dark;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            sound2.Play();
            newImage = AdjustBrightness(ogImage, trackBar1.Value);
            pictureBox1.Image = newImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = darkimage;
            sound.Play();
            trackBar1.BackColor = Color.Gray;
            trackBar1.Enabled = false;
            trackBar2.BackColor = Color.Gray;
            trackBar2.Enabled = false;
            iconPictureBox4.ForeColor = Color.Gray;
            button1.BackColor = Color.Gray;
            button1.Enabled = false;
            button2.BackColor = Color.Red;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sound.Play();
            pictureBox1.Image = newImage;
            trackBar1.BackColor = Color.Orange;
            trackBar1.Enabled = true;
            trackBar2.BackColor = Color.Turquoise;
            trackBar2.Enabled = true;
            iconPictureBox4.ForeColor = Color.LightSeaGreen;
            button1.BackColor = Color.Lime;
            button1.Enabled = true;
            button2.BackColor = Color.Gray;
            button2.Enabled = false;
        }

        private Bitmap AdjustBrightness(Image image, float brightness)
        {
            // Make the ColorMatrix.
            float b = (float)brightness / 50f;
            ColorMatrix cm = new ColorMatrix(new float[][]
                {
                    new float[] {1,0,0,0,0},
                    new float[] {0,1,0,0,0},
                    new float[] {0,0,1,0,0},
                    new float[] {0,0,0,1,0},
                    new float[] {b, b, b, 1, 1}
                });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cm);

            // Draw the image onto the new bitmap while applying the new ColorMatrix.
            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width, 0),
                new Point(0, image.Height),
            };
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            // Make the result bitmap.
            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(image, points, rect, GraphicsUnit.Pixel, attributes);
            }
            // Return the result.
            return bm;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sound.Play();
            if(button1.Enabled == true)
            {
                button1_Click(sender, e);
            }
            else
            {
                button2_Click(sender, e);
            }
        }

        private Bitmap AdjustColor(Image image, float brightness)
        {
            // Make the ColorMatrix.
            float b;
            if (brightness == 1)
            {
                b = 1;
            }
            else
            {
                b = (float)brightness * 0.5f;
            }
            ColorMatrix cm = new ColorMatrix(new float[][]
                {
                    new float[] {1,0,0,0,0},
                    new float[] {0,1,0,0,0},
                    new float[] {0,0,b,0,0},
                    new float[] {0,0,0,1,0},
                    new float[] {0,0,0,0,1}
                });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cm);

            // Draw the image onto the new bitmap while applying the new ColorMatrix.
            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width, 0),
                new Point(0, image.Height),
            };
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            // Make the result bitmap.
            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(image, points, rect, GraphicsUnit.Pixel, attributes);
            }
            // Return the result.
            return bm;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            sound2.Play();
            newImage = AdjustColor(ogImage, trackBar2.Value);
            pictureBox1.Image = newImage;
        }
    }
}
