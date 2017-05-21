using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop
{
    class Cart
    {
        public Cart()
        {
            Products = new List<Product>();
        }               
        
        #region Properties
        public List<Product> Products { get; }
        #endregion

        #region Methods
        public double TotalPrice()
        {
            double totalPrice = 0;
            foreach (var item in Products)
            {
                totalPrice += item.Price;
            }

            return totalPrice;      
        }
        #endregion
    }
}
