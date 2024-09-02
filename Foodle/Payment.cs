using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodle
{
    class Payment
    {
        private string _paymentID = string.Empty;
        private string _paymentMethod = string.Empty;
        private float _paymentAmount = 0.0f;

        //Defisini Property
        public string PaymentID
        {
            get { return _paymentID; }

        }
        public string PaymentMethod
        {
            get { return _paymentMethod; }
        }
        public float PaymentAmount
        {
            get { return _paymentAmount; }
        }

        //definisikan method kelas
        public void processPayment()
        {

        }
    }
}