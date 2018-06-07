using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EljonBati
{
    public partial class loadingscrn : Form
    {
        public loadingscrn()
        {
            InitializeComponent();
        }

        private void loadingscrn_Load(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                System.Threading.Thread.Sleep(50);
                backgroundWorker1.ReportProgress(i);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prgbar.Value = e.ProgressPercentage;
            label3.Text = "Loading files ..." + e.ProgressPercentage.ToString() + "%";
            if (prgbar.Value == 100)
            {
                this.Hide();
                new Form1().Show();
            }
        }
    }
}
