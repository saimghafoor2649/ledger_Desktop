using System;
using System.Windows.Forms;

namespace Ahmad_Saleem_and_Company.App
{
    public partial class PayableViewForm : Form
    {
        public PayableViewForm()
        {
            InitializeComponent();
        }

        private void PayableViewForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.Controls.Add(this.reportViewer1);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void PayableViewForm_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ledger_systemDataSet.payablereport' table. You can move, or remove it, as needed.
           // this.payablereportTableAdapter.Fill(this.ledger_systemDataSet.payablereport);

            this.reportViewer2.RefreshReport();
        }
    }
}
