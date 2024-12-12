using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahmad_Saleem_and_Company.App
{
    public partial class ReportViewForm : Form
    {
        public ReportViewForm()
        {
            InitializeComponent();
        }

        private void ReportViewForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.Controls.Add(this.reportViewer1);
            this.reportViewer2.RefreshReport();
        }
    }
}
