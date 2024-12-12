using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Ahmad_Saleem_and_Company.App
{
    public partial class CreditVoucher : Form
    {
        public CreditVoucher()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("server=127.0.0.1;user=root;database=ledger system;password=;charset=utf8");
        public CreditVoucher(SqlConnection connection)
        {
            this.connection = connection;
        }
        private void CreditVoucher_Load(object sender, EventArgs e)
        {
            
        }

        private void NewCustomerCreditRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCustomerCreditbtn.Enabled = false;
            if (UpdateCustomerCreditbtn.Enabled == false)
            {
                AddCustomercreditbtn.Enabled = true;
            }
        }

        private void UpdateCustomerCreditRadiobtn_CheckedChanged(object sender, EventArgs e)
        {
            AddCustomercreditbtn.Enabled = false;
            if (AddCustomercreditbtn.Enabled == false)
            {
                UpdateCustomerCreditbtn.Enabled = true;
            }
        }
        private void FetchCustomerData()
        {
            string customerId = CreditCustomeridtxtbox.Text;

            if (!string.IsNullOrEmpty(customerId))
            {
                try
                {
                    connection.Open();

                    // SQL query to fetch customer data by Customerid
                    string fetchQuery = @"SELECT Customername, Customerphoneno 
                                          FROM customer WHERE Customerid = @Customerid";

                    SqlCommand fetchCommand = new SqlCommand(fetchQuery, connection);
                    fetchCommand.Parameters.AddWithValue("@Customerid", customerId);

                    SqlDataReader reader = fetchCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        CreditCustomernametxtbox.Text = reader["Customername"].ToString();
                        CustomerCreditphonenotxtbox.Text = reader["Customerphoneno"].ToString();
                       
                    }
                    else
                    {
                        MessageBox.Show("Customer ID not found.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while fetching customer data: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter a Customer ID.");
            }
        }


        private void AddCustomercreditbtn_Click(object sender, EventArgs e)
        {
            string Customerid = CreditCustomeridtxtbox.Text;
            string Customername = CreditCustomernametxtbox.Text;
            string Customerphoneno = CustomerCreditphonenotxtbox.Text;
            string Voucherno = CreditVouchernotxtbox.Text;
            string Naration = CreditNarationtxtbox.Text;
            decimal Amount = decimal.Parse(CreditAmounttxtbox.Text);
            DateTime Date = CreditDateTimePicker.Value;

            if (!string.IsNullOrEmpty(Customerid) && !string.IsNullOrEmpty(Customername) &&
                !string.IsNullOrEmpty(Customerphoneno))
            {
                try
                {
                    connection.Open();

                   

                    // SQL query to insert into creditvoucher table
                    string insertQuery = @"INSERT INTO creditvoucher 
                            (Voucherno, Customerid, Customername, Customerphoneno, Date, Amount, Naration)
                            VALUES(@Voucherno, @Customerid, @Customername, @Customerphoneno, @Date,@Amount, @Naration)";

                    // Create MySqlCommand and bind parameters
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@Voucherno", Voucherno);
                    command.Parameters.AddWithValue("@Customerid", Customerid);
                    command.Parameters.AddWithValue("@Customername", Customername);
                    command.Parameters.AddWithValue("@Customerphoneno", Customerphoneno);
                    command.Parameters.AddWithValue("@Date", Date);
                  
                    command.Parameters.AddWithValue("@Amount", Amount);
                    command.Parameters.AddWithValue("@Naration", Naration);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        
                        MessageBox.Show("Credit voucher added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add credit voucher. Please try again.");
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
        // Update the credit voucher against voucher no
        private void UpdateCustomerCreditbtn_Click(object sender, EventArgs e)
        {
            string Customerid = CreditCustomeridtxtbox.Text;
            string Customername = CreditCustomernametxtbox.Text;
            string Customerphoneno = CustomerCreditphonenotxtbox.Text;
            string Voucherno = CreditVouchernotxtbox.Text;
            string Naration = CreditNarationtxtbox.Text;
            decimal Amount = decimal.Parse(CreditAmounttxtbox.Text);
            DateTime Date = CreditDateTimePicker.Value;

            if (!string.IsNullOrEmpty(Customerid) && !string.IsNullOrEmpty(Customername) &&
                !string.IsNullOrEmpty(Customerphoneno) && !string.IsNullOrEmpty(Voucherno))
            {
                try
                {
                    connection.Open();

                    // Check if the voucher number exists for the given customer ID
                    string checkVoucherNoQuery = "SELECT COUNT(*) FROM creditvoucher WHERE Voucherno = @Voucherno AND Customerid = @Customerid";
                    SqlCommand checkVoucherNoCommand = new SqlCommand(checkVoucherNoQuery, connection);
                    checkVoucherNoCommand.Parameters.AddWithValue("@Voucherno", Voucherno);
                    checkVoucherNoCommand.Parameters.AddWithValue("@Customerid", Customerid);

                    int voucherCount = Convert.ToInt32(checkVoucherNoCommand.ExecuteScalar());

                    if (voucherCount == 0)
                    {
                        MessageBox.Show("Voucher number does not exist for the specified Customer ID. Please enter a valid voucher number.");
                        return; // Exit if voucher number does not exist for the given customer ID
                    }

                    

                    // SQL query to update the existing credit voucher
                    string updateQuery = @"UPDATE creditvoucher SET 
                                Customername = @Customername, 
                                Customerphoneno = @Customerphoneno, 
                                Date = @Date, 
                                Amount = @Amount, 
                                Naration = @Naration 
                                WHERE Voucherno = @Voucherno AND Customerid = @Customerid";

                    // Create MySqlCommand and bind parameters
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@Voucherno", Voucherno);
                    command.Parameters.AddWithValue("@Customerid", Customerid);
                    command.Parameters.AddWithValue("@Customername", Customername);
                    command.Parameters.AddWithValue("@Customerphoneno", Customerphoneno);
                    command.Parameters.AddWithValue("@Date", Date);
                   
                    command.Parameters.AddWithValue("@Amount", Amount);
                    command.Parameters.AddWithValue("@Naration", Naration);

                    // Execute the update query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                       
                        MessageBox.Show("Credit voucher updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update credit voucher. Please try again.");
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

        private void CreditCustomeridtxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // Check if the Enter key is pressed
            {
                FetchCustomerData();
                e.Handled = true; // Prevent the Enter key sound
            }
        }

        

        private void CreditSearchtxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(CreditSearchtxtbox.Text))
            {
                string searchQuery = CreditSearchtxtbox.Text;

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    // Query to search by either Customer ID or Customer Name
                    string query = "SELECT * FROM creditvoucher WHERE Customerid = @searchQuery OR Customername = @searchQuery";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@searchQuery", searchQuery);

                    adapter.SelectCommand = command;
                    adapter.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        CustomerCreditDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        CustomerCreditDataGridView.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("No credit voucher found with the provided ID or Name.");
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void CreditVouchernotxtbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
