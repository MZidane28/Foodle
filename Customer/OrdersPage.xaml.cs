using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Project_Foodle.Customer
{
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            LoadOrders();
        }

        // Example Order class
        public class Order
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public DateTime OrderDate { get; set; }
        }

        // Sample list of orders
        private List<Order> Orders { get; set; }

        // Load orders for demonstration
        private void LoadOrders()
        {
            Orders = new List<Order>
            {
                new Order { ProductName = "Product A", Quantity = 2, Price = 100, OrderDate = DateTime.Now.AddDays(-1) },
                new Order { ProductName = "Product B", Quantity = 1, Price = 50, OrderDate = DateTime.Now.AddDays(-3) },
                new Order { ProductName = "Product C", Quantity = 5, Price = 200, OrderDate = DateTime.Now.AddDays(-10) }
            };

            // Set the orders to the ListView
            OrdersListView.ItemsSource = Orders;
        }

        // Handle sort selection changes
        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                if (selectedItem.Content.ToString() == "Sort by Date (Newest)")
                {
                    OrdersListView.ItemsSource = Orders.OrderByDescending(o => o.OrderDate).ToList();
                }
                else
                {
                    OrdersListView.ItemsSource = Orders.OrderBy(o => o.OrderDate).ToList();
                }
            }
        }

        // Handle date filter button click
        private void FilterByDateButton_Click(object sender, RoutedEventArgs e)
        {
            // Open a date picker dialog or use hardcoded date range for simplicity
            DateTime startDate = DateTime.Now.AddDays(-7); // For example, filter orders from the past 7 days
            DateTime endDate = DateTime.Now;

            var filteredOrders = Orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).ToList();
            OrdersListView.ItemsSource = filteredOrders;
        }
    }
}
