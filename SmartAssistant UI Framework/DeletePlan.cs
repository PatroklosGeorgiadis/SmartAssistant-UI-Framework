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
    public partial class DeletePlan : Form
    {
        public DeletePlan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            while (Application.OpenForms.OfType<FinalPlan>().Any())
            {
                Application.OpenForms.OfType<FinalPlan>().First().Close();
            }
            while (Application.OpenForms.OfType<Survey>().Any())
            {
                Application.OpenForms.OfType<Survey>().First().Close();
            }
                this.Close();
        }
    }
}
