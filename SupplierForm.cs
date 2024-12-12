
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ahmad_Saleem_and_Company.App
{
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("server=127.0.0.1;user=root;database=ledger system;password=;charset=utf8");
        public SupplierForm(SqlConnection connection)
        {
            this.connection = connection;
        }
        private void AddSupplierbtn_Click(object sender, EventArgs e)
        {

            string Supplierid = Supplieridtxtbox.Text;
            string Suppliername = Suppliernametxtbox.Text;
            string Supplierphoneno = Supplierphonenotxtbox.Text;

            if (!string.IsNullOrEmpty(Suppliername) && !string.IsNullOrEmpty(Supplierphoneno))
            {
                try
                {
                    connection.Open();

                    // Query to check if the supplier already exists
                    string checkQuery = "SELECT COUNT(*) FROM supplier WHERE Supplierid = @Supplierid AND  Supplierphoneno = @Supplierphoneno";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@Supplierid", Supplierid);
                    checkCommand.Parameters.AddWithValue("@Supplierphoneno", Supplierphoneno);

                    int supplierCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (supplierCount > 0)
                    {
                        MessageBox.Show("Supplier already exist.");
                    }
                    else
                    {
                        // Insert the new supplier into the database
                        string insertQuery = "INSERT INTO supplier (Supplierid, Suppliername, Supplierphoneno) VALUES (@Supplierid, @Suppliername, @Supplierphoneno)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@Supplierid", Supplierid);
                        insertCommand.Parameters.AddWithValue("@Suppliername", Suppliername);
                        insertCommand.Parameters.AddWithValue("@Supplierphoneno", Supplierphoneno);

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Supplier added successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to add Supplier. Please try again.");
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
                MessageBox.Show("Please fill all fields.");
            }
        }

        private void Suppliersearchtxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(Suppliersearchtxtbox.Text))
            {
                string searchQuery = Suppliersearchtxtbox.Text;

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    // Query to search by either Supplier ID or Supplier Name
                    string query = "SELECT * FROM supplier WHERE Supplierid = @searchQuery OR Suppliername = @searchQuery";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@searchQuery", searchQuery);

                    adapter.SelectCommand = command;
                    adapter.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SupplierDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        SupplierDataGridView.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("No supplier found with the provided ID or Name.");
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

        private void Newsupplierradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSupplierbtn.Enabled = false;
            if (UpdateSupplierbtn.Enabled == false)
            {
                AddSupplierbtn.Enabled = true;
            }
        }

        private void Updatesupplierradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            AddSupplierbtn.Enabled = false;
            if (AddSupplierbtn.Enabled == false)
            {
                UpdateSupplierbtn.Enabled = true;
            }
        }

        private void UpdateSupplierbtn_Click(object sender, EventArgs e)
        {
            string Supplierid = Supplieridtxtbox.Text;
            string Suppliername = Suppliernametxtbox.Text;
            string Supplierphoneno = Supplierphonenotxtbox.Text;

            // Check if all required fields are filled
            if (!string.IsNullOrEmpty(Supplierid) && !string.IsNullOrEmpty(Suppliername) && !string.IsNullOrEmpty(Supplierphoneno))
            {
                try
                {
                    // Open the database connection
                    connection.Open();

                    // Check if the Supplier ID exists in the database
                    string checkidQuery = "SELECT Supplierid FROM supplier WHERE Supplierid = @Supplierid";
                    SqlCommand checkCommand = new SqlCommand(checkidQuery, connection);
                    checkCommand.Parameters.AddWithValue("@Supplierid", Supplierid);

                    object result = checkCommand.ExecuteScalar();

                    if (result != null)
                    {
                        // Update Supplier name and phone number using the existing Supplierid
                        string updateQuery = "UPDATE supplier SET Suppliername = @Suppliername,  Supplierphoneno = @Supplierphoneno WHERE Supplierid = @Supplierid";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@Suppliername", Suppliername);
                        updateCommand.Parameters.AddWithValue("@Supplierphoneno", Supplierphoneno);
                        updateCommand.Parameters.AddWithValue("@Supplierid", Supplierid);

                        // Execute the update command
                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        // Check if the update was successful
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Supplier name and phone number updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update Supplier name and phone number. Please try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Supplier ID not found.");
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
                MessageBox.Show("Please enter all fields: Supplier ID, Supplier name, and phone number.");
            }
        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
