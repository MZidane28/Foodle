using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodle
{
    class Order
    {
        private string _orderID;
        private string _orderStatus;
        private DateTime _orderTime;
        private float _orderTotal;
        private string _restaurant;

        public string OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }
        public string OrderStatus
        {
            get { return _orderStatus; }
            set { _orderStatus = value; }
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

        public void updateStatus (string status)
        {
            _orderStatus = status;
        }
        public float CalculateTotal()
        {
            return _orderTotal;
        }
    }
}