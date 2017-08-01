using System;
using System.Linq;
using onlineShop.Products;

namespace onlineShop.Data.InMemory
{
    /// <summary>
    /// Manager of products of in-memory database
    /// </summary>
    public class InMemoryProductsProvider : IProductsProvider
    {
        private InMemoryProductsRepository _productsDescriptions;

        public InMemoryProductsProvider(InMemoryProductsRepository productsDescriptions)
        {
            _productsDescriptions = productsDescriptions;
        }

        public IQueryable<Product> GetProducts()
        {
            return _productsDescriptions.Products.Values.AsQueryable();
        }

        public bool TryAddProduct(Product product)
        {
            if (!_productsDescriptions.Products.ContainsKey(product.Id))
            {
                _productsDescriptions.Products.Add(product.Id, product);
                return true;
            }

            return false;
        }

        public bool TryRemoveProduct(Guid productId)
        {
            if (_productsDescriptions.Products.ContainsKey(productId))
            {
                _productsDescriptions.Products.Remove(productId);
                return true;
            }

            return false;
        }
    }
}
