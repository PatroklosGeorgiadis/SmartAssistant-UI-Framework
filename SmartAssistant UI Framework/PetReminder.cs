using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp27
{
    public partial class PetReminder : Form
    {
        DateTimePicker timepicker = new DateTimePicker();
        DateTimePicker timepicker2 = new DateTimePicker();
        public PetReminder()
        {
            InitializeComponent();
            timepicker.Location = new Point(367, 145);
            timepicker.Size = new Size(82, 21);
            timepicker.Format = DateTimePickerFormat.Custom;
            timepicker.CustomFormat = "HH:mm";
            timepicker.ShowUpDown = true;
            Controls.Add(timepicker);
            timepicker2.Location = new Point(367, 185);
            timepicker2.Size = new Size(82, 21);
            timepicker2.Format = DateTimePickerFormat.Custom;
            timepicker2.CustomFormat = "HH:mm";
            timepicker2.ShowUpDown = true;
            Controls.Add(timepicker2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Confirm confirm = new Confirm();
            confirm.ShowDialog();
            this.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                timepicker.Visible = false;
            }
            else
            {
                timepicker.Visible = true;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                timepicker2.Visible = false;
            }
            else
            {
                timepicker2.Visible = true;
            }
        }

        private void PetReminder_Load(object sender, EventArgs e)
        {
            
        }
    }
}
