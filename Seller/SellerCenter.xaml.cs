using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Npgsql; // Assuming you are using Npgsql for PostgreSQL connection
using Project_Foodle.Foodle;

namespace Project_Foodle.Seller
{
    public partial class SellerCenter : Page
    {
        private NpgsqlConnection conn;
        //tambah sini
        public SellerCenter()
        {
            InitializeComponent();
            SellerCenterButton.Style = (Style)FindResource("ActiveButtonStyle");
            SetHighlightPosition(SellerCenterButton);

            LoadActiveItems();
        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButtonStyles();

            Button clickedButton = sender as Button;
            if (clickedButton != null)
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
                    default:
                        break;
                }
                NavigationService.RemoveBackEntry(); // Menghapus entry navigasi sebelumnya
            }
        }

        private void ResetButtonStyles()
        {
            SellerCenterButton.Style = (Style)FindResource("InactiveButtonStyle");
            ManageOrderButton.Style = (Style)FindResource("InactiveButtonStyle");
            MessagesButton.Style = (Style)FindResource("InactiveButtonStyle");
            SettingsButton.Style = (Style)FindResource("InactiveButtonStyle");
            SellerProfileButton.Style = (Style)FindResource("InactiveButtonStyle");
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

        // Event handler for Upload New Item button
        private void UploadItemButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the Upload Item page
            NavigationService.Navigate(new UploadItem());
        }

        private void LoadActiveItems()
        {
            string username = Application.Current.Properties["LoggedUser"] as string;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("User not logged in");
                return;
            }

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT id, name, price, stock, image_path, category FROM public.products WHERE username = @username";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        var items = new List<ProductItem>();

                        while (reader.Read())
                        {
                            items.Add(new ProductItem
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                Stock = reader.GetInt32(3),
                                ImagePath = reader.GetString(4),
                                Category = reader.GetString(5)
                            });
                        }

                        ActiveItemsListView.ItemsSource = items;
                        TotalItemsText.Text = items.Count.ToString();
                    }
                }
            }
        }
    }

    public class ProductItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }
    }
}
