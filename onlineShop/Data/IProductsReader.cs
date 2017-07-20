using onlineShop.Products;
using System;
using System.Linq;

namespace onlineShop.Data
{
    /// <summary>
    /// Interface used for read only access to the database of products.
    /// </summary>
    public interface IProductsReader
    {
        IQueryable<Product> GetProducts();
    }
}
