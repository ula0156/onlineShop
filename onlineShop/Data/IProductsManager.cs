using OnlineShop.Products;
using System;

namespace onlineShop.Data
{
    /// <summary>
    /// Interface used for read and write access to the database of products.
    /// </summary>
    interface IProductsManager : IProductsReader
    {
        bool TryAddProduct(Product product, int stock);

        bool TryRemoveProduct(Guid productId);
    }
}
