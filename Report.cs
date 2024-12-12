
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Ahmad_Saleem_and_Company.App
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("server=127.0.0.1;user=root;database=ledger system;password=;charset=utf8");
        private void Report_Load(object sender, EventArgs e)
        {
            
        }

        private void GenerateReportbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Define the date range
                DateTime fromDate = ReportDatefrompicker.Value.Date;
                DateTime toDate = ReportDateToPicker.Value.Date.AddDays(1).AddTicks(-1);

                // Open the connection
                connection.Open();

                // Fetch data from the saleinvoice table
                string query = @"
                SELECT Voucherno, Customername, Productname, Qty, Rate, Gariafee, Totalgariafee, Total 
                FROM saleinvoice
                WHERE Date BETWEEN @FromDate AND @ToDate";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Check if any data was retrieved
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No data found for the selected criteria.");
                    return;
                }

                // Calculate the GrandTotal for each Customer
                var grandTotalCustomer = dt.AsEnumerable()
                    .GroupBy(row => row.Field<string>("Customername"))
                    .Select(group => new
                    {
                        Customername = group.Key,
                        GrandTotal = group.Sum(row => Convert.ToDecimal(row["Total"] ?? 0)),
                        GrandTotalgariafee = group.Sum(row => Convert.ToDecimal(row["Totalgariafee"] ?? 0)),
                        GrandQty = group.Sum(row => Convert.ToDecimal(row["Qty"] ?? 0)),
                        GrandTotalrate = group.Sum(row => Convert.ToDecimal(row["Rate"] ?? 0))

                    })
                    .ToList();

                // Calculate the GrandTotal for all customers
                decimal grandTotalAllCustomers = grandTotalCustomer.Sum(c => c.GrandTotal);
                decimal grandTotalgariafeeAll = grandTotalCustomer.Sum(c => c.GrandTotalgariafee);
                decimal grandTotalQtyAll = grandTotalCustomer.Sum(c => c.GrandQty);
                decimal grandTotalRateAll = grandTotalCustomer.Sum(c => c.GrandTotalrate);

                // Insert into report table
                foreach (DataRow row in dt.Rows)
                {
                    string customerName = row["Customername"].ToString();
                    decimal total = Convert.ToDecimal(row["Total"]);
                    decimal grandTotal = grandTotalCustomer.First(c => c.Customername == customerName).GrandTotal;
                    decimal grandTotalgariafee = grandTotalCustomer.First(c => c.Customername == customerName).GrandTotalgariafee;
                    decimal grandQty = grandTotalCustomer.First(c => c.Customername == customerName).GrandQty;
                    decimal grandTotalrate = grandTotalCustomer.First(c => c.Customername == customerName).GrandTotalrate;

                    string insertQuery = @"
                          INSERT INTO report (Voucherno, Customername, Productname, Qty, Rate, Gariafee, Totalgariafee, Total, GrandTotal, GrandTotalgariafee, GrandQty, GrandTotalrate, GrandTotalCustomer)
                          VALUES (@Voucherno, @Customername, @Productname, @Qty, @Rate, @Gariafee, @Totalgariafee, @Total, @GrandTotal, @GrandTotalgariafee, @GrandQty, @GrandTotalrate, @GrandTotalCustomer)
                          ON DUPLICATE KEY UPDATE 
                          Customername = VALUES(Customername), 
                          Productname = VALUES(Productname), 
                          Qty = VALUES(Qty), 
                          Rate = VALUES(Rate), 
                          Gariafee = VALUES(Gariafee), 
                          Totalgariafee = VALUES(Totalgariafee), 
                          Total = VALUES(Total), 
                           GrandTotal = VALUES(GrandTotal), 
                           GrandTotalgariafee = VALUES(GrandTotalgariafee), 
                           GrandQty = VALUES(GrandQty), 
                           GrandTotalrate = VALUES(GrandTotalrate), 
                           GrandTotalCustomer = VALUES(GrandTotalCustomer)";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@Voucherno", row["Voucherno"]);
                    insertCmd.Parameters.AddWithValue("@Customername", row["Customername"]);
                    insertCmd.Parameters.AddWithValue("@Productname", row["Productname"]);
                    insertCmd.Parameters.AddWithValue("@Qty", row["Qty"]);
                    insertCmd.Parameters.AddWithValue("@Rate", row["Rate"]);
                    insertCmd.Parameters.AddWithValue("@Gariafee", row["Gariafee"]);
                    insertCmd.Parameters.AddWithValue("@Totalgariafee", row["Totalgariafee"]);
                    insertCmd.Parameters.AddWithValue("@Total", total);
                    insertCmd.Parameters.AddWithValue("@GrandTotal", grandTotal);
                    insertCmd.Parameters.AddWithValue("@GrandTotalgariafee", grandTotalgariafee);
                    insertCmd.Parameters.AddWithValue("@GrandQty", grandQty);
                    insertCmd.Parameters.AddWithValue("@GrandTotalrate", grandTotalrate);
                    insertCmd.Parameters.AddWithValue("@GrandTotalCustomer", grandTotalAllCustomers);

                    insertCmd.ExecuteNonQuery();
                }
                MessageBox.Show("Report data inserted successfully!");
                // Now, after inserting the data, fetch it from the `payablereport` table
                string fetchQuery = "SELECT * FROM report";
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

               

                // Close the connection
                connection.Close();
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
                    Landscape = false, // Change to true for landscape if the report has many columns

                    PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1169), // A4 paper size

                };
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.SetPageSettings(pageSettings);





                reportViewer1.LocalReport.ReportPath = @"D:\Ahmad Saleem and Company\Report.rdlc";

                // Add the DataTable (fetchDt) as a data source for the report
                ReportDataSource reportDataSource = new ReportDataSource("ReportDataSet", fetchDt);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                // Refresh the report to display the data
                reportViewer1.RefreshReport();

                // Display the report in the PayableViewForm
                ReportViewForm reportViewForm = new ReportViewForm();
                reportViewForm.Controls.Add(reportViewer1);
                reportViewer1.Dock = DockStyle.Fill;

                reportViewForm.Show();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message);
                connection.Close();
            }

        }

        private void GenerateReportTodaybtn_Click(object sender, EventArgs e)
        {
            // Set the DateFrom to the start of today and DateTo to the end of today
            DateTime todayStart = DateTime.Today; // This sets the time to 00:00:00
            DateTime todayEnd = DateTime.Today.AddDays(1).AddTicks(-1); // This sets the time to 23:59:59

            // Assign the start and end of today to the date pickers
            ReportDatefrompicker.Value = todayStart;
            ReportDateToPicker.Value = todayEnd;

            // Call the generate report method
            GenerateReportbtn_Click(sender, e);
        }
    }
}
