using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Ahmad_Saleem_and_Company
{
    public partial class Login : Form
    {
       
        private bool isPasswordVisible = false; // Track password visibility
        public Login()
        {
            InitializeComponent();
            passwordtextbox.PasswordChar = '*';
           
        }
        SqlConnection connection = new SqlConnection("server=127.0.0.1;user=root;database=ledger system;password=");
          public Login(SqlConnection connection)
          {
            this.connection = connection;
          }
        private void Loginbtn_click(object sender, EventArgs e)
        {
            string Enteredname = nametextbox.Text;
            string EnteredPassword = passwordtextbox.Text;

            try
            {
                if (!string.IsNullOrEmpty(nametextbox.Text) && !string.IsNullOrEmpty(passwordtextbox.Text))
                {
                    // Open the database connection
                    connection.Open();

                    // SQL command to fetch the hashed password from the database based on the entered username
                    string query = "SELECT Password FROM user WHERE Name = @Name";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", Enteredname);

                    // Execute the command and retrieve the hashed password from the database
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        // Convert the result to a string (hashed password)
                        string storedPassword = result.ToString();


                        if (storedPassword == EnteredPassword)
                        {
                            MessageBox.Show("Login Successfully...");

                            Home h = new Home();
                            h.Show();
                            this.Hide();
                            



                        }
                        else
                        {
                            MessageBox.Show("Please enter the correct username and password...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all the blanks.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                connection.Close();
            }
            

        }

        private void eyeiconBtn_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                // Hide the password
                passwordtextbox.PasswordChar = '*';
                isPasswordVisible = false;
            }
            else
            {
                // Show the password
                passwordtextbox.PasswordChar = '\0'; // No masking character
                isPasswordVisible = true;
            }
        }
        

       

       
       

    }
}
