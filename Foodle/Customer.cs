using System;
using System.Collections.Generic;

namespace Foodle2
{
    using Foodle1;
    class Customer : User
    {
        public string CustomerAddress { get; set; }
        public List<Order> CustomerOrder { get; set; }

        public Customer()
        {
            CustomerOrder = new List<Order>();
        }

        public Order PlaceOrder()
        {
            // Implementasi logika untuk melakukan pemesanan
            Order newOrder = new Order();
            CustomerOrder.Add(newOrder);
            return newOrder;
        }

        public Order[] TrackOrder()
        {
            // Implementasi logika untuk melacak pesanan
            return CustomerOrder.ToArray();
        }

        public void WriteReview()
        {
            // Implementasi logika untuk menulis ulasan
        }
    }

    public class Order
    {
        // Implementasi logika untuk kelas Order
    }
}