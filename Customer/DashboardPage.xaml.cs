using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Project_Foodle.Models; 

namespace Project_Foodle.Customer
{
    public partial class DashboardPage : Page
    {
        // Observable collection of items in the cart
        public ObservableCollection<CartItem> CartItems { get; set; }

        // List to hold products that will be displayed on the Dashboard
        public List<Product> Products { get; set; }

        public DashboardPage()
        {
            InitializeComponent();
            CartItems = new ObservableCollection<CartItem>();
            CartListView.ItemsSource = CartItems;

            // Simulate fetching product data (replace this with real data from a database or API)
            Products = FetchProductsFromDatabase();

            LoadProductList();
        }

        // Cart item class to store product details
        public class CartItem
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }

        // Load the products from the database or API
        private List<Product> FetchProductsFromDatabase()
        {
            // Simulating product data from a database or API
            return new List<Product>
            {
                new Product { ProductId = 1, Name = "Product 1", Price = 25.00m, Description = "Delicious Product 1", ImageUrl = "Images/product1.jpg" },
                new Product { ProductId = 2, Name = "Product 2", Price = 30.00m, Description = "Delicious Product 2", ImageUrl = "Images/product2.jpg" },
                new Product { ProductId = 3, Name = "Product 3", Price = 15.00m, Description = "Delicious Product 3", ImageUrl = "Images/product3.jpg" }
            };
        }

        // Load the products into the product list on the page
        private void LoadProductList()
        {
            foreach (var product in Products)
            {
                Button productButton = new Button
                {
                    Content = new StackPanel
                    {
                        Orientation = Orientation.Vertical,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Children =
                        {
                            new Image { Source = new BitmapImage(new Uri(product.ImageUrl, UriKind.RelativeOrAbsolute)), Width = 100, Height = 100 },
                            new TextBlock { Text = product.Name, FontWeight = FontWeights.Bold, HorizontalAlignment = HorizontalAlignment.Center },
                            new TextBlock { Text = $"${product.Price}", HorizontalAlignment = HorizontalAlignment.Center }
                        }
                    },
                    Style = (Style)FindResource("ProductCardStyle"),
                    Tag = product // Store product information in the Tag property
                };

                productButton.Click += ProductButton_Click;
                ProductListPanel.Children.Add(productButton);
            }
        }

        // Add the product to the cart when a product button is clicked
        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            var product = (Product)((Button)sender).Tag; // Retrieve product from the button's Tag
            AddToCart(product);
        }

        // Add product to cart
        private void AddToCart(Product product)
        {
            var existingItem = CartItems.FirstOrDefault(item => item.ProductName == product.Name);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                CartItems.Add(new CartItem { ProductName = product.Name, Quantity = 1, Price = product.Price });
            }
        }

        // Handle opening the cart popup
        private void OpenCartButton_Click(object sender, RoutedEventArgs e)
        {
            CartPopup.IsOpen = true;
        }

        // Checkout the cart (handle order processing)
        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (CartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Process checkout (e.g., go to payment page or show confirmation)
            ProcessCheckout();

            // Close the cart popup after checkout
            CartPopup.IsOpen = false;
        }

        // Process the checkout
        private void ProcessCheckout()
        {
            decimal totalAmount = 0;

            // Calculate the total amount of the cart
            foreach (var item in CartItems)
            {
                totalAmount += item.Quantity * item.Price;
            }

            // Example: Proceed to payment or order confirmation
            MessageBox.Show($"Checkout successful! Total amount: {totalAmount:C}", "Checkout", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear the cart after successful checkout
            CartItems.Clear();
        }
    }
}
