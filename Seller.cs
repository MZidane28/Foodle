using Order1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User1;

namespace Seller1
{
    internal class Seller : User
    {
        private string _sellerAddress;
        private List<string> _sellerMenu;

        public string SellerName
        {
            get { return UserName; }
            set { UserName = value; }
        }

        public string SellerAddress
        {
            get { return _sellerAddress; }
            set { _sellerAddress = value; }
        }

        public List<string> SellerMenu
        {
            get { return _sellerMenu; }
            set { _sellerMenu = value; }
        }

        public Seller()
        {
            _sellerMenu = new List<string>();
        }

        public void UpdateMenu()
        {
            Console.WriteLine("Current menu:");
            DisplayMenu();

            Console.WriteLine("Do you want to add a new item or remove an existing one? (add/remove/none):");
            string action = Console.ReadLine()?.Trim().ToLower();

            if (action == "add")
            {
                Console.WriteLine("Enter the name of the new menu item:");
                string newItem = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(newItem))
                {
                    _sellerMenu.Add(newItem);
                    Console.WriteLine($"Item '{newItem}' added to the menu.");
                }
                else
                {
                    Console.WriteLine("Invalid item name. No item added.");
                }
            }
            else if (action == "remove")
            {
                Console.WriteLine("Enter the name of the item to remove:");
                string itemToRemove = Console.ReadLine()?.Trim();
                if (_sellerMenu.Remove(itemToRemove))
                {
                    Console.WriteLine($"Item '{itemToRemove}' removed from the menu.");
                }
                else
                {
                    Console.WriteLine("Item not found in the menu.");
                }
            }
            else if (action == "none")
            {
                Console.WriteLine("No changes made to the menu.");
            }
            else
            {
                Console.WriteLine("Invalid option. No changes made.");
            }

            Console.WriteLine("Updated menu:");
            DisplayMenu();
        }

        private void DisplayMenu()
        {
            if (_sellerMenu.Count == 0)
            {
                Console.WriteLine("Menu is currently empty.");
            }
            else
            {
                foreach (var item in _sellerMenu)
                {
                    Console.WriteLine($"- {item}");
                }
            }
        }

        public string AcceptOrder()
        {
            return "Order diterima";
        }

        public void UpdateOrderStatus(Order order)
        {
            if (order.OrderStatus == "Pending")
            {
                Console.WriteLine("The order is currently in 'Pending' status.");
                Console.WriteLine("Confirm to update status to 'Sedang Disiapkan' by typing 'confirm':");
                string userInput = Console.ReadLine()?.Trim().ToLower();

                if (userInput == "confirm")
                {
                    if (order.OrderStatus == "Pending")
                    {
                        order.OrderStatus = "Sedang Disiapkan";
                        Console.WriteLine("Order status updated to 'Sedang Disiapkan'.");
                        Console.WriteLine("Confirm to update status to 'Selesai' by typing 'confirm' again:");
                        userInput = Console.ReadLine()?.Trim().ToLower();

                        if (userInput == "confirm")
                        {
                            if (order.OrderStatus == "Sedang Disiapkan")
                            {
                                order.OrderStatus = "Selesai";
                                Console.WriteLine("Order status updated to 'Selesai'.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Status update to 'Selesai' not confirmed.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Status update to 'Sedang Disiapkan' not confirmed.");
                }
            }
            else if (order.OrderStatus == "Sedang Disiapkan")
            {
                Console.WriteLine("The order is currently in 'Sedang Disiapkan' status.");
                Console.WriteLine("Confirm to update status to 'Selesai' by typing 'confirm':");
                string userInput = Console.ReadLine()?.Trim().ToLower();

                if (userInput == "confirm")
                {
                    if (order.OrderStatus == "Sedang Disiapkan")
                    {
                        order.OrderStatus = "Selesai";
                        Console.WriteLine("Order status updated to 'Selesai'.");
                    }
                }
                else
                {
                    Console.WriteLine("Status update to 'Selesai' not confirmed.");
                }
            }
            else
            {
                Console.WriteLine("Order status is not 'Pending' or 'Sedang Disiapkan'. No update needed.");
            }
        }

        public void DisplayReviews(Dictionary<string, string> sellerReviews)
        {
            if (sellerReviews.Count == 0)
            {
                Console.WriteLine("No reviews available.");
                return;
            }

            Console.WriteLine("Customer reviews:");
            foreach (var review in sellerReviews)
            {
                Console.WriteLine($"Seller: {review.Key}");
                Console.WriteLine($"Review: {review.Value}");
                Console.WriteLine();
            }
        }
    }
}