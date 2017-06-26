using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop
{
    class ContactInformation
    {
        public ContactInformation(string emailAddress, string shippingAddress, string phoneNumber)
        {
            EmailAddress = emailAddress;
            ShippingAddress = shippingAddress;
            PhoneNumber = phoneNumber;
        }
        #region Properties:
        public string EmailAddress { get; set; }
        public string ShippingAddress { get; set; }
        public string PhoneNumber { get; set; }
        #endregion;
    }
}
