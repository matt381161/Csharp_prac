using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AutoPick
{
    public partial class Form1 : Form
    {
        private Boolean pick = false;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr MapleStoryHandle = FindWindow("Notepad", "123.txt - 記事本");

            if (MapleStoryHandle == IntPtr.Zero)
            {
                MessageBox.Show("Calculator is not running.");
                return;
            }
            SetForegroundWindow(MapleStoryHandle);
            pick = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IntPtr MapleStoryHandle = FindWindow("Notepad", "123.txt - 記事本");

            if (MapleStoryHandle == IntPtr.Zero)
            {
                MessageBox.Show("Calculator is not running.");
                return;
            }
            SetForegroundWindow(MapleStoryHandle);
            pick = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pick) {
                SendKeys.SendWait(" ");
            }
        }
    }
}
