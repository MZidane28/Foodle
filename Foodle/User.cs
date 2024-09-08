using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User1
{
    class User
    {
        private string _userID;
        private string _userName;
        private string _userEmail;
        private string _phoneNumber;
        private string _userPassword;
        private bool _isLoggedIn;

        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string UserEmail
        {
            get { return _userEmail; }
            set { _userEmail = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string UserPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; }
        }

        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
        }

        public bool Login(string userName, string userPassword)
        {
            if (userName == _userName && userPassword == _userPassword)
            {
                _isLoggedIn = true;
                Console.WriteLine("Login Berhasil");
                return true;
            }
            else
            {
                Console.WriteLine("Login Gagal. Silakan Coba Lagi");
                return false;
            }
        }

        public void Logout()
        {
            if (_isLoggedIn)
            {
                _isLoggedIn = false;
                Console.WriteLine("Anda telah keluar.");
            }
            else
            {
                Console.WriteLine("Tidak ada pengguna yang Login.");
            }
        }
    }
}