using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MakeERP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cellcount = Int32.Parse(textBox1.Text);
            if (textBox2.Text == "") textBox2.Text = "Test";
            String filepath = "D:\\" + textBox2.Text + ".ERP";
            using (StreamWriter WriteStream = new StreamWriter(filepath, false))
            {
                String txt = "";
                txt = "Drawing   MarkingArea    Marking Area80    0         0         0         0";
                WriteStream.WriteLine(txt);
                txt = "Matrix    Marking Area80 Matrix1           0     0.000     0.000     0.000";
                WriteStream.WriteLine(txt);
//Cell      Matrix1        MCell109          0     0.000     0.000     0.000
                for (int i = 0; i < cellcount; i++)
                {
                    txt = "Cell      Matrix1        MCell";
                    txt += (i + 109).ToString();
                    txt += "       ";
                    if (i >= 0 & i < 10) txt += "   ";
                    else if (i >= 10 & i <= 99) txt += "  ";
                    else if (i >= 100 & i <= 999) txt += " ";
                    txt += i.ToString();
                    txt+= "     0.000     0.000     0.000";
                    WriteStream.WriteLine(txt);
                }
                WriteStream.Close();
                MessageBox.Show("完成!檔案在D:\\");
                Application.Exit();
            }
        }
    }
}
