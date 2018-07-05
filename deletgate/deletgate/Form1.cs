using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deletgate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            aa aa=new aa();
            bb bbb = new bb();
            aa.dele1 += new aa.dele(bbb.print);
            textBox1.Text = aa.asd("123");
        }
    }
}
