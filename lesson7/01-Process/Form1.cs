using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace _01_Process
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Process proc = new Process();
            //proc.StartInfo = new ProcessStartInfo("calc.exe");
            //proc.Start();

            // proc.WaitForExit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            process.StartInfo = new ProcessStartInfo("calc.exe");
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            process.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            process.CloseMainWindow();
            process.Close();
        }
    }
}
