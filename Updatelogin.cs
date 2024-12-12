using System;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Ahmad_Saleem_and_Company
{
    public partial class Updatelogin : Form
    {
        public Updatelogin()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("server=127.0.0.1;user=root;database=ledger system;password=");
        public Updatelogin(SqlConnection connection)
        {
            this.connection = connection;
        }
        private void updateloginsavebtn_Click(object sender, EventArgs e)
        {
            string newUsername = newnametxtbox.Text;
            string oldPassword = oldpasswordtxtbox.Text;
            string newPassword = newpasswordtxtbox.Text;

            if (!string.IsNullOrEmpty(newUsername) && !string.IsNullOrEmpty(oldPassword) && !string.IsNullOrEmpty(newPassword))
            {
                try
                {
                    // Open the database connection
                    connection.Open();

                    // Check if old password matches
                    string checkPasswordQuery = "SELECT Password FROM user WHERE Password = @oldPassword";
                    SqlCommand checkCommand = new SqlCommand(checkPasswordQuery, connection);
                    checkCommand.Parameters.AddWithValue("@oldPassword", oldPassword);

                    object result = checkCommand.ExecuteScalar();

                    if (result != null)
                    {
                        string storedPassword = result.ToString();
                        string enteredOldPassword = oldPassword;

                        if (storedPassword == enteredOldPassword)
                        {
                            // Hash the new password
                            string newPasswordHash = newPassword;

                            // Update username and password
                            string updateQuery = "UPDATE user SET Password = @NewPassword,Name = @Name";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                            updateCommand.Parameters.AddWithValue("@NewPassword", newPasswordHash);
                            updateCommand.Parameters.AddWithValue("@Name", newUsername);

                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Username and password updated successfully.");
                            }
                            else
                            {
                                MessageBox.Show("Failed to update username and password. Please try again.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Old password is incorrect.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Old Password not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while updating the database: " + ex.Message);
                }
                finally
                {
                    // Close the database connection
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter all fields: new username, old password, and new password.");
            }
        }
    }
}
