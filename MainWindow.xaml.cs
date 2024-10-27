using Npgsql;
using System;
using System.Data;
using System.Windows;
using System.Windows.Media;

namespace Foodle
{
    public partial class MainWindow : Window
    {
        private NpgsqlConnection conn;
        private string connString = "Host=localhost;Port=5432;Username=zidane;Password=Agar123Fku;Database=Foodle";

        public MainWindow()
        {
            InitializeComponent();
            EmailTextBox.Foreground = Brushes.Gray; // Set initial color for email textbox
            PasswordPlaceholder.Visibility = Visibility.Visible; // Ensure password placeholder is visible
        }

        // Method to open the database connection
        private void OpenConnection()
        {
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect: {ex.Message}");
            }
        }

        // Method to close the database connection
        private void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the database connection
            OpenConnection();

            // Fetch email and password from textboxes
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            // SQL query to check if user exists with provided email and password
            string sql = "SELECT COUNT(1) FROM useraccount WHERE useremail = @Email AND userpassword = @Password";

            try
            {
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("Email", email);
                    cmd.Parameters.AddWithValue("Password", password);

                    // Execute the query and check if user exists
                    int userExists = Convert.ToInt32(cmd.ExecuteScalar());

                    if (userExists > 0)
                    {
                        MessageBox.Show("Login successful!");
                        // Navigate to the main application window or dashboard
                        // e.g., new Dashboard().Show(); this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login: {ex.Message}");
            }
            finally
            {
                // Close the database connection
                CloseConnection();
            }
        }

        private void RegisterHere_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage(); // Create a new instance of RegisterPage
            registerPage.Show(); // Show the RegisterPage
            this.Close(); // Optional: Close the MainWindow if you don't want it open
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Closes the application
        }

        private void EmailTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            EmailPlaceholder.Visibility = Visibility.Collapsed; // Hide placeholder when textbox is focused
        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                EmailPlaceholder.Visibility = Visibility.Visible; // Show placeholder if textbox is empty
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password == "")
            {
                PasswordPlaceholder.Visibility = Visibility.Collapsed; // Hide placeholder when focused
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                PasswordPlaceholder.Visibility = Visibility.Visible; // Show placeholder if empty
            }
        }

        private void EmailTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Handle text changes if necessary
        }
    }
}
