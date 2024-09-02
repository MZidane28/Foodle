using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodle1
{
    class User
    {
        protected string _userID;
        protected string _userName;
        protected string _userEmail;
        protected string _phoneNumber;
        protected string _userPassword;

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

        public Boolean Login(string userName, string userPassword)
        {
            if (userName == _userName || userPassword == _userPassword)
            {
                Console.WriteLine("Login Berhasil");
                return true;
            }

            else
            {
                Console.WriteLine("Login Gagal. Silakan Coba Lagi");
                return false;
            }
        }
    }
}