using onlineShop.Products;
using System;
using System.Collections.Generic;

namespace onlineShop.Data.InMemory
{
    public class InMemoryProductsRepository
    {
        // Key: Guid - product id, Value: product
        public Dictionary<Guid, Product> Products;

        public InMemoryProductsRepository()
        {
            Products = new Dictionary<Guid, Product>();
        }
    }
}
