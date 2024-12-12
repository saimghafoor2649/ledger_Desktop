using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Ahmad_Saleem_and_Company.App
{
    public partial class SaleInvoice : Form
    {
        public SaleInvoice()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("server=127.0.0.1;user=root;database=ledger system;password=;charset=utf8");

        public SaleInvoice(SqlConnection connection)
        {
            this.connection = connection;
        }

        private void SaleInvoice_Load(object sender, EventArgs e)
        {
            LoadCustomerNames();
            LoadProductNames();
        }
        private void LoadCustomerNames()
        {
            try
            {
                connection.Open();
                string query = "SELECT DISTINCT Customername FROM customer";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                   Customernamecombobox.Items.Add(reader["Customername"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading customer names: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void LoadProductNames()
        {
            try
            {
                connection.Open();
                string query = "SELECT DISTINCT ProductName FROM product"; // Assuming products table exists
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Saleinvoiceproductnamecombobox.Items.Add(reader["Productname"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading product names: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void NewSaleinvoiceradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSaleInvoicebtn.Enabled = false;
            if (UpdateSaleInvoicebtn.Enabled == false)
            {
                AddSaleinvoicebtn.Enabled = true;
            }
        }

        private void UpdateSaleinvoiceradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            AddSaleinvoicebtn.Enabled = false;
            if (AddSaleinvoicebtn.Enabled == false)
            {
                UpdateSaleInvoicebtn.Enabled = true;
            }
        }

        private void AddSaleinvoicebtn_Click(object sender, EventArgs e)
        {
            string voucherno = Saleinvoicevochernotxtbox.Text;
            string customerName = Customernamecombobox.SelectedItem.ToString();
            string customerId = SaleinvoiceCustomeridtxtbox.Text;
            decimal balance = decimal.Parse(SaleinvoiceBalancetxtbox.Text);
            string productName = Saleinvoiceproductnamecombobox.SelectedItem.ToString();
            string productId = Saleinvoiceproductidtxtbox.Text;
            DateTime date = DateTime.Now; // Or use a date picker control
            string customerPhoneNo = SaleinvoiceCustomerphonenotxtbox.Text;
            int qty = int.Parse(SaleinvoiceQtytxtbox.Text);
            decimal rate = decimal.Parse(SaleinvoiceRatetxtbox.Text);
            decimal gariaFee = decimal.Parse(SaleinvoiceGariaFeetxtbox.Text);
            decimal totalGariaFee = decimal.Parse(SaleinvoiceTotalGariafeeshowtxtbox.Text);
            decimal total = decimal.Parse(SaleinvoiceTotalshowtxtbox.Text);

            // Check if Voucherno exists
            try
            {
                connection.Open();

                string checkQuery = "SELECT COUNT(*) FROM creditvoucher WHERE Voucherno = @Voucherno AND Customerid = @Customerid";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@Voucherno", voucherno);
                checkCommand.Parameters.AddWithValue("@Customerid", customerId);
                long count = (long)checkCommand.ExecuteScalar();

                if (count > 0)
                {

                    // Insert new record
                     string insertQuery = @"
                 INSERT INTO saleinvoice 
                 (Customername, Voucherno, Customerid, Balance, Productname, Productid, Date, Customerphoneno, Qty, Rate, Gariafee, Totalgariafee, Total)
                 VALUES
                 (@Customername, @Voucherno, @Customerid, @Balance, @Productname, @Productid, @Date, @Customerphoneno, @Qty, @Rate, @Gariafee, @Totalgariafee, @Total)";

                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@Customername", customerName);
                    insertCommand.Parameters.AddWithValue("@Voucherno", voucherno);
                    insertCommand.Parameters.AddWithValue("@Customerid", customerId);
                    insertCommand.Parameters.AddWithValue("@Balance", balance);
                    insertCommand.Parameters.AddWithValue("@Productname", productName);
                    insertCommand.Parameters.AddWithValue("@Productid", productId);
                    insertCommand.Parameters.AddWithValue("@Date", date);
                    insertCommand.Parameters.AddWithValue("@Customerphoneno", customerPhoneNo);
                    insertCommand.Parameters.AddWithValue("@Qty", qty);
                    insertCommand.Parameters.AddWithValue("@Rate", rate);
                    insertCommand.Parameters.AddWithValue("@Gariafee", gariaFee);
                    insertCommand.Parameters.AddWithValue("@Totalgariafee", totalGariaFee);
                    insertCommand.Parameters.AddWithValue("@Total", total);

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sale invoice added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add sale invoice. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Voucher no does not exist against customer id");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void UpdateSaleInvoicebtn_Click(object sender, EventArgs e)
        {
            string voucherno = Saleinvoicevochernotxtbox.Text;
            string customerName = Customernamecombobox.SelectedItem.ToString();
            string customerId = SaleinvoiceCustomeridtxtbox.Text;
            decimal balance = decimal.Parse(SaleinvoiceBalancetxtbox.Text);
            string productName = Saleinvoiceproductnamecombobox.SelectedItem.ToString();
            string productId = Saleinvoiceproductidtxtbox.Text;
            DateTime date = DateTime.Now; // Or use a date picker control
            string customerPhoneNo = SaleinvoiceCustomerphonenotxtbox.Text;
            int qty = int.Parse(SaleinvoiceQtytxtbox.Text);
            decimal rate = decimal.Parse(SaleinvoiceRatetxtbox.Text);
            decimal gariaFee = decimal.Parse(SaleinvoiceGariaFeetxtbox.Text);
            decimal totalGariaFee = decimal.Parse(SaleinvoiceTotalGariafeeshowtxtbox.Text);
            decimal total = decimal.Parse(SaleinvoiceTotalshowtxtbox.Text);

            if (!string.IsNullOrEmpty(customerId) && !string.IsNullOrEmpty(customerName) &&
                !string.IsNullOrEmpty(customerPhoneNo) && !string.IsNullOrEmpty(voucherno))
            {
                try
                {
                    connection.Open();

                    // Check if the voucher number exists for the given customer ID
                    string checkVoucherNoQuery = "SELECT COUNT(*) FROM saleinvoice WHERE Voucherno = @Voucherno AND Customerid = @Customerid";
                    SqlCommand checkVoucherNoCommand = new SqlCommand(checkVoucherNoQuery, connection);
                    checkVoucherNoCommand.Parameters.AddWithValue("@Voucherno", voucherno);
                    checkVoucherNoCommand.Parameters.AddWithValue("@Customerid", customerId);

                    int voucherCount = Convert.ToInt32(checkVoucherNoCommand.ExecuteScalar());

                    if (voucherCount == 0)
                    {
                        MessageBox.Show("Voucher number does not exist for the specified Customer ID. Please enter a valid voucher number.");
                        return; // Exit if voucher number does not exist for the given customer ID
                    }



                    // SQL query to update the existing credit voucher
                    string updateQuery = @"UPDATE saleinvoice SET 
                                Customername = @Customername, 
                                Customerphoneno = @Customerphoneno, 
                                 Balance=@Balance,
                                Date = @Date, 
                                Productname=@Productname,
                                Qty=@Qty,
                                Rate=@Rate,
                                Gariafee=@Gariafee,
                                Totalgariafee=@Totalgariafee,
                                Total=@Total
                                WHERE Voucherno = @Voucherno AND Customerid = @Customerid";



                    // Create MySqlCommand and bind parameters
                    SqlCommand command = new SqlCommand(updateQuery, connection);

                    command.Parameters.AddWithValue("@Customername", customerName);
                    command.Parameters.AddWithValue("@Customerphoneno", customerPhoneNo);
                    command.Parameters.AddWithValue("@Balance", balance);
                    command.Parameters.AddWithValue("@Productname", productName);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Qty", qty);
                    command.Parameters.AddWithValue("@Rate", rate);
                    command.Parameters.AddWithValue("@Gariafee", gariaFee);
                    command.Parameters.AddWithValue("@Totalgariafee", totalGariaFee);
                    command.Parameters.AddWithValue("@Total", total);
                    command.Parameters.AddWithValue("@Voucherno", voucherno);
                    command.Parameters.AddWithValue("@Customerid", customerId);


                    // Execute the update query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                       
                        MessageBox.Show("Sale invoice updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update Sale invoice. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }

        }

        private void Customernamecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string customerName = Customernamecombobox.SelectedItem.ToString();
            FetchCustomerDetails(customerName);
            FetchCustomerVouchers(customerName);
        }
        // fetch customer details and show to txtboxes
        private void FetchCustomerDetails(string customerName)
        {
            try
            {
                connection.Open();
                string query = @"SELECT Customerid, Customerphoneno, Amount, Voucherno
                                 From creditvoucher 
                                 Where Customername = @Customername 
                                 ORDER BY Date DESC LIMIT 1";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Customername", customerName);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    SaleinvoiceCustomeridtxtbox.Text = reader["Customerid"].ToString();
                    SaleinvoiceCustomerphonenotxtbox.Text = reader["Customerphoneno"].ToString();
                    SaleinvoiceRatetxtbox.Text = reader["Amount"].ToString();
                    Saleinvoicevochernotxtbox.Text = reader["Voucherno"].ToString();
                   
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching customer details: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        // customer searching to datagridview
        private void FetchCustomerVouchers(string customerName)
        {
            try
            {
                connection.Open();
                string query = @"SELECT Voucherno, Customerid,Customerphoneno, Amount, Date
                                 FROM creditvoucher
                                 WHERE Customername = @Customername";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Customername", customerName);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                SaleinvoiceDatagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                SaleinvoiceDatagridview.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching customer vouchers: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Saleinvoiceproductnamecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string productName = Saleinvoiceproductnamecombobox.SelectedItem.ToString();
            FetchProductId(productName);
        }
        private void FetchProductId(string productName)
        {
            try
            {
                connection.Open();
                string query = "SELECT Productid FROM product WHERE Productname = @Productname"; // Assuming products table exists
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Productname", productName);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    Saleinvoiceproductidtxtbox.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Product not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching product ID: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        // fectch data from datagrid view when user click the row
        private void SaleinvoiceDatagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a row is clicked
            {
                DataGridViewRow row = SaleinvoiceDatagridview.Rows[e.RowIndex];

                // Fetch and assign "Voucherno"
                Saleinvoicevochernotxtbox.Text = row.Cells["Voucherno"] != null && row.Cells["Voucherno"].Value != null
                    ? row.Cells["Voucherno"].Value.ToString()
                    : string.Empty;

                // Fetch and assign "Customerid"
                SaleinvoiceCustomeridtxtbox.Text = row.Cells["Customerid"] != null && row.Cells["Customerid"].Value != null
                    ? row.Cells["Customerid"].Value.ToString()
                    : string.Empty;

                // Fetch and assign "Customerphoneno"
                SaleinvoiceCustomerphonenotxtbox.Text = row.Cells["Customerphoneno"] != null && row.Cells["Customerphoneno"].Value != null
                    ? row.Cells["Customerphoneno"].Value.ToString()
                    : string.Empty;

                // Check if the "Balance" column exists before trying to access it
               

                // If you want to fetch the "Rate" in the future, you can uncomment this:
                 SaleinvoiceRatetxtbox.Text = row.Cells["Amount"] != null && row.Cells["Amount"].Value != null
                     ? row.Cells["Amount"].Value.ToString()
                   : string.Empty;
            }
        }

        private void SaleinvoiceQtytxtbox_TextChanged(object sender, EventArgs e)
        {
            CalculateTotals();
        }

        private void SaleinvoiceGariaFeetxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaleinvoiceGariaFeetxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateGariaFee(); // Calculate total garia fee on Enter key press
                e.Handled = true; // Mark the event as handled
                e.SuppressKeyPress = true; // Prevent the Enter key sound
            }
        }

        private void SaleinvoiceTotalGariafeeshowtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateTotals(); // Calculate total on Enter key press
                e.Handled = true; // Mark the event as handled
                e.SuppressKeyPress = true; // Prevent the Enter key sound
            }

        }
        private void CalculateGariaFee()
        {
            try
            {
                // Get the quantity and garia fee values
                decimal qty = string.IsNullOrWhiteSpace(SaleinvoiceQtyshowtxtbox.Text) ? 0 : Convert.ToDecimal(SaleinvoiceQtyshowtxtbox.Text);
                decimal gariaFee = string.IsNullOrWhiteSpace(SaleinvoiceGariaFeetxtbox.Text) ? 0 : Convert.ToDecimal(SaleinvoiceGariaFeetxtbox.Text);

                // Calculate total garia fee
                decimal totalGariaFee = qty * gariaFee;
                SaleinvoiceTotalGariafeeshowtxtbox.Text = totalGariaFee.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while calculating the total garia fee: " + ex.Message);
            }
        }
        private void CalculateTotals()
        {
            try
            {
                // Get values from textboxes
                decimal rate = string.IsNullOrWhiteSpace(SaleinvoiceRatetxtbox.Text) ? 0 : Convert.ToDecimal(SaleinvoiceRatetxtbox.Text);
                decimal qty = string.IsNullOrWhiteSpace(SaleinvoiceQtytxtbox.Text) ? 0 : Convert.ToDecimal(SaleinvoiceQtytxtbox.Text);
                decimal gariaFee = string.IsNullOrWhiteSpace(SaleinvoiceGariaFeetxtbox.Text) ? 0 : Convert.ToDecimal(SaleinvoiceGariaFeetxtbox.Text);

                // Calculate total garia fee and overall total
                decimal totalGariaFee = qty * gariaFee;
                decimal total = (rate * qty) + totalGariaFee;

                // Display the results
                SaleinvoiceRateshowtxtbox.Text = rate.ToString("N2");
                SaleinvoiceQtyshowtxtbox.Text = qty.ToString("N2");
                SaleinvoiceTotalGariafeeshowtxtbox.Text = totalGariaFee.ToString("N2");
                SaleinvoiceTotalshowtxtbox.Text = total.ToString("N2");
                // update the balance
                SaleinvoiceBalancetxtbox.Text = total.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while calculating the totals: " + ex.Message);
            }
        }

        private void Saleinvoicesearchtxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(Saleinvoicesearchtxtbox.Text))
            {
                string searchQuery = Saleinvoicesearchtxtbox.Text;

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    // Query to search by either Customer ID or Customer Name
                    string query = "SELECT * FROM saleinvoice WHERE Customerid = @searchQuery OR Customername = @searchQuery";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@searchQuery", searchQuery);

                    adapter.SelectCommand = command;
                    adapter.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SaleinvoiceDatagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        SaleinvoiceDatagridview.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("No sale invoice found with the provided ID or Name.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void siticonePanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
