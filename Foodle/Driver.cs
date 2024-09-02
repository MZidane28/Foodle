using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodle
{
    using Foodle1;
    class Driver: User
    {
        private string _vehicleType;
        private string _driverRate;


        public string VehicleType
        {
            get { return _vehicleType; }
            set { _vehicleType = value; }
        }


        public string DriverRate
        {
            get { return _driverRate; }
            set { _driverRate = value; }
        }


        public void PickupOrder()
        {
        }


        public void DeliverOrder()
        {
        }
    }
}
