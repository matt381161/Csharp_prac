using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pra_Matt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "Eng"  && textBox2.Text == "E12345")
            {
                label4.Visible = false;
                label3.Visible = true;
                tabControl1.Visible = true;
                toolStripStatusLabel1.Text = "Logged in!";
            }
            else if (textBox1.Text == "Super" && textBox2.Text == "S12345")
            {
                label4.Visible = false;
                label3.Visible = true;
                tabControl1.Visible = true;
                toolStripStatusLabel1.Text = "Logged in!";
            }
            else {
                label3.Visible = false;
                label4.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
                tabControl1.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("yyyy/MM/dd \nHH:mm:ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is tab 1");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exit?", "Exit",MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label6.BackColor = System.Drawing.Color.Red;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label6.BackColor = System.Drawing.Color.Blue;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label6.BackColor = System.Drawing.Color.Green;
        }

        private int second, minute, uuu;

        private void button4_Click(object sender, EventArgs e)
        {
            uuu = 0;
            second = 0;
            minute = 0;
            label7.Text = minute + " : " + second;
            timer2.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            uuu += 1;
            if (uuu == 100)
            {
                second += 1;
                uuu = 0;
            }
            if (second == 60)
            {
                minute += 1;
                second = 0;
            }
            label7.Text = minute + " : " + second + " : " + uuu;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Font = new System.Drawing.Font("新細明體", (comboBox1.SelectedIndex + 1) * 20, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
