using Npgsql;
using System;
using System.Data;
using System.Windows;
using System.Windows.Media;
using System.Security.Cryptography;
using System.Text;
using Project_Foodle.Customer;

namespace Project_Foodle.Foodle
{
    public partial class LoginPage : Window
    {
        private NpgsqlConnection conn;
        private string connString = "Host=foodle-application-foodle-application.h.aivencloud.com;Port=26047;Username=avnadmin;Password=AVNS_k_H25YfvkdcfYfDq7ph;Database=Project-Foodle;SslMode=Require;Trust Server Certificate=true";


        public LoginPage()
        {
            InitializeComponent();
            // Set initial placeholder visibility for Email/Username and Password fields
            EmailTextBox.Foreground = Brushes.Gray;
            EmailPlaceholder.Visibility = Visibility.Visible;
            PasswordPlaceholder.Visibility = Visibility.Visible;
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

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

        private void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            OpenConnection();

            string emailOrUsername = EmailTextBox.Text; // This can be either email or username
            string password = HashPassword(PasswordBox.Password); // Hash the entered password

            // Lakukan verifikasi username dan password di sini
            // Jika login berhasil:
            Application.Current.Properties["LoggedUser"] = emailOrUsername;

            // Adjust the query to match the hashed password
            string sql = "SELECT COUNT(1) FROM useraccount WHERE (useremail = @EmailOrUsername OR username = @EmailOrUsername) AND userpassword = @Password";

            try
            {
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("EmailOrUsername", emailOrUsername);
                    cmd.Parameters.AddWithValue("Password", password); // Use hashed password here

                    int userExists = Convert.ToInt32(cmd.ExecuteScalar());

                    if (userExists > 0)
                    {
                        MessageBox.Show("Login successful!");
                        App.LoggedInEmailorUsername = emailOrUsername; // di mana emailInput adalah email yang diinput pengguna

                        // Assuming you have a Frame named 'MainFrame' for navigation
                        MainFrame.Navigate(new DashboardPage());  // Navigate to the DashboardPage

                    }
                    else
                    {
                        MessageBox.Show("Invalid email/username or password. Please try again.");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
        }

        private void RegisterHere_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the RegisterPage2 for new users to register
            RegisterPage1 registerPage = new RegisterPage1();
            registerPage.Show();
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void EmailTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Hide placeholder when user focuses on the email field
            EmailPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Show placeholder if the email field is empty
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                EmailPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Hide placeholder when user focuses on the password field
            if (PasswordBox.Password == "")
            {
                PasswordPlaceholder.Visibility = Visibility.Collapsed;
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Show placeholder if the password field is empty
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                PasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }
    }
}
