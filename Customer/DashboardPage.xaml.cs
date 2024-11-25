using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Npgsql;
using Project_Foodle.Foodle;
using Project_Foodle.Models;

namespace Project_Foodle.Customer
{
    public partial class DashboardPage : Page
    {
        private readonly string _connectionString = "Host=foodle-application-foodle-application.h.aivencloud.com;Port=26047;Username=avnadmin;Password=AVNS_k_H25YfvkdcfYfDq7ph;Database=Project-Foodle;SslMode=Require;Trust Server Certificate=true";

        public DashboardPage()
        {
            InitializeComponent();
            DashboardButton.Style = (Style)FindResource("ActiveButtonStyle");
            SetHighlightPosition(DashboardButton);
            LoadAddressData(); // Load address data (default and shipping)
            LoadProductData(); // Load product data from the database
        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButtonStyles();

            if (sender is Button clickedButton)
            {
                clickedButton.Style = (Style)FindResource("ActiveButtonStyle");
                SetHighlightPosition(clickedButton);

                string destinationPage = clickedButton.Content.ToString();
                HandleNavigationRequest(destinationPage);
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
            DashboardButton.Style = (Style)FindResource("InactiveButtonStyle");
            OrdersButton.Style = (Style)FindResource("InactiveButtonStyle");
            AccountProfileButton.Style = (Style)FindResource("InactiveButtonStyle");
        }

        private void SetHighlightPosition(Button button)
        {
            if (button != null)
            {
                ActiveHighlight.Visibility = Visibility.Visible;
                double buttonPositionY = button.TranslatePoint(new Point(0, 0), this).Y;
                Canvas.SetTop(ActiveHighlight, buttonPositionY);
            }
            else
            {
                ActiveHighlight.Visibility = Visibility.Collapsed;
            }
        }

        public void LoadProductData()
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, name, price, stock, category, image_path, username FROM products";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var products = new List<Product>();
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("id")),
                                Name = reader["name"].ToString(),
                                Price = Convert.ToDecimal(reader["price"]),
                                Stock = Convert.ToInt32(reader["stock"]),
                                Category = reader["category"].ToString(),
                                ImagePath = reader["image_path"].ToString(),
                                Username = reader["username"].ToString(),
                                SelectedQuantity = 1
                            });
                        }

                        ProductList.ItemsSource = products;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadAddressData()
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT address, alamat_pengiriman FROM useraccount WHERE id = @UserId";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        int userId = 1; // Replace with actual logged-in user ID
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string defaultAddress = reader["address"].ToString();
                                DefaultAddressTextBlock.Text = defaultAddress;

                                string shippingAddress = reader["alamat_pengiriman"]?.ToString();
                                ShippingAddressTextBox.Text = string.IsNullOrWhiteSpace(shippingAddress) ? defaultAddress : shippingAddress;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading address data: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditAddress_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button editButton)
            {
                editButton.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(211, 47, 47)); // Red
            }

            ShippingAddressTextBox.IsReadOnly = false;
            SaveAddressButton.IsEnabled = true;
        }

        private void SaveShippingAddress_Click(object sender, RoutedEventArgs e)
        {
            string shippingAddress = ShippingAddressTextBox.Text.Trim();

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = string.IsNullOrWhiteSpace(shippingAddress)
                        ? "UPDATE useraccount SET alamat_pengiriman = NULL WHERE id = @UserId"
                        : "UPDATE useraccount SET alamat_pengiriman = @ShippingAddress WHERE id = @UserId";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        int userId = 1; // Replace with actual logged-in user ID
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        if (!string.IsNullOrWhiteSpace(shippingAddress))
                            cmd.Parameters.AddWithValue("@ShippingAddress", shippingAddress);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Alamat pengiriman berhasil disimpan.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            LoadAddressData(); // Reload addresses to reflect the changes
                        }
                        else
                        {
                            MessageBox.Show("Gagal menyimpan alamat pengiriman.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }

                ShippingAddressTextBox.IsReadOnly = true;
                SaveAddressButton.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving shipping address: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Product product)
            {
                if (product.SelectedQuantity > 1)
                {
                    product.SelectedQuantity--;
                    ProductList.Items.Refresh();
                }
            }
        }

        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Product product)
            {
                if (product.SelectedQuantity < product.Stock)
                {
                    product.SelectedQuantity++;
                    ProductList.Items.Refresh();
                }
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button buyButton)
            {
                try
                {
                    if (!(buyButton.DataContext is Product selectedProduct))
                    {
                        MessageBox.Show("Failed to retrieve product data.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (selectedProduct.Stock == 0)
                    {
                        MessageBox.Show("This product is out of stock.", "Out of Stock", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    // Replace with actual username if required
                    string usernamePlaceholder = "defaultUser"; // Placeholder string for username
                    var buyProductPage = new BuyProduct(selectedProduct.ID, selectedProduct.SelectedQuantity);

                    buyProductPage.RequestNavigation += HandleNavigationRequest;

                    MainFrame.Navigate(buyProductPage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during purchase: {ex.Message}", "Purchase Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void HandleNavigationRequest(string destinationPage)
        {
            Page targetPage = null;

            switch (destinationPage)
            {
                case "Dashboard":
                    targetPage = new DashboardPage();
                    break;
                case "Orders":
                    targetPage = new OrdersPage();
                    break;
                case "Messages":
                    targetPage = new MessagesPage();
                    break;
                case "Settings":
                    targetPage = new SettingsPage();
                    break;
                case "Account Profile":
                    targetPage = new AccountProfile();
                    break;
            }

            if (targetPage != null && NavigationService.Content.GetType() != targetPage.GetType())
            {
                NavigationService.Navigate(targetPage);
            }
        }
    }
}
