using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using User1;
using Order1;

namespace Seller1
{
    class Seller : User
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

        public string AcceptOrder(string orderedItem)
        {
            if (_sellerMenu.Contains(orderedItem))
            {
                Console.WriteLine($"Order for {orderedItem} received. Do you want to accept this order? (Yes/No)");
                string response = Console.ReadLine().ToLower();

                if (response == "yes")
                {
                    return $"Order for {orderedItem} has been accepted.";
                }
                else if (response == "no")
                {
                    return $"Order for {orderedItem} has been declined.";
                }
                else
                {
                    return "Invalid input. The order has been canceled.";
                }
            }
            else
            {
                return $"Sorry, {orderedItem} is not available on the menu.";
            }
        }

        public void UpdateOrderStatus(Order order)
        {
            if (order.OrderStatus == "Tunggu respon seller dulu, ya")
            {
                Console.WriteLine("The order is currently in 'Tunggu respon seller dulu, ya' status.");
                Console.WriteLine("Confirm to update status to 'Bentar ya, lagi disiapin' by typing 'confirm':");
                string userInput = Console.ReadLine()?.Trim().ToLower();

                if (userInput == "confirm")
                {
                    if (order.OrderStatus == "Tunggu respon seller dulu, ya")
                    {
                        order.OrderStatus = "Bentar ya, lagi disiapin";
                        Console.WriteLine("Order status updated to 'Bentar ya, lagi disiapin'.");

                        // Additional logic for changing status to 'Siap nih!'
                        Console.WriteLine("Confirm to update status to 'Siap nih!' by typing 'confirm' again:");
                        userInput = Console.ReadLine()?.Trim().ToLower();

                        if (userInput == "confirm")
                        {
                            if (order.OrderStatus == "Bentar ya, lagi disiapin")
                            {
                                order.OrderStatus = "Siap nih!";
                                Console.WriteLine("Order status updated to 'Siap nih!'.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Status update to 'Siap nih!' not confirmed.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Status update to 'Bentar ya, lagi disiapin' not confirmed.");
                }
            }
            else if (order.OrderStatus == "Bentar ya, lagi disiapin")
            {
                Console.WriteLine("The order is currently in 'Bentar ya, lagi disiapin' status.");
                Console.WriteLine("Confirm to update status to 'Siap nih!' by typing 'confirm':");
                string userInput = Console.ReadLine()?.Trim().ToLower();

                if (userInput == "confirm")
                {
                    if (order.OrderStatus == "Bentar ya, lagi disiapin")
                    {
                        order.OrderStatus = "Siap nih!";
                        Console.WriteLine("Order status updated to 'Siap nih!'.");
                    }
                }
                else
                {
                    Console.WriteLine("Status update to 'Siap nih!' not confirmed.");
                }
            }
            else
            {
                Console.WriteLine("Order status is not 'Tunggu respon seller dulu, ya' or 'Bentar ya, lagi disiapin'. No update needed.");
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