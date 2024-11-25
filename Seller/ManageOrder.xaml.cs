using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Npgsql;
using Project_Foodle.Foodle;

namespace Project_Foodle.Seller
{
    public partial class ManageOrder : Page
    {
        // Koneksi ke database (ganti dengan informasi koneksi Anda)
        private readonly string _connectionString = "Host=foodle-application-foodle-application.h.aivencloud.com;Port=26047;Username=avnadmin;Password=AVNS_k_H25YfvkdcfYfDq7ph;Database=Project-Foodle;SslMode=Require;Trust Server Certificate=true";

        public ManageOrder()
        {
            InitializeComponent();
            LoadOrders(); // Memuat data pesanan ke DataGrid
            ManageOrderButton.Style = (Style)FindResource("ActiveButtonStyle"); // Menandai tombol aktif
        }

        /// <summary>
        /// Event handler untuk tombol navigasi
        /// </summary>
        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset semua gaya tombol ke default
            ResetButtonStyles();

            // Identifikasi tombol yang diklik
            if (sender is Button clickedButton)
            {
                // Ganti gaya tombol yang diklik ke gaya aktif
                clickedButton.Style = (Style)FindResource("ActiveButtonStyle");

                // Navigasi ke halaman yang sesuai
                switch (clickedButton.Content.ToString())
                {
                    case "Seller Center":
                        NavigationService.Navigate(new SellerCenter());
                        break;
                    case "Manage Order":
                        // Sudah berada di halaman Manage Order
                        break;
                    case "Seller Profile":
                        NavigationService.Navigate(new SellerProfile());
                        break;
                    default:
                        MessageBox.Show("Unknown navigation target.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                }
            }
        }

        /// <summary>
        /// Event handler untuk tombol Log Out
        /// </summary>
        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            // Konfirmasi log out
            MessageBoxResult result = MessageBox.Show(
                "Yakin ingin melakukan log out?",
                "Konfirmasi Log Out",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Buka halaman login sebagai window baru
                var loginWindow = new LoginPage(); // Pastikan LoginPage adalah Window
                loginWindow.Show();

                // Tutup window saat ini
                Window.GetWindow(this)?.Close();
            }
        }

        /// <summary>
        /// Mereset semua gaya tombol navigasi ke default
        /// </summary>
        private void ResetButtonStyles()
        {
            SellerCenterButton.Style = (Style)FindResource("InactiveButtonStyle");
            ManageOrderButton.Style = (Style)FindResource("InactiveButtonStyle");
            SellerProfileButton.Style = (Style)FindResource("InactiveButtonStyle");
        }

        /// <summary>
        /// Memuat username pengguna yang sedang login
        /// </summary>
        /// <returns>Username pengguna</returns>
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
                        return result?.ToString() ?? string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading username: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return string.Empty;
            }
        }

        /// <summary>
        /// Memuat data pesanan dari database ke DataGrid
        /// </summary>
        private void LoadOrders()
        {
            string username = LoadUsername();

            if (string.IsNullOrEmpty(username))
                return;

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT p.id AS ProductId, p.name AS ProductName, p.image_path AS ImagePath, 
                       pr.quantity AS Quantity, pr.total_amount AS TotalAmount, 
                       pr.purchase_date AS PurchaseDate, pr.alamat_pengiriman AS DeliveryAddress
                FROM purchases pr
                INNER JOIN products p ON pr.product_id = p.id
                WHERE p.username = @Username";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        using (var reader = command.ExecuteReader())
                        {
                            var orders = new List<Order>();

                            while (reader.Read())
                            {
                                orders.Add(new Order
                                {
                                    OrderId = reader["ProductId"].ToString(),
                                    ProductName = reader["ProductName"].ToString(),
                                    ImagePath = reader["ImagePath"].ToString(), // Ambil path gambar
                                    Quantity = Convert.ToInt32(reader["Quantity"]),
                                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                                    PurchaseDate = Convert.ToDateTime(reader["PurchaseDate"]),
                                    DeliveryAddress = reader["DeliveryAddress"].ToString()
                                });
                            }

                            OrdersList.ItemsSource = orders; // Assign ke ItemsControl
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        /// <summary>
        /// Class untuk merepresentasikan data pesanan
        /// </summary>
        public class Order
        {
            public string OrderId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal TotalAmount { get; set; }
            public DateTime PurchaseDate { get; set; }
            public string DeliveryAddress { get; set; }
            public string ImagePath { get; set; } // Properti baru untuk path gambar
        }

    }
}