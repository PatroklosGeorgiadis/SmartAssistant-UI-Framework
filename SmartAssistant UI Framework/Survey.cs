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
    public partial class Survey : Form
    {
        private SoundPlayer sound = new SoundPlayer("button-press.wav");
        private int nextorder;
        private long previoustime;
        private String transport, parking;
        DateTimePicker timepicker = new DateTimePicker();
        public Survey(int order, String from, long previous)
        {
            InitializeComponent();
            label6.Text = order.ToString();
            nextorder = order + 1;
            timepicker.Location = new Point(270, 101);
            timepicker.Size = new Size(60, 26);
            timepicker.Format = DateTimePickerFormat.Custom;
            timepicker.CustomFormat = "HH:mm";
            timepicker.ShowUpDown = true;
            Controls.Add(timepicker);
            if (comboBox1.Items.Contains(from))
            {
                comboBox1.Items.Remove(from);
            }
            previoustime = previous;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timepicker.Value.Ticks <= previoustime)
            {
                MessageBox.Show("Η ώρα που ορίσατε για την άφιξη σε αυτόν τον προορισμό είναι πιο νώρις από την ώρα άφιξης στον προηγούμενο προορισμό. Παρακαλώ, προσθέστε το κάθε γεγονός με χρονολογική σειρά");
            }
            else if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Έχετε ξεχάσει να ορίσετε κάποια ανάγκαια πεδία");
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Είστε σίγουροι ότι το πλάνο σας έχει ολοκληρωθεί;", "Έλεγχος", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    Confirm conf = new Confirm();
                    conf.ShowDialog();
                    String map = mapDecider();
                    StringBuilder stops = new StringBuilder();
                    foreach (object item in checkedListBox1.CheckedItems)
                    {
                        stops.Append(item.ToString());
                    }
                    int hour = timepicker.Value.Hour - 1;
                    int min = timepicker.Value.Minute;
                    String startTime = hour.ToString() + ":" + min.ToString();
                    transport = comboBox2.Text;
                    FinalPlan f = new FinalPlan(label6.Text, timepicker.Text, comboBox1.Text, startTime, stops.ToString(), parking, map, transport);
                    f.Show();
                    f.Visible = false;
                    ShoesQuiz sq = new ShoesQuiz(label6.Text);
                    sq.Show();
                    sq.Visible = false;
                    Planner planner = Application.OpenForms.OfType<Planner>().First();
                    planner.PlanDisplay();
                }
            }
        }
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text == "Αυτοκίνητο")
            {
                checkedListBox1.Items.Add("Βενζινάδικο");
            }
            else if (checkedListBox1.Items.Contains("Βενζινάδικο"))
            {
                checkedListBox1.Items.Remove("Βενζινάδικο");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                linkLabel1.Visible = true;
            }
            else
            {
                linkLabel1.Visible = false;
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    label7.Visible = true;
                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    if (radioButton1.Checked && radioButton1.Visible)
                    {
                        linkLabel1.Visible = true;
                    }
                }
                else
                {
                    label7.Visible = false;
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    linkLabel1.Visible = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sound.Play();
            if (timepicker.Value.Ticks <= previoustime)
            {
                MessageBox.Show("Η ώρα που ορίσατε για την άφιξη σε αυτόν τον προορισμό είναι πιο νώρις από την ώρα άφιξης στον προηγούμενο προορισμό. Παρακαλώ, προσθέστε το κάθε γεγονός με χρονολογική σειρά");
            }
            else if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Έχετε ξεχάσει να ορίσετε κάποια ανάγκαια πεδία");
            }
            else
            {
                int hour = timepicker.Value.Hour - 1;
                int min = timepicker.Value.Minute;
                String startTime = hour.ToString() + ":" + min.ToString();
                Planner planner = Application.OpenForms.OfType<Planner>().First();
                planner.SurveyDisplay(nextorder, comboBox1.Text, timepicker.Value.Ticks);
                String map = mapDecider();
                StringBuilder stops = new StringBuilder();
                foreach (object item in checkedListBox1.CheckedItems)
                {
                    stops.Append(item.ToString() + " ");
                }
                transport = comboBox2.Text;
                FinalPlan f = new FinalPlan(label6.Text, timepicker.Text, comboBox1.Text, startTime, stops.ToString(), parking, map, transport);
                f.Show();
                f.Visible = false;
                ShoesQuiz sq = new ShoesQuiz(label6.Text);
                sq.Show();
                sq.Visible = false;
                this.Hide();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CoffeeRecomend cfr = new CoffeeRecomend();
            cfr.ShowDialog();
        }

        private String mapDecider()
        {
            StringBuilder map = new StringBuilder();
            switch (comboBox1.Text)
            {
                case "Σπίτι":
                    map.Append("home");
                    parking = "Γκαράζ";
                    break;
                case "Πανεπιστήμιο":
                    map.Append("university");
                    parking = "Καραούλη και Δημητρίου 80";
                    break;
                case "Γυμναστήριο":
                    map.Append("gym");
                    parking = "Nικ. Πλαστήρα 7";
                    break;
                case "Σουπερμάρκετ":
                    map.Append("supermarket");
                    parking = "Λεωφ. Αθηνών 302";
                    break;
                case "Μάθημα οδήγησης":
                    map.Append("driving");
                    parking = "Nικ. Πλαστήρα 7";
                    break;
                default:
                    map.Append("home");
                    parking = comboBox1.Text + " Πάρκινγκ";
                    break;
            }
            map.Append(".png");
            return map.ToString();
        }
    }
}
