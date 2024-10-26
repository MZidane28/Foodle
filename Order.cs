using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order1
{
    internal class Order
    {
        private string _orderID;
        private DateTime _orderTime;
        private float _orderTotal;
        private string _restaurant;

        public string OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        public DateTime OrderTime
        {
            get { return _orderTime; }
            set { _orderTime = value; }
        }

        public float OrderTotal
        {
            get { return _orderTotal; }
            set { _orderTotal = value; }
        }

        public string Restaurant
        {
            get { return _restaurant; }
            set { _restaurant = value; }
        }

        public string OrderStatus { get; set; } = "Pending";

        public void UpdateStatusByRestaurant()
        {
            if (OrderStatus == "Pending")
            {
                OrderStatus = "Sedang Disiapkan";
                Console.WriteLine($"Order status updated by Restaurant: {OrderStatus}");
            }
            else
            {
                Console.WriteLine("Invalid status update by Restaurant.");
            }
        }

        public void UpdateStatusByDriver()
        {
            if (OrderStatus == "Sedang Disiapkan")
            {
                OrderStatus = "Sedang Dikirim";
                Console.WriteLine($"Order status updated by Driver: {OrderStatus}");
            }
            else if (OrderStatus == "Sedang Dikirim")
            {
                OrderStatus = "Sudah Sampai";
                Console.WriteLine($"Order status updated by Driver: {OrderStatus}");
            }
            else
            {
                Console.WriteLine("Invalid status update by Driver.");
            }
        }

        public float CalculateTotal(int quantity, float pricePerItem)
        {
            OrderTotal = quantity * pricePerItem;
            return OrderTotal;
        }
    }
}
