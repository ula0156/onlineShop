using System;
using System.Linq;
using OnlineShop.Products;
using OnlineShop.Data;

namespace onlineShop.Data
{
    /// <summary>
    /// Manager of products of in-memory database
    /// </summary>
    public class InMemoryProductsManager : IProductsManager
    {
        private ProductsDescriptions _productsDescriptions;
        private ProductsStocks _productsStocks;

        public InMemoryProductsManager(ProductsDescriptions productsDescriptions, ProductsStocks productsStocks)
        {
            _productsDescriptions = productsDescriptions;
            _productsStocks = productsStocks;
        }

        public IQueryable<Product> GetProducts()
        {
            return _productsDescriptions.Products.Values.AsQueryable();
        }

        public int GetProductStock(Guid productId)
        {
            return _productsStocks.Stocks[productId];
        }

        public bool TryAddProduct(Product product, int stock)
        {
            if (!_productsStocks.Stocks.ContainsKey(product.Id))
            {
                _productsDescriptions.Products.Add(product.Id, product);
                _productsStocks.Stocks[product.Id] = 0;
            }

            _productsStocks.Stocks[product.Id] += stock;
            return true;
        }

        public bool TryRemoveProduct(Guid productId)
        {
            if (_productsDescriptions.Products.ContainsKey(productId))
            {
                _productsStocks.Stocks.Remove(productId);
                _productsDescriptions.Products.Remove(productId);
                return true;
            }

            return false;
        }
    }
}
