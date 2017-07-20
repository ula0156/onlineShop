using onlineShop.Products;
using System;
using System.Collections.Generic;

namespace onlineShop.Data.InMemory
{
    public class InMemoryProductsRepository
    {
        // Guid - product id, product, int - number of copies
        public Dictionary<Guid, Product> Products;

        public InMemoryProductsRepository()
        {
            Products = new Dictionary<Guid, Product>();
        }
    }
}
