
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ahmad_Saleem_and_Company.App
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("server=127.0.0.1;user=root;database=ledger system;password=;charset=utf8");
        public CustomerForm(SqlConnection connection)
        {
            this.connection = connection;
        }
        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void Addcustomerbtn_Click(object sender, EventArgs e)
        {
            string customerId = customeridtxtbox.Text;
            string mobileNo = customerphonenotxtbox.Text;
            string customerName = customerNametxtbox.Text;

            if (!string.IsNullOrEmpty(mobileNo) && !string.IsNullOrEmpty(customerName))
            {
                try
                {
                    connection.Open();

                    // Query to check if the customer already exists
                    string checkQuery = "SELECT COUNT(*) FROM customer WHERE Customerid = @Customerid AND Customerphoneno = @Customerphoneno";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@Customerid", customerId);
                    checkCommand.Parameters.AddWithValue("@Customerphoneno", mobileNo);

                    int customerCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (customerCount > 0)
                    {
                        MessageBox.Show("Customer already exists.");
                    }
                    else
                    {
                        // Insert the new customer into the database
                        string insertQuery = "INSERT INTO customer (Customerid, Customername, Customerphoneno) VALUES (@Customerid, @Customername, @Customerphoneno)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@Customerid", customerId);
                        insertCommand.Parameters.AddWithValue("@Customername", customerName);
                        insertCommand.Parameters.AddWithValue("@Customerphoneno", mobileNo);

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer added successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to add customer. Please try again.");
                        }
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
                MessageBox.Show("Please fill in all fields.");
            }
        }

        private void siticoneTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(siticoneTextBox1.Text))
            {
                string searchValue = siticoneTextBox1.Text;

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    // Determine if the search input is numeric (Customer ID) or text (Customer Name)
                    int customerId;
                    string query;

                    if (int.TryParse(searchValue, out customerId)) // If input is numeric, search by Customer ID
                    {
                        query = "SELECT * FROM customer WHERE Customerid = @SearchValue";
                    }
                    else // Otherwise, search by Customer Name
                    {
                        query = "SELECT * FROM customer WHERE Customername LIKE CONCAT('%', @SearchValue, '%')";
                    }

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SearchValue", searchValue);

                    adapter.SelectCommand = command;
                    adapter.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        siticoneDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        siticoneDataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("No customer found.");
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

        private void NewRadiobtn_CheckedChanged(object sender, EventArgs e)
        {
            CustomerUpdatebtn.Enabled = false;
            if (CustomerUpdatebtn.Enabled == false)
            {
                Addcustomerbtn.Enabled = true; 
            }
        }

        private void UpdateRadiobtn_CheckedChanged(object sender, EventArgs e)
        {
            Addcustomerbtn.Enabled = false;
            if (Addcustomerbtn.Enabled == false)
            {
                CustomerUpdatebtn.Enabled = true;
            }
        }

        private void CustomerUpdatebtn_Click(object sender, EventArgs e)
        {
            string Customerid = customeridtxtbox.Text;
            string Customername = customerNametxtbox.Text;
            string Customerphoneno = customerphonenotxtbox.Text;

            // Check if all required fields are filled
            if (!string.IsNullOrEmpty(Customerid) && !string.IsNullOrEmpty(Customername) && !string.IsNullOrEmpty(Customerphoneno))
            {
                try
                {
                    // Open the database connection
                    connection.Open();

                    // Check if the customer ID exists in the database
                    string checkidQuery = "SELECT Customerid FROM customer WHERE Customerid = @Customerid";
                    SqlCommand checkCommand = new SqlCommand(checkidQuery, connection);
                    checkCommand.Parameters.AddWithValue("@Customerid", Customerid);

                    object result = checkCommand.ExecuteScalar();

                    if (result != null)
                    {
                        // Update Customer name and phone number using the existing Customerid
                        string updateQuery = "UPDATE customer SET Customername = @Customername, Customerphoneno = @Customerphoneno WHERE Customerid = @Customerid";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@Customername", Customername);
                        updateCommand.Parameters.AddWithValue("@Customerphoneno", Customerphoneno);
                        updateCommand.Parameters.AddWithValue("@Customerid", Customerid);

                        // Execute the update command
                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        // Check if the update was successful
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer name and phone number updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update customer name and phone number. Please try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer ID not found.");
                    }
                }
                catch (Exception ex)
                {
                    // Show the error message if an exception occurs
                    MessageBox.Show("An error occurred while updating: " + ex.Message);
                }
                finally
                {
                    // Close the database connection
                    connection.Close();
                }
            }
            else
            {
                // Show a message if required fields are missing
                MessageBox.Show("Please enter all fields: Customer ID, Customer name, and phone number.");
            }
        }
    }
}
