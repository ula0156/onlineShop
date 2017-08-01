using onlineShop.Products;
using System;

namespace onlineShop.Data
{
    /// <summary>
    /// Interface used for read and write access to the database of products.
    /// </summary>
    public interface IProductsProvider : IProductsReader
    {
        bool TryAddProduct(Product product);

        bool TryRemoveProduct(Guid productId);
    }
}
