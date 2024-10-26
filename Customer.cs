using Order1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User1;

namespace Customer1
{
    internal class Customer : User
    {
        private string _customerAddress;
        private List<Order> _customerOrders;
        private Dictionary<string, string> _sellerReviews;
        private Dictionary<string, int> _driverRatings;

        public string CustomerName
        {
            get { return UserName; }
            set { UserName = value; }
        }

        public Customer()
        {
            _customerOrders = new List<Order>();
            _sellerReviews = new Dictionary<string, string>();
            _driverRatings = new Dictionary<string, int>();
        }

        public string CustomerAddress
        {
            get { return _customerAddress; }
            set { _customerAddress = value; }
        }

        public List<Order> CustomerOrders
        {
            get { return _customerOrders; }
        }

        public Dictionary<string, string> SellerReviews
        {
            get { return _sellerReviews; }
        }

        public Dictionary<string, int> DriverRatings
        {
            get { return _driverRatings; }
        }

        public void AddOrder(Order order)
        {
            Console.WriteLine("Do you want to add this order? (yes/no):");
            string userInput = Console.ReadLine()?.Trim().ToLower();

            if (userInput == "yes")
            {
                _customerOrders.Add(order);
                Console.WriteLine("Order added successfully.");
            }
            else
            {
                Console.WriteLine("Order was not added.");
            }
        }

        public void TrackOrder()
        {
            if (CustomerOrders.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }

            foreach (var order in CustomerOrders)
            {
                Console.WriteLine($"OrderID: {order.OrderID}");
                Console.WriteLine($"Order Status: {order.OrderStatus}");
            }
        }

        public void WriteReview(string SellerName)
        {
            Console.WriteLine($"Please write your review for {SellerName}:");
            string review = Console.ReadLine();
            _sellerReviews[SellerName] = review;
            Console.WriteLine($"Thank you! Your review for {SellerName} has been submitted.");
        }

        public void RateDriver(string DriverName)
        {
            Console.WriteLine($"Please rate the driver {DriverName} on a scale of 1 to 5:");
            int rating;
            while (!int.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 5)
            {
                Console.WriteLine("Invalid rating. Please enter a number between 1 and 5:");
            }

            _driverRatings[DriverName] = rating;
            Console.WriteLine($"Thank you! You rated the driver {DriverName} with {rating} stars.");
        }
    }
}