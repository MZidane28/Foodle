using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Npgsql;
using Project_Foodle.Foodle;

namespace Project_Foodle.Customer
{
    public partial class OrdersPage : Page
    {
        private readonly string _connectionString = "Host=foodle-application-foodle-application.h.aivencloud.com;Port=26047;Username=avnadmin;Password=AVNS_k_H25YfvkdcfYfDq7ph;Database=Project-Foodle;SslMode=Require;Trust Server Certificate=true";

        public OrdersPage()
        {
            InitializeComponent();
            OrdersButton.Style = (Style)FindResource("ActiveButtonStyle");
            SetHighlightPosition(OrdersButton);

            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                string loggedInUsername = LoadUsername();
                if (string.IsNullOrEmpty(loggedInUsername))
                {
                    return; // Stop if username is not found
                }

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT p.product_id, p.quantity, p.username, p.purchase_date, p.total_amount, 
                               p.payment_method, p.alamat_pengiriman, 
                               pr.name AS product_name, pr.price, pr.image_path 
                        FROM purchases p
                        JOIN products pr ON p.product_id = pr.id
                        WHERE p.username = @Username";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", loggedInUsername);

                        using (var reader = cmd.ExecuteReader())
                        {
                            var orders = new List<OrderItem>();
                            while (reader.Read())
                            {
                                orders.Add(new OrderItem
                                {
                                    ProductName = reader["product_name"].ToString(),
                                    Quantity = $"Quantity: {reader["quantity"]}",
                                    Price = $"Price: Rp {Convert.ToDecimal(reader["price"]):N}",
                                    TotalAmount = $"Total Amount: Rp {Convert.ToDecimal(reader["total_amount"]):N}",
                                    Username = $"Purchased by: {reader["username"]}",
                                    PurchaseDate = $"Date: {Convert.ToDateTime(reader["purchase_date"]).ToString("dd MMM yyyy HH:mm")}",
                                    PaymentMethod = $"Payment: {reader["payment_method"]}",
                                    ShippingAddress = $"Address: {reader["alamat_pengiriman"]}",
                                    ImagePath = reader["image_path"].ToString()
                                });
                            }

                            OrdersList.ItemsSource = orders;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string LoadUsername()
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    string userEmailOrUsername = App.LoggedInEmailorUsername;
                    string query = "SELECT username FROM useraccount WHERE useremail = @Email OR username = @Username";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", userEmailOrUsername);
                        command.Parameters.AddWithValue("@Username", userEmailOrUsername);

                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("User not found. Please log in again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading username: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return string.Empty;
            }
        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButtonStyles();

            if (sender is Button clickedButton)
            {
                clickedButton.Style = (Style)FindResource("ActiveButtonStyle");
                SetHighlightPosition(clickedButton);

                string destinationPage = clickedButton.Content.ToString();
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
    }

    public class OrderItem
    {
        public string ProductName { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string TotalAmount { get; set; }
        public string Username { get; set; }
        public string PurchaseDate { get; set; }
        public string PaymentMethod { get; set; }
        public string ShippingAddress { get; set; }
        public string ImagePath { get; set; }
    }
}
