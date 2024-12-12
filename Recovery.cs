
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahmad_Saleem_and_Company.App
{
    public partial class Recovery : Form
    {
        public Recovery()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("server=127.0.0.1;user=root;database=ledger system;password=;charset=utf8");

        public Recovery(SqlConnection connection)
        {
            this.connection = connection;
        }
        private void Recoverynewradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            RecoveryUpdatebtn.Enabled = false;
            if (RecoveryUpdatebtn.Enabled == false)
            {
                RecoveryAddbtn.Enabled = true;
            }
        }

        private void RecoveryUpdateradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            RecoveryAddbtn.Enabled = false;
            if (RecoveryAddbtn.Enabled == false)
            {
                RecoveryUpdatebtn.Enabled = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Recovery_Load(object sender, EventArgs e)
        {
            LoadCustomerNames();
            Recoverysearchtxtbox.TextChanged += Recoverysearchtxtbox_TextChanged;
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
                    RecoveryCustomernamecombobox.Items.Add(reader["Customername"].ToString());
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer names: " + ex.Message);
            }
        }

        private void RecoveryCustomernamecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCustomer = RecoveryCustomernamecombobox.SelectedItem.ToString();
            FetchCustomerDetails(selectedCustomer);
            LoadCustomerVouchers(selectedCustomer);
        }
        private void FetchCustomerDetails(string customerName)
        {
            try
            {
                connection.Open();
                string query = @"SELECT Customerid, Customerphoneno,Voucherno,Balance,Productname
                                 FROM saleinvoice
                                 WHERE Customername = @Customername 
                                 ORDER BY Date DESC LIMIT 1";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Customername", customerName);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Recoveryvouchernotxtbox.Text = reader["Voucherno"].ToString();
                    Recoverycustomeridtxtbox.Text = reader["Customerid"].ToString();
                    Recoverycustomerphonenotxtbox.Text = reader["Customerphoneno"].ToString();
                    RecoveryProductnametxtbox.Text = reader["Productname"].ToString();
                    Recoverybalancetxtboc.Text = reader["Balance"].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching customer details: " + ex.Message);
            }
        }
        //when the user select customer name so all details fetch from saleinvoice against customer name
        private void LoadCustomerVouchers(string customerName)
        {
            try
            {
                connection.Open();
               SqlCommand cmd = new SqlCommand("SELECT * FROM saleinvoice WHERE Customername = @Customername", connection);
                cmd.Parameters.AddWithValue("@Customername", customerName);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                RecoveryDatagridview.DataSource = dt;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading vouchers: " + ex.Message);
            }
        }

        private void RecoveryAmounttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateBalance();
            }
        }
        private void UpdateBalance()
        {
            if (decimal.TryParse(Recoverybalancetxtboc.Text, out decimal balance) && decimal.TryParse(RecoveryAmounttxtbox.Text, out decimal amount))
            {
                balance -= amount;
                Recoverybalancetxtboc.Text = balance.ToString();
                // Optionally, update the balance in the database here if required
            }
            else
            {
                MessageBox.Show("Invalid amount entered.");
            }
        }

        private void RecoveryAddbtn_Click(object sender, EventArgs e)
        {
            string voucherno = Recoveryvouchernotxtbox.Text;
            string customerId = Recoverycustomeridtxtbox.Text;
            string customerName = RecoveryCustomernamecombobox.SelectedItem.ToString();
            string narration = RecoveryDetailstxtbox.Text; // Assuming there's a TextBox for narration
            DateTime date = DateTime.Now; // Or use a date picker control
            decimal amount = decimal.Parse(RecoveryAmounttxtbox.Text);
            string customerPhoneNo = Recoverycustomerphonenotxtbox.Text;
            string productName = RecoveryProductnametxtbox.Text;
            decimal balance = decimal.Parse(Recoverybalancetxtboc.Text);

            try
            {
                connection.Open();

                // Check if the voucher number and customer ID exist in the saleinvoice table
                string checkQuery = @"
            SELECT COUNT(*) 
            FROM saleinvoice 
            WHERE Voucherno = @Voucherno AND Customerid = @Customerid";

                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@Voucherno", voucherno);
                checkCommand.Parameters.AddWithValue("@Customerid", customerId);

                int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (count > 0)
                {
                    // Insert new recovery record
                    string insertQuery = @"
                INSERT INTO recovery 
                (Voucherno, Balance, Customerid, Customername, Narration, Date, Amount, Customerphoneno, Productname)
                VALUES
                (@Voucherno, @Balance, @Customerid, @Customername, @Narration, @Date, @Amount, @Customerphoneno, @Productname)";

                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@Voucherno", voucherno);
                    insertCommand.Parameters.AddWithValue("@Balance", balance);
                    insertCommand.Parameters.AddWithValue("@Customerid", customerId);
                    insertCommand.Parameters.AddWithValue("@Customername", customerName);
                    insertCommand.Parameters.AddWithValue("@Narration", narration);
                    insertCommand.Parameters.AddWithValue("@Date", date);
                    insertCommand.Parameters.AddWithValue("@Amount", amount);
                    insertCommand.Parameters.AddWithValue("@Customerphoneno", customerPhoneNo);
                    insertCommand.Parameters.AddWithValue("@Productname", productName);

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Recovery details added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add recovery details. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Voucher number or Customer ID does not exist in the sale invoice.");
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

        private void RecoveryUpdatebtn_Click(object sender, EventArgs e)
        {
            string voucherno = Recoveryvouchernotxtbox.Text;
            string customerId = Recoverycustomeridtxtbox.Text;
            string customerName = RecoveryCustomernamecombobox.SelectedItem.ToString();
            string narration = RecoveryDetailstxtbox.Text; // Assuming there's a TextBox for narration
            DateTime date = DateTime.Now; // Or use a date picker control
            decimal amount = decimal.Parse(RecoveryAmounttxtbox.Text);
            string customerPhoneNo = Recoverycustomerphonenotxtbox.Text;
            string productName = RecoveryProductnametxtbox.Text;
            decimal balance = decimal.Parse(Recoverybalancetxtboc.Text);

            try
            {
                connection.Open();

                // Update existing recovery record
                string updateQuery = @"
                         UPDATE recovery
                         SET Balance = @Balance,
                          Customername = @Customername,
                           Narration = @Narration,
                          Date = @Date,
                        Amount = @Amount,
                         Customerphoneno = @Customerphoneno,
                           Productname = @Productname
                  WHERE Voucherno = @Voucherno AND Customerid = @Customerid";

                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@Balance", balance);
                updateCommand.Parameters.AddWithValue("@Customername", customerName);
                updateCommand.Parameters.AddWithValue("@Narration", narration);
                updateCommand.Parameters.AddWithValue("@Date", date);
                updateCommand.Parameters.AddWithValue("@Amount", amount);
                updateCommand.Parameters.AddWithValue("@Customerphoneno", customerPhoneNo);
                updateCommand.Parameters.AddWithValue("@Productname", productName);
                updateCommand.Parameters.AddWithValue("@Voucherno", voucherno);
                updateCommand.Parameters.AddWithValue("@Customerid", customerId);

                int rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Recovery details updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update recovery details. Please try again.");
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

        private void Recoverysearchtxtbox_TextChanged(object sender, EventArgs e)
        {
            PerformSearch(Recoverysearchtxtbox.Text);
        }

        private void Recoverysearchtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearch(Recoverysearchtxtbox.Text);
            }
        }
        private void PerformSearch(string searchText)
        {
            try
            {
                connection.Open();

                string query = @"
                      SELECT * 
                      FROM recovery 
                      WHERE Voucherno LIKE @SearchText OR Customername LIKE @SearchText";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                RecoveryDatagridview.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error performing search: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
