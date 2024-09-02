using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodle
{
    using Foodle1;
    class Seller: User
    {
        private string _sellerAddress;
        private string[] _sellerMenu;


        public string SellerAddress
        {
            get { return _sellerAddress; }
            set { _sellerAddress = value; }
        }


        public string[] SellerMenu
        {
            get { return _sellerMenu; }
            set { _sellerMenu = value; }
        }


        public string UpdateMenu()
        {
            return "Menu diperbaharui";
        }


        public string AcceptOrder()
        {
            return "Order diterima";
        }
    }

}
