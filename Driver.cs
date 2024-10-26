﻿using Order1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User1;

namespace Driver1
{
    internal class Driver : User
    {
        private string _vehicleType;

        public string DriverName
        {
            get { return UserName; }
            set { UserName = value; }
        }

        public string VehicleType
        {
            get { return _vehicleType; }
            set { _vehicleType = value; }
        }

        public void PickupOrder(Order order)
        {
            Console.WriteLine("Do you want to pick up this order? (yes/no):");
            string userInput = Console.ReadLine()?.Trim().ToLower();

            if (userInput == "yes")
            {
                Console.WriteLine("Order picked up. Please proceed to deliver the order.");
            }
            else
            {
                Console.WriteLine("You chose not to pick up the order.");
            }
        }

        public void DeliverOrder(Order order)
        {
            if (order.OrderStatus == "Sedang Disiapkan")
            {
                Console.WriteLine("The order is ready to be delivered.");
                Console.WriteLine("Confirm delivery by typing 'confirm':");
                string userInput = Console.ReadLine()?.Trim().ToLower();

                if (userInput == "confirm")
                {
                    if (order.OrderStatus == "Sedang Disiapkan")
                    {
                        order.OrderStatus = "Sedang Dikirim";
                        Console.WriteLine("Order status updated to 'Sedang Dikirim'.");
                    }
                }
                else
                {
                    Console.WriteLine("Delivery not confirmed.");
                }
            }
            else if (order.OrderStatus == "Sedang Dikirim")
            {
                Console.WriteLine("The order is on the way.");
                Console.WriteLine("Confirm delivery completion by typing 'confirm':");
                string userInput = Console.ReadLine()?.Trim().ToLower();

                if (userInput == "confirm")
                {
                    if (order.OrderStatus == "Sedang Dikirim")
                    {
                        order.OrderStatus = "Sudah Sampai";
                        Console.WriteLine("Order status updated to 'Sudah Sampai'.");
                    }
                }
                else
                {
                    Console.WriteLine("Delivery completion not confirmed.");
                }
            }
            else
            {
                Console.WriteLine("Order is not in a valid status for delivery or completion.");
            }
        }

        public void DisplayDriverRating(Dictionary<string, int> driverRatings)
        {
            if (driverRatings.TryGetValue(DriverName, out int totalRating))
            {
                double averageRating = driverRatings.Values.Average();
                Console.WriteLine($"Driver {DriverName} has an average rating of {averageRating:F1} stars based on {driverRatings.Count} ratings.");
            }
            else
            {
                Console.WriteLine($"No ratings available for driver {DriverName}.");
            }
        }
    }
}
