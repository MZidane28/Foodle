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
            EmailTextBox.Foreground = Brushes.Gray;
            PasswordPlaceholder.Visibility = Visibility.Visible; 
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

            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            string sql = "SELECT COUNT(1) FROM useraccount WHERE useremail = @Email AND userpassword = @Password";

            try
            {
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("Email", email);
                    cmd.Parameters.AddWithValue("Password", password);

                    int userExists = Convert.ToInt32(cmd.ExecuteScalar());

                    if (userExists > 0)
                    {
                        MessageBox.Show("Login successful!");
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
                CloseConnection();
            }
        }

        private void RegisterHere_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            registerPage.Show();
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void EmailTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            EmailPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                EmailPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password == "")
            {
                PasswordPlaceholder.Visibility = Visibility.Collapsed;
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                PasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void EmailTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
        }
    }
}
