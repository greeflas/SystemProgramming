using System;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public partial class MainForm : Form
    {
        delegate string MyDelegate();
        delegate string CalcDel(string a, string b);

        public MainForm()
        {
            InitializeComponent();
        }

        string GetData()
        {
            Thread.Sleep(5000);

            return "Test data";
        }

        Task<string> GetData2()
        {
            return Task.Run(
                () =>
                {
                    Thread.Sleep(5000);
                    return "Test data 2";
                }
            );
        }

        Task<string> Sum(string a, string b)
        {
            return Task.Run(
                () =>
                {
                    Thread.Sleep(5000);
                    return (Convert.ToInt32(a) + Convert.ToInt32(b)).ToString();
                }
            );
        }

        string Sum2(string a, string b)
        {
            Thread.Sleep(5000);
            return (Convert.ToInt32(a) + Convert.ToInt32(b)).ToString();
        }

        void Callback(IAsyncResult ar)
        {
            AsyncResult res = (AsyncResult)ar;
            MyDelegate caller = (MyDelegate)res.AsyncDelegate;

            lblData.Text = caller.EndInvoke(ar);
        }

        private async void btnGetData_Click(object sender, EventArgs e)
        {
            //MyDelegate del = GetData;
            //IAsyncResult res = del.BeginInvoke(Callback, null);

            lblData.Text = await GetData2();
        }

        void CalcCallback(IAsyncResult ar)
        {
            AsyncResult res = (AsyncResult)ar;
            CalcDel caller = (CalcDel)res.AsyncDelegate;

            Res.Text = caller.EndInvoke(ar);
        }

        private async void btnCalc_Click(object sender, EventArgs e)
        {
            //string a = A.Text;
            //string b = B.Text;

            //Res.Text = await Sum(a, b);

            CalcDel del = Sum2;
            IAsyncResult res = del.BeginInvoke(A.Text, B.Text, CalcCallback, null);
        }
    }
}
