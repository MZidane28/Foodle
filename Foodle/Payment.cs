using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment1
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
            // Cek apakah metode pembayaran valid
            if (string.IsNullOrEmpty(_paymentMethod))
            {
                Console.WriteLine("Metode pembayaran tidak valid.");
                return;
            }

            // Cek apakah jumlah pembayaran valid
            if (_paymentAmount <= 0)
            {
                Console.WriteLine("Jumlah pembayaran tidak valid.");
                return;
            }

            // Proses pembayaran
            Console.WriteLine("Pembayaran sedang diproses...");
            Console.WriteLine($"ID Pembayaran: {_paymentID}");
            Console.WriteLine($"Metode Pembayaran: {_paymentMethod}");
            Console.WriteLine($"Jumlah Pembayaran: {_paymentAmount}");

            // Konfirmasi pembayaran berhasil
            Console.WriteLine("Pembayaran berhasil diproses.");
        }
    }
}