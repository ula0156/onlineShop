using OnlineShop.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace onlineShop.Data
{
    /// <summary>
    /// Interface used for read only access to the database of products.
    /// </summary>
    interface IProductsReader
    {
        IQueryable<Product> GetProducts();

        int GetProductStock(Guid productId);
    }
}
