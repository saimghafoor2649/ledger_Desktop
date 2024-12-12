using Ahmad_Saleem_and_Company.App;
using Siticone.Desktop.UI.WinForms;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Ahmad_Saleem_and_Company
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            new SiticoneShadowForm(this);
            new SiticoneDragControl(LogoContainer);
            new SiticoneDragControl(dragheaderpanel);
            new SiticoneDragControl(ControlHeader);
            new SiticoneDragControl(sidenavcontainer);
          


        }



        private void panelslider_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void CustomerFormbtn_Click(object sender, EventArgs e)
        {

            CustomerForm customerForm = new CustomerForm();
            customerForm.Show();

        }
        

        private void ProductFormbtn_Click(object sender, EventArgs e)
        {
            ProductForm productForm= new ProductForm();
            productForm.Show();
        }

        private void siticoneButton12_Click(object sender, EventArgs e)
        {
            Updatelogin updatelogin= new Updatelogin();
            updatelogin.Show();
        }

        private void siticoneComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(siticoneComboBox1.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentUICulture=new System.Globalization.CultureInfo("en");
                    break;
                    case 1:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ur-PK");
                    break;
            }
            this.Controls.Clear();
            InitializeComponent();
        }
       
                   
         
         
        

        private void DebitVoucherbtn_Click(object sender, EventArgs e)
        {
           //DebitVoucher debitVoucher= new DebitVoucher();
            //debitVoucher.Show();
        }

        private void CreditVoucherbtn_Click(object sender, EventArgs e)
        {
            CreditVoucher creditVoucher= new CreditVoucher();
            creditVoucher.Show();
        }

        private void UpdateDebitbtn_Click(object sender, EventArgs e)
        {
            UpdateDebit updateDebit= new UpdateDebit();
            updateDebit.Show();
        }

        private void UpdateCreditbtn_Click(object sender, EventArgs e)
        {
           UpdateCredit updateCredit= new UpdateCredit();
            updateCredit.Show();
        }

        private void SaleInvoicebtn_Click(object sender, EventArgs e)
        {
           SaleInvoice saleInvoice= new SaleInvoice();
            saleInvoice.Show();
        }

        private void UpdateSaleinvoicebtn_Click(object sender, EventArgs e)
        {
            UpdateSaleInvoice updateSaleInvoice= new UpdateSaleInvoice();
            updateSaleInvoice.Show();
        }

        private void LedgerReportbtn_Click(object sender, EventArgs e)
        {
            LedgerReport ledgerReport= new LedgerReport();
            ledgerReport.Show();
        }

        private void Recoverybtn_Click(object sender, EventArgs e)
        {
           Recovery recovery= new Recovery();
            recovery.Show();
        }

        private void UpdateRecoverybtn_Click(object sender, EventArgs e)
        {
           UpdateRecovery updateRecovery= new UpdateRecovery();
            updateRecovery.Show();
        }

        private void Reportbtn_Click(object sender, EventArgs e)
        {
            Report report= new Report();
            report.Show();
        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
        }

        private void SupplierFormbtn_Click(object sender, EventArgs e)
        {
            SupplierForm supplierForm = new SupplierForm();
            supplierForm.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void PurchaseStockbtn_Click(object sender, EventArgs e)
        {
            Payable payable = new Payable();
            payable.Show();
        }

        private void siticoneButton15_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton14_Click(object sender, EventArgs e)
        {

        }
    }
}
