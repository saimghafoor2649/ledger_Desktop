
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Data.SqlClient;

namespace Ahmad_Saleem_and_Company.App
{
    public partial class LedgerReport : Form
    {
        public ReportViewer reportViewer1;
        public LedgerReport()
        {
            InitializeComponent();
            // Initialize ReportViewer (ensure it's correctly added to your form)
                   
            // Event handlers for key down events
            this.KeyDown += new KeyEventHandler(LedgerReport_KeyDown);
            Ledgerreportcustomernamecombobox.KeyDown += new KeyEventHandler(LedgerReport_KeyDown);
            LedgerReportdatefrom.KeyDown += new KeyEventHandler(LedgerReport_KeyDown);
            LedgerReportdateto.KeyDown += new KeyEventHandler(LedgerReport_KeyDown);
        }
        SqlConnection connection = new SqlConnection("server=127.0.0.1;user=root;database=ledger system;password=;charset=utf8");

        //public object ReportViewer1 { get; private set; }

        public LedgerReport(SqlConnection connection)
        {
            this.connection = connection;
        }
        private void LedgerReport_Load(object sender, EventArgs e)
        {
            LoadCustomerNames();
        }
        private void LoadCustomerNames()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Customername FROM customer", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ledgerreportcustomernamecombobox.Items.Add(reader["Customername"].ToString());
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer names: " + ex.Message);
            }
        }
        private void Ledgerreportcustomernamecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCustomer = Ledgerreportcustomernamecombobox.SelectedItem.ToString();
           
            FetchCustomerDetails(selectedCustomer);
           
        }
        private void FetchCustomerDetails(string customerName)
        {
            try
            {
                connection.Open();
                string query = @"SELECT Customerid
                                 FROM customer
                                 WHERE Customername = @Customername";
                                
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Customername", customerName);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    
                    Ledgercustomeridtxtbox.Text = reader["Customerid"].ToString();
                   
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching customer details: " + ex.Message);
            }
        }

        private void LedgerReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FetchLedgerData();
                e.Handled = true;  // Mark the event as handled
                e.SuppressKeyPress = true; // Prevent the sound on Enter key press
            }
        }
        private void FetchLedgerData()
        {
            try
            {
                // Ensure the customer ID and date range are specified
                if (string.IsNullOrEmpty(Ledgercustomeridtxtbox.Text))
                {
                    MessageBox.Show("Please select a customer.");
                    return;
                }

                DateTime fromDate = LedgerReportdatefrom.Value;
                DateTime toDate = LedgerReportdateto.Value;

                // Open connection
               
                
                    connection.Open();
                

                // Query to fetch data from recovery and productname from saleinvoice
                string query = @"
                    SELECT *
                    FROM recovery 
                    WHERE Customerid = @Customerid
                      AND Date BETWEEN @FromDate AND @ToDate";
            

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Customerid", Ledgercustomeridtxtbox.Text);
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Bind data to DataGridView
                Ledgerreportdatagridview.DataSource = dt;

                // Close connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching ledger data: " + ex.Message);
            }
            
        }

        private void Ledgercustomeridtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FetchLedgerData();
                e.Handled = true;  // Mark the event as handled
                e.SuppressKeyPress = true; // Prevent the sound on Enter key press
            }
        }

        private void Generateledgerreportbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure the customer ID and date range are specified
                if (string.IsNullOrEmpty(Ledgercustomeridtxtbox.Text))
                {
                    MessageBox.Show("Please select a customer.");
                    return;
                }

                DateTime fromDate = LedgerReportdatefrom.Value;
                DateTime toDate = LedgerReportdateto.Value.Date.AddDays(1).AddTicks(-1); 

                // Open connection
                connection.Open();

                // Query to fetch data from the recovery table
                string query = @"
                SELECT *
                   FROM recovery 
                    WHERE Customerid = @Customerid
                    AND Date BETWEEN @FromDate AND @ToDate";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Customerid", Ledgercustomeridtxtbox.Text);
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);
               
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Close connection
                connection.Close();

                // Check if data is retrieved
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No data found for the selected criteria.");
                    return;
                }

                // Show a message box with the number of rows and a sample value
                MessageBox.Show($"Data fetched successfully. Rows count: {dt.Rows.Count}");
                MessageBox.Show($"Sample data - First row, first column value: {dt.Rows[0][0]}");

                // Debugging - Display all column names and first row values
                string columns = string.Join(", ", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
                string firstRowValues = string.Join(", ", dt.Rows[0].ItemArray);
                MessageBox.Show($"Columns: {columns}\nFirst row values: {firstRowValues}");


                // Set up the ReportViewer

                ReportViewer reportViewer1 = new ReportViewer
                {
                    ProcessingMode = ProcessingMode.Local,
                    Dock = DockStyle.Fill
                };
                reportViewer1.LocalReport.ReportPath = @"D:\Ahmad Saleem and Company\LedgerReport.rdlc";
                

                // Add the DataTable as a data source for the report
                ReportDataSource reportDataSource = new ReportDataSource("DataSet", dt); // Ensure "LedgerDataSet" matches the dataset name in your RDLC
                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                if (reportViewer1.LocalReport.DataSources.Count > 0)
                {
                    MessageBox.Show("Data source added to ReportViewer successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to add data source to ReportViewer.");
                }
                // Refresh the report to display the data
                reportViewer1.RefreshReport();
                reportViewer1.ReportError += (s, ev) =>
                {
                    MessageBox.Show("Report Error: " + ev.Exception.Message);
                };

                // Display the report in the LedgerReportForm
                LedgerReportForm ledgerReportForm = new LedgerReportForm();
                ledgerReportForm.Controls.Add(reportViewer1);
                reportViewer1.Dock = DockStyle.Fill;
                ledgerReportForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message + "\n" + ex.StackTrace);
                connection.Close(); // Ensure connection is closed on error
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
