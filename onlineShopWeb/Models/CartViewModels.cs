using onlineShop.Products;
using System.Collections.Generic;

namespace onlineShopWeb.Models
{
    public class CartViewModel
    {

        public IReadOnlyDictionary<Product, int> CartProducts { get; set; }
        public double TotalPrice { get; set; }
        public double TotalWeight { get; set; }
        public string Status { get; set; }
    }
}