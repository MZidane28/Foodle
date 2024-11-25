using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Npgsql;
using Project_Foodle.Foodle;
using Project_Foodle.Models;

namespace Project_Foodle.Driver
{
    public partial class DriverDashboard : Page
    {
        private readonly string _connectionString = "Host=foodle-application-foodle-application.h.aivencloud.com;Port=26047;Username=avnadmin;Password=AVNS_k_H25YfvkdcfYfDq7ph;Database=Project-Foodle;SslMode=Require;Trust Server Certificate=true";

        public DriverDashboard()
        {
            InitializeComponent();
            DriverDashboardButton.Style = (Style)FindResource("ActiveButtonStyle");
            SetHighlightPosition(DriverDashboardButton);
            LoadDashboardData(); // Load data saat halaman dibuka
        }

        private void LoadDashboardData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    purchases.username AS customer_username,
                    purchases.product_id,
                    products.name AS product_name,
                    products.price,
                    products.category,
                    products.image_path,
                    products.username AS seller_username
                FROM purchases
                INNER JOIN products ON purchases.product_id = products.id;";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        DashboardStackPanel.Children.Clear(); // Clear previous data

                        while (reader.Read())
                        {
                            // Create Border for each item
                            Border border = new Border
                            {
                                Background = System.Windows.Media.Brushes.White,
                                CornerRadius = new System.Windows.CornerRadius(10),
                                Margin = new Thickness(0, 0, 0, 10),
                                Padding = new Thickness(10),
                                BorderBrush = System.Windows.Media.Brushes.LightGray,
                                BorderThickness = new Thickness(1)
                            };

                            // Create Grid inside the Border
                            Grid grid = new Grid();
                            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
                            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                            // Add Image to Grid
                            Image image = new Image
                            {
                                Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(reader["image_path"].ToString(), UriKind.RelativeOrAbsolute)),
                                Width = 100,
                                Height = 100,
                                Margin = new Thickness(10)
                            };
                            Grid.SetColumn(image, 0);
                            grid.Children.Add(image);

                            // Add Details to Grid
                            StackPanel detailsPanel = new StackPanel { Margin = new Thickness(10) };
                            detailsPanel.Children.Add(new TextBlock { Text = reader["product_name"].ToString(), FontFamily = new System.Windows.Media.FontFamily("Poppins SemiBold"), FontSize = 20 });
                            detailsPanel.Children.Add(new TextBlock { Text = $"Category: {reader["category"]}", FontSize = 16, Foreground = System.Windows.Media.Brushes.Gray });
                            detailsPanel.Children.Add(new TextBlock { Text = $"Price: {reader["price"]:C}", FontSize = 16, Foreground = System.Windows.Media.Brushes.Green });
                            detailsPanel.Children.Add(new TextBlock { Text = $"Seller: {reader["seller_username"]}", FontSize = 14, Foreground = System.Windows.Media.Brushes.Gray });
                            detailsPanel.Children.Add(new TextBlock { Text = $"Customer: {reader["customer_username"]}", FontSize = 14, Foreground = System.Windows.Media.Brushes.Gray });
                            Grid.SetColumn(detailsPanel, 1);
                            grid.Children.Add(detailsPanel);

                            // Add Grid to Border
                            border.Child = grid;

                            // Add Border to StackPanel
                            DashboardStackPanel.Children.Add(border);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard data: " + ex.Message);
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

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButtonStyles();

            if (sender is Button clickedButton)
            {
                clickedButton.Style = (Style)FindResource("ActiveButtonStyle");
                SetHighlightPosition(clickedButton);

                switch (clickedButton.Content.ToString())
                {
                    case "Driver Dashboard":
                        NavigationService.Navigate(new DriverDashboard());
                        break;
                    case "Driver Profile":
                        NavigationService.Navigate(new DriverProfile());
                        break;
                }

                NavigationService.RemoveBackEntry();
            }
        }

        private void ResetButtonStyles()
        {
            DriverDashboardButton.Style = (Style)FindResource("InactiveButtonStyle");
            DriverProfileButton.Style = (Style)FindResource("InactiveButtonStyle");
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
    }

    // Model untuk item dashboard
    public class DashboardItem
    {
        public string CustomerUsername { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }
        public string SellerUsername { get; set; }
    }
}