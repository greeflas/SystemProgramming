using System;
using System.Threading;
using System.Windows.Forms;

namespace _05_WinformsAppDomain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Newthread();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void Newthread()
        {
            Thread thread = new Thread(new ThreadStart(InitDomain));
            thread.Start();
        }

        void InitDomain()
        {
            AppDomain MyDomain = AppDomain.CreateDomain("My domain");
            MyDomain.ExecuteAssembly(@"D:\Shop\Shop.WinForm.exe");
            AppDomain.Unload(MyDomain);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Main domain is work!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Newthread();
        }
    }
}
