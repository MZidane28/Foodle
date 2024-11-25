using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Npgsql; // Assuming you are using Npgsql for PostgreSQL connection
using Project_Foodle.Foodle;

namespace Project_Foodle.Seller
{
    public partial class SellerCenter : Page
    {
        private string connString = "Host=foodle-application-foodle-application.h.aivencloud.com;Port=26047;Username=avnadmin;Password=AVNS_k_H25YfvkdcfYfDq7ph;Database=Project-Foodle;SslMode=Require;Trust Server Certificate=true";

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
                }
                NavigationService.RemoveBackEntry(); // Remove previous navigation entry
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
                // Buka LoginPage sebagai Window
                var loginWindow = new LoginPage(); // LoginPage adalah Window
                loginWindow.Show();

                // Tutup window saat ini
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
                Canvas.SetTop(ActiveHighlight, buttonPositionY);
            }
            else
            {
                ActiveHighlight.Visibility = Visibility.Collapsed;
            }
        }

        private void UploadItemButton_Click(object sender, RoutedEventArgs e)
        {
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
                                Category = reader.GetString(5),
                                IsEditing = false // Default to not editing
                            });
                        }

                        ActiveItemsListView.ItemsSource = items;
                        TotalItemsText.Text = items.Count.ToString();
                    }
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button?.Tag is ProductItem item)
            {
                // Set IsEditing to true to enable editing
                item.IsEditing = true;
                ActiveItemsListView.Items.Refresh(); // Refresh the ListView to apply changes
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button?.Tag is ProductItem item)
            {
                // Set IsEditing to false to disable editing
                item.IsEditing = false;

                // Save changes to database
                UpdateProductInDatabase(item);

                // Refresh ListView
                ActiveItemsListView.Items.Refresh();
                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void UpdateProductInDatabase(ProductItem product)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = "UPDATE public.products SET name = @name, price = @price, stock = @stock, image_path = @imagePath WHERE id = @id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("name", product.Name);
                        cmd.Parameters.AddWithValue("price", product.Price);
                        cmd.Parameters.AddWithValue("stock", product.Stock);
                        cmd.Parameters.AddWithValue("imagePath", product.ImagePath);
                        cmd.Parameters.AddWithValue("id", product.Id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button?.Tag is ProductItem item)
            {
                // Konfirmasi penghapusan
                var result = MessageBox.Show($"Are you sure you want to delete the product '{item.Name}'?",
                                             "Confirm Delete",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    // Hapus item dari database
                    DeleteProductFromDatabase(item);

                    // Refresh ListView
                    LoadActiveItems();
                    MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void DeleteProductFromDatabase(ProductItem product)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = "DELETE FROM public.products WHERE id = @id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("id", product.Id);

                        cmd.ExecuteNonQuery(); // Jalankan query delete
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }

    public class ProductItem : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }

        private bool _isEditing;
        public bool IsEditing
        {
            get => _isEditing;
            set
            {
                _isEditing = value;
                OnPropertyChanged(nameof(IsEditing));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}