using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Npgsql;
using Project_Foodle.Customer;
using Project_Foodle.Driver;
using Project_Foodle.Foodle;

namespace Project_Foodle.Seller
{
    public partial class SellerProfile : Page
    {
        private NpgsqlConnection conn;
        private string connString = "Host=foodle-application-foodle-application.h.aivencloud.com;Port=26047;Username=avnadmin;Password=AVNS_k_H25YfvkdcfYfDq7ph;Database=Project-Foodle;SslMode=Require;Trust Server Certificate=true";

        public SellerProfile()
        {
            InitializeComponent();
            SellerProfileButton.Style = (Style)FindResource("ActiveButtonStyle");
            SetHighlightPosition(SellerProfileButton);
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();

                string userEmailOrUsername = App.LoggedInEmailorUsername;
                string query = "SELECT id, fullname, username, useremail, userpassword, phone, country, address, gender, dob, seller_address FROM useraccount WHERE useremail = @Email OR username = @Username";

                using (var command = new NpgsqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Email", userEmailOrUsername);
                    command.Parameters.AddWithValue("@Username", userEmailOrUsername);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            NameTextBlock.Text = reader["fullname"]?.ToString() ?? "No Name";
                            CustomerIDTextBlock.Text = reader["id"] != DBNull.Value ? $"ID {reader["id"]} • {reader["username"]}" : "No ID";
                            EmailTextBox.Text = reader["useremail"]?.ToString() ?? "No Email";
                            PhoneTextBox.Text = reader["phone"]?.ToString() ?? "No Phone";
                            GenderTextBox.Text = reader["gender"]?.ToString() ?? "No Gender";
                            DobTextBox.Text = reader["dob"]?.ToString() ?? "No DOB";
                            SellerAddressTextBox.Text = reader["seller_address"]?.ToString() ?? "No Address";
                            PasswordTextBox.Text = string.IsNullOrEmpty(reader["userpassword"]?.ToString())
                                ? "No Password"
                                : new string('*', Math.Min(reader["userpassword"].ToString().Length, 12));
                        }
                        else
                        {
                            MessageBox.Show("User not found!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn?.Close();
            }
        }

        private void MoveToDriverButton_Click(object sender, RoutedEventArgs e)
        {
            // Pindah ke halaman SellerCenter
            NavigationService.Navigate(new DriverDashboard());
        }

        // Handler untuk tombol Edit dan Save
        private void EmailEditButton_Click(object sender, RoutedEventArgs e) => ToggleEditMode(EmailTextBox);
        private void PhoneEditButton_Click(object sender, RoutedEventArgs e) => ToggleEditMode(PhoneTextBox);
        private void GenderEditButton_Click(object sender, RoutedEventArgs e) => ToggleEditMode(GenderTextBox);
        private void DobEditButton_Click(object sender, RoutedEventArgs e) => ToggleEditMode(DobTextBox);
        private void SellerAddressEditButton_Click(object sender, RoutedEventArgs e) => ToggleEditMode(SellerAddressTextBox);

        private void EmailSaveButton_Click(object sender, RoutedEventArgs e) => SaveFieldToDatabase("useremail", EmailTextBox.Text);
        private void PhoneSaveButton_Click(object sender, RoutedEventArgs e) => SaveFieldToDatabase("phone", PhoneTextBox.Text);
        private void GenderSaveButton_Click(object sender, RoutedEventArgs e) => SaveFieldToDatabase("gender", GenderTextBox.Text);
        private void DobSaveButton_Click(object sender, RoutedEventArgs e) => SaveFieldToDatabase("dob", DobTextBox.Text);
        private void SellerAddressButton_Click(object sender, RoutedEventArgs e)
        {
            string newAddress = SellerAddressTextBox.Text;
            SaveFieldToDatabase("seller_address", string.IsNullOrWhiteSpace(newAddress) ? null : newAddress);
            ToggleEditMode(SellerAddressTextBox);
        }

        private void PasswordEditButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleEditMode(PasswordTextBox);
        }

        private void PasswordSaveButton_Click(object sender, RoutedEventArgs e)
        {
            string rawPassword = PasswordTextBox.Text;
            if (string.IsNullOrEmpty(rawPassword))
            {
                MessageBox.Show("Password cannot be empty.");
                return;
            }

            string hashedPassword = HashPassword(rawPassword);
            SaveFieldToDatabase("userpassword", hashedPassword);
            ToggleEditMode(PasswordTextBox);
        }

        // Mengaktifkan atau menonaktifkan mode edit
        private void ToggleEditMode(TextBox textBox)
        {
            textBox.IsReadOnly = !textBox.IsReadOnly;
            textBox.Background = textBox.IsReadOnly
                ? System.Windows.Media.Brushes.Transparent
                : new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
        }

        // Menyimpan data ke database
        private void SaveFieldToDatabase(string columnName, string newValue)
        {
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();

                string userEmailOrUsername = App.LoggedInEmailorUsername;
                string query = $"UPDATE useraccount SET {columnName} = @NewValue WHERE useremail = @Email OR username = @Username";

                using (var command = new NpgsqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@NewValue", (object)newValue ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Email", userEmailOrUsername);
                    command.Parameters.AddWithValue("@Username", userEmailOrUsername);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"{columnName} updated successfully.");
                        ResetFieldBackground(columnName);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the field.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn?.Close();
            }
        }

        // Fungsi hashing password
        private string HashPassword(string password)
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

        private void ResetFieldBackground(string columnName)
        {
            // Konversi string warna semula (#04944F) ke Color
            System.Windows.Media.Color color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#04944F");

            if (columnName == "useremail")
                EmailTextBox.Background = new System.Windows.Media.SolidColorBrush(color);
            else if (columnName == "phone")
                PhoneTextBox.Background = new System.Windows.Media.SolidColorBrush(color);
            else if (columnName == "gender")
                GenderTextBox.Background = new System.Windows.Media.SolidColorBrush(color);
            else if (columnName == "dob")
                DobTextBox.Background = new System.Windows.Media.SolidColorBrush(color);
            else if (columnName == "address")
                SellerAddressTextBox.Background = new System.Windows.Media.SolidColorBrush(color);
            else if (columnName == "userpassword")
                PasswordTextBox.Background = new System.Windows.Media.SolidColorBrush(color);
        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButtonStyles();

            if (sender is Button clickedButton)
            {
                clickedButton.Style = (Style)FindResource("ActiveButtonStyle");
                SetHighlightPosition(clickedButton);

                switch (clickedButton.Content.ToString())
                {
                    case "Seller Center":
                        NavigationService.Navigate(new SellerCenter());
                        break;
                    case "Manage Order":
                        NavigationService.Navigate(new ManageOrder());
                        break;
                    case "Messages":
                        NavigationService.Navigate(new MessagesPage());
                        break;
                    case "Settings":
                        NavigationService.Navigate(new SettingsPage());
                        break;
                    case "Seller Profile":
                        NavigationService.Navigate(new SellerProfile());
                        break;
                }

                NavigationService.RemoveBackEntry();
            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Yakin ingin melakukan log out?",
                "Konfirmasi Log Out",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var loginWindow = new LoginPage();
                loginWindow.Show();

                Window.GetWindow(this)?.Close();
            }
        }

        private void ResetButtonStyles()
        {
            SellerCenterButton.Style = (Style)FindResource("InactiveButtonStyle");
            ManageOrderButton.Style = (Style)FindResource("InactiveButtonStyle");
            SellerProfileButton.Style = (Style)FindResource("InactiveButtonStyle");
        }

        private void SetHighlightPosition(Button button)
        {
            if (button != null)
            {
                ActiveHighlight.Visibility = Visibility.Visible;
                double buttonPositionY = button.TranslatePoint(new Point(0, 0), this).Y;
                Debug.WriteLine($"Button Position Y: {buttonPositionY}");
                Canvas.SetTop(ActiveHighlight, buttonPositionY);
            }
            else
            {
                ActiveHighlight.Visibility = Visibility.Collapsed;
            }
        }

        private void MoveToCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            // Pindah ke halaman SellerCenter
            NavigationService.Navigate(new DashboardPage());
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            // Handle navigation event if necessary
        }
    }
}