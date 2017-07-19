using OnlineShop.Products;
using System;
using System.Collections.Generic;

namespace OnlineShop.Data
{
    public class ProductsDescriptions
    {
        // Guid - product id, product, int - number of copies
        public Dictionary<Guid, Product> Products;

        public ProductsDescriptions()
        {
            Products = new Dictionary<Guid, Product> ();
        }
    }
}
