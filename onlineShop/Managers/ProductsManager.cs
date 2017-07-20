using onlineShop.Data;
using onlineShop.Products;
using System;

namespace onlineShop.Managers
{
    public class ProductsManager
    {
        private IProductsProvider _productsProvider;
        private IStocksProvider _stocksProvider;

        public ProductsManager(IProductsProvider productsProvider, IStocksProvider stocksProvider)
        {
            _productsProvider = productsProvider;
            _stocksProvider = stocksProvider;
        }
        
        /// <summary>
        /// Increase the stock for existing product
        /// </summary>
        public bool TryIncreaseStock(Guid productId, int count)
        {
            return _stocksProvider.TryIncreaseStock(productId, count);
        }

        /// <summary>
        /// Add a product and setting stock
        /// </summary>
        public bool TryAddProduct(Product product, int count)
        {
            return _productsProvider.TryAddProduct(product) && _stocksProvider.TryAddStock(product.Id, count);
        }

        public bool TryRemoveProduct(Guid productId)
        {
            return _productsProvider.TryRemoveProduct(productId) && _stocksProvider.TryRemoveStock(productId);
        }
    }
}
