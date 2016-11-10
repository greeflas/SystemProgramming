using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05_Timer
{
    public partial class Form1 : Form
    {
        int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Timer.Enabled = true;
            Timer.Tick += Timer_Tick;

            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnClear.Enabled = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            count++;
            if (count % 2 == 0)
                listBox1.Items[0] = String.Format("{0} {1}", "Even:", count);
            else
                listBox1.Items[1] = String.Format("{0} {1}", "Not even:", count);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Timer.Enabled = false;

            btnStop.Enabled = false;
            btnStart.Enabled = true;
            btnClear.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            btnClear.Enabled = false;
        }
    }
}
