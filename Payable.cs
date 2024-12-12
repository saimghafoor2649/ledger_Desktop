
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ahmad_Saleem_and_Company.App
{
    public partial class Payable : Form
    {
        public Payable()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("server=127.0.0.1;user=root;database=ledger system;password=;charset=utf8");
        private void Payablereportgeneratebtn_Click(object sender, EventArgs e)
        {

            try
            {
                // Define the date range based on the DatePickers
                DateTime Datefrom = PayableDateFromPicker.Value.Date;
                DateTime Dateto = PayableDateToPicker.Value.Date.AddDays(1).AddTicks(-1);

                // Open connection
                connection.Open();

                // Query to fetch data from the recovery and saleinvoice tables
                string query = @"
                    SELECT 
                     r.Customerid, 
                     r.Customername, 
                      r.Customerphoneno,
                      SUM(r.Amount) AS Amount, 
                     (SELECT SUM(Total) FROM saleinvoice s WHERE s.Customerid = r.Customerid) AS Total 
                         FROM recovery r
                   WHERE r.Date BETWEEN @FromDate AND @ToDate
                    GROUP BY r.Customerid, r.Customername";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@FromDate", Datefrom);
                cmd.Parameters.AddWithValue("@ToDate", Dateto);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Check if data is retrieved
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No data found for the selected criteria.");
                    return;
                }

                // Iterate over each row and calculate balances
                foreach (DataRow row in dt.Rows)
                {
                    decimal total = Convert.ToDecimal(row["Total"]);
                    decimal amount = Convert.ToDecimal(row["Amount"]);
                    decimal balance = total - amount; // Calculate balance
                    decimal totalBalance = balance; // This could be updated if needed

                    // Insert or update the data in the Payable report table
                    string insertQuery = @"
                       INSERT INTO payablereport (Customerid, Customername,Customerphoneno,Total, Amount, Balance,TotalBalance, Gtotal)
                      VALUES (@Customerid, @Customername,@Customerphoneno,@Total, @Amount, @Balance, @TotalBalance,@Gtotal)
                      ON DUPLICATE KEY UPDATE 
                      Total = @Total,
                       Amount = @Amount, 
                        Balance = @Balance, 
                       TotalBalance = @TotalBalance,
                        Gtotal = @Gtotal";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@Customerid", row["Customerid"]);
                    insertCmd.Parameters.AddWithValue("@Customername", row["Customername"]);
                    insertCmd.Parameters.AddWithValue("@Customerphoneno", row["Customerphoneno"]);
                    insertCmd.Parameters.AddWithValue("@Total", total);
                    insertCmd.Parameters.AddWithValue("@Amount", amount);
                    insertCmd.Parameters.AddWithValue("@Balance", balance);
                    insertCmd.Parameters.AddWithValue("@TotalBalance", totalBalance);
                    insertCmd.Parameters.AddWithValue("@Gtotal", total); // Assuming Gtotal is the sum of Total

                    insertCmd.ExecuteNonQuery();
                }

                // Now, after inserting the data, fetch it from the `payablereport` table
                string fetchQuery = "SELECT * FROM payablereport";
                SqlCommand fetchCmd = new SqlCommand(fetchQuery, connection);
                SqlDataAdapter fetchAdapter = new SqlDataAdapter(fetchCmd);
                DataTable fetchDt = new DataTable();
                fetchAdapter.Fill(fetchDt);

                // Check if any data was fetched
                if (fetchDt.Rows.Count == 0)
                {
                    MessageBox.Show("No data found in the Payable Report.");
                    return;
                }

                // Close the connection after fetching data
                connection.Close();

                // Set up the ReportViewer
                /*  
                      ReportViewer reportViewer1 = new ReportViewer
                {
                    ProcessingMode = ProcessingMode.Local,

                    Dock = DockStyle.Fill,
                    ZoomMode = ZoomMode.FullPage,

                };

                reportViewer1.VerticalScroll.Enabled = true;
                 
                 */





                /*
                 reportViewer1.SetPageSettings(new System.Drawing.Printing.PageSettings
                {
                    Margins = new System.Drawing.Printing.Margins(5, 5, 5, 5), // Set small margins
                    Landscape = true, // Change to true if your table has many columns and you need more width
                    PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1169) // Width 827px, Height 1169px for A4 size
                });
                 
                 */

                // Set up the ReportViewer
                ReportViewer reportViewer1 = new ReportViewer
                {
                    ProcessingMode = ProcessingMode.Local,
                    Dock = DockStyle.Fill,
                    //ZoomMode = ZoomMode.PageWidth, // Fit the report to page width
                    
                };

                // Set page settings such as paper size, margins, and orientation
                var pageSettings = new System.Drawing.Printing.PageSettings
                {
                    Margins = new System.Drawing.Printing.Margins(1, 1, 1, 1), // Set margins to avoid cutting off data
                    Landscape = true, // Change to true for landscape if the report has many columns
                    
                    PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1169), // A4 paper size
                   
                };
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.SetPageSettings(pageSettings);



              
               
                reportViewer1.LocalReport.ReportPath = @"D:\Ahmad Saleem and Company\PayableReport.rdlc";
               
                // Add the DataTable (fetchDt) as a data source for the report
                ReportDataSource reportDataSource = new ReportDataSource("PayableDataSet", fetchDt);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                // Refresh the report to display the data
                reportViewer1.RefreshReport();

                // Display the report in the PayableViewForm
                PayableViewForm payableViewForm = new PayableViewForm();
                payableViewForm.Controls.Add(reportViewer1);
                reportViewer1.Dock = DockStyle.Fill;
                
                payableViewForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message + "\n" + ex.StackTrace);
                connection.Close(); // Ensure connection is closed on error
            }
        }
       
        private void GenerateTodayPayableReportbtn_Click(object sender, EventArgs e)
        {
            // Set the DateFrom to the start of today and DateTo to the end of today
            DateTime todayStart = DateTime.Today; // This sets the time to 00:00:00
            DateTime todayEnd = DateTime.Today.AddDays(1).AddTicks(-1); // This sets the time to 23:59:59

            // Assign the start and end of today to the date pickers
            PayableDateFromPicker.Value = todayStart;
            PayableDateToPicker.Value = todayEnd;

            // Call the generate report method
            Payablereportgeneratebtn_Click(sender, e);
        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
