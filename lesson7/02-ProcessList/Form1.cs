using System;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace _02_ProcessList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var processes = Process.GetProcesses()
                .OrderBy(p => p.ProcessName);
            
            foreach(var proc in processes)
            {
                ProcessList.Items.Add($"{proc.ProcessName}");
            }
        }
    }
}
