using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Npgsql;

namespace Project_Foodle.Customer
{
    public partial class BuyProduct : Page
    {
        private readonly string _connectionString = "Host=foodle-application-foodle-application.h.aivencloud.com;Port=26047;Username=avnadmin;Password=AVNS_k_H25YfvkdcfYfDq7ph;Database=Project-Foodle;SslMode=Require;Trust Server Certificate=true";
        private int _selectedQuantity = 1;
        private int _maxStock = 0;
        private decimal _productPrice = 0;

        public BuyProduct(int productId, int selectedQuantity = 1)
        {
            InitializeComponent();
            _selectedQuantity = selectedQuantity;

            LoadProductData(productId);
            UpdateTotalAmount();
        }

        public event Action<string> RequestNavigation;

        private void LoadProductData(int productId)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, name, price, stock, category, image_path FROM products WHERE id = @ProductId";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", productId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ProductIDTextBlock.Text = reader.GetInt32(reader.GetOrdinal("id")).ToString();
                                ProductNameTextBlock.Text = reader["name"].ToString();
                                ProductCategoryTextBlock.Text = reader["category"].ToString();
                                ProductStockTextBlock.Text = reader.GetInt32(reader.GetOrdinal("stock")).ToString();

                                _productPrice = Convert.ToDecimal(reader["price"]);
                                ProductPriceTextBlock.Text = $"Rp {_productPrice:N}";

                                string imagePath = reader["image_path"].ToString();
                                if (!string.IsNullOrEmpty(imagePath))
                                {
                                    ProductImage.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                                }

                                _maxStock = reader.GetInt32(reader.GetOrdinal("stock"));
                                UpdateTotalAmount();
                            }
                            else
                            {
                                MessageBox.Show("Product not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product data: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateTotalAmount()
        {
            decimal totalAmount = _productPrice * _selectedQuantity;
            TotalAmountTextBlock.Text = $"Rp {totalAmount:N}";
        }

        private void PurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedQuantity > _maxStock)
            {
                MessageBox.Show("Not enough stock available for purchase.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Update the product stock
                            string updateQuery = @"
                            UPDATE products 
                            SET stock = stock - @quantity 
                            WHERE id = @productId AND stock >= @quantity 
                            RETURNING stock";
                            using (var updateCmd = new NpgsqlCommand(updateQuery, connection, transaction))
                            {
                                updateCmd.Parameters.AddWithValue("@quantity", _selectedQuantity);
                                updateCmd.Parameters.AddWithValue("@productId", int.Parse(ProductIDTextBlock.Text));

                                var result = updateCmd.ExecuteScalar();
                                if (result == null || Convert.ToInt32(result) < 0)
                                {
                                    MessageBox.Show("Failed to update stock. The stock might have changed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    transaction.Rollback();
                                    return;
                                }
                            }

                            // Calculate total amount
                            decimal totalAmount = _productPrice * _selectedQuantity;

                            // Load shipping address
                            string shippingAddress = LoadShippingAddress();
                            if (string.IsNullOrEmpty(shippingAddress))
                            {
                                transaction.Rollback();
                                return;
                            }

                            // Load username before proceeding with the purchase
                            string username = LoadUsername();
                            if (string.IsNullOrEmpty(username))
                            {
                                transaction.Rollback();
                                return;
                            }

                            // Retrieve payment method
                            string paymentMethod = PaymentMethodComboBox.Text;

                            // Insert the purchase record
                            string insertQuery = @"
                            INSERT INTO purchases (product_id, quantity, username, total_amount, alamat_pengiriman, payment_method) 
                            VALUES (@productId, @quantity, @username, @totalAmount, @alamatPengiriman, @paymentMethod)";
                            using (var insertCmd = new NpgsqlCommand(insertQuery, connection, transaction))
                            {
                                insertCmd.Parameters.AddWithValue("@productId", int.Parse(ProductIDTextBlock.Text));
                                insertCmd.Parameters.AddWithValue("@quantity", _selectedQuantity);
                                insertCmd.Parameters.AddWithValue("@username", username);
                                insertCmd.Parameters.AddWithValue("@totalAmount", totalAmount);
                                insertCmd.Parameters.AddWithValue("@alamatPengiriman", shippingAddress);
                                insertCmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);

                                insertCmd.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            MessageBox.Show("Purchase confirmed! Stock updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                            RequestNavigation?.Invoke("Orders");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Error processing purchase: {ex.Message}", "Purchase Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string LoadShippingAddress()
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    string userEmailOrUsername = App.LoggedInEmailorUsername;
                    string query = "SELECT alamat_pengiriman, address FROM useraccount WHERE useremail = @Email OR username = @Username";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", userEmailOrUsername);
                        command.Parameters.AddWithValue("@Username", userEmailOrUsername);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string shippingAddress = reader["alamat_pengiriman"]?.ToString();
                                if (string.IsNullOrWhiteSpace(shippingAddress))
                                {
                                    shippingAddress = reader["address"]?.ToString();
                                }
                                return shippingAddress;
                            }
                            else
                            {
                                MessageBox.Show("User not found. Please log in again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return string.Empty;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading shipping address: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return string.Empty;
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
    }
}
