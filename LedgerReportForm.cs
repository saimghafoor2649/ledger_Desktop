using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Ahmad_Saleem_and_Company.App
{
    public partial class LedgerReportForm : Form
    {
        public LedgerReportForm()
        {
            InitializeComponent();
        }
      

        private void LedgerReportForm_Load(object sender, EventArgs e)
        {
           this.reportViewer1.RefreshReport();
            this.Controls.Add(this.reportViewer1);
            
          
            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void LedgerReportForm_Load_1(object sender, EventArgs e)
        {

            this.reportViewer2.RefreshReport();
        }
    }
    
}
