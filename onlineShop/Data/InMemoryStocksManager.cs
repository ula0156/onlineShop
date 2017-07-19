using System;
using OnlineShop.Data;

namespace onlineShop.Data
{
    public class InMemoryStocksManager : IStocksManager
    {
        private ProductsStocks _productsStocks;

        public InMemoryStocksManager(ProductsStocks productsStocks)
        {
            _productsStocks = productsStocks;
        }

        public bool TryDecreaseStock(Guid productId)
        {
            if (_productsStocks.Stocks.ContainsKey(productId))
            {
                _productsStocks.Stocks[productId]--;
                return true;
            }

            return false;
        }

        public bool TryIncreaseStock(Guid productId)
        {
            if (_productsStocks.Stocks.ContainsKey(productId))
            {
                _productsStocks.Stocks[productId]++;
                return true;
            }

            return false;
        }
    }
}
