using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Ahmad_Saleem_and_Company.App
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("server=127.0.0.1;user=root;database=ledger system;password=;charset=utf8");
        public ProductForm(SqlConnection connection)
        {
            this.connection = connection;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductAddBtn_Click(object sender, EventArgs e)
        {
            string ProductId = productidtxtbox.Text;
            string Productname = productnametxtbox.Text;
            if (!string.IsNullOrEmpty(Productname))
            { 
                try
                {
                    connection.Open();

                    // Query to check if the product already exists
                    string checkQuery = "SELECT COUNT(*) FROM product WHERE Productid = @Productid";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);

                    checkCommand.Parameters.AddWithValue("@Productid", ProductId);

                    int ProductCount = Convert.ToInt32(checkCommand.ExecuteScalar()); 

                    if (ProductCount > 0)
                    {
                        MessageBox.Show("Product already exists.");
                    }
                    else
                    {
                        // Insert the new product into the database
                        string insertQuery = "INSERT INTO product (Productid, Productname) VALUES (@Productid, @Productname)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@Productid", ProductId);
                        insertCommand.Parameters.AddWithValue("@Productname", Productname);


                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product added successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to add product. Please try again.");
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

        private void Productsearchtxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(Productsearchtxtbox.Text))
            {
                string searchValue = Productsearchtxtbox.Text;

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    // Determine if the search input is a number (Product ID) or text (Product Name)
                    int productId;
                    string query;

                    if (int.TryParse(searchValue, out productId)) // If input is numeric, search by Product ID
                    {
                        query = "SELECT * FROM product WHERE Productid = @SearchValue";
                    }
                    else // Otherwise, search by Product Name
                    {
                        query = "SELECT * FROM product WHERE Productname LIKE CONCAT('%', @SearchValue, '%')";
                    }

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SearchValue", searchValue);

                    adapter.SelectCommand = command;
                    adapter.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ProductDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        ProductDataGridView.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("No product found.");
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

        private void NewProductradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateProductbtn.Enabled = false;
            if (UpdateProductbtn.Enabled == false)
            {
                ProductAddBtn.Enabled = true;
            }
        }

        private void UpdateProductRadiobtn_CheckedChanged(object sender, EventArgs e)
        {
            ProductAddBtn.Enabled = false;
            if (ProductAddBtn.Enabled == false)
            {
                UpdateProductbtn.Enabled = true;
            }
        }

        private void UpdateProductbtn_Click(object sender, EventArgs e)
        {
            string Productid = productidtxtbox.Text;
            string Productname = productnametxtbox.Text;
            

            // Check if all required fields are filled
            if (!string.IsNullOrEmpty(Productid) && !string.IsNullOrEmpty(Productname))
            {
                try
                {
                    // Open the database connection
                    connection.Open();

                    // Check if the product ID exists in the database
                    string checkidQuery = "SELECT Productid FROM product WHERE Productid = @Productid";
                    SqlCommand checkCommand = new SqlCommand(checkidQuery, connection);
                    checkCommand.Parameters.AddWithValue("@Productid", Productid);

                    object result = checkCommand.ExecuteScalar();

                    if (result != null)
                    {
                        // Update product name  using the existing productid
                        string updateQuery = "UPDATE product SET Productname = @Productname WHERE  Productid = @Productid";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@Productid", Productid);
                        updateCommand.Parameters.AddWithValue("@Productname", Productname);
                        

                        // Execute the update command
                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        // Check if the update was successful
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product name updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update Product name. Please try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product ID not found.");
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
                MessageBox.Show("Please enter all fields: product ID, product name.");
            }
        }
    }
}
