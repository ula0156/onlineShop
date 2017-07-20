using System;
using onlineShop.Data.InMemory;

namespace onlineShop.Data.InMemory
{
    public class InMemoryStocksProvider : IStocksProvider
    {
        private InMemoryStocksRepository _productsStocks;

        public InMemoryStocksProvider(InMemoryStocksRepository productsStocks)
        {
            _productsStocks = productsStocks;
        }

        public bool TryDecreaseStock(Guid productId, int count)
        {
            if (_productsStocks.Stocks.ContainsKey(productId))
            {
                _productsStocks.Stocks[productId] -= count;
                return true;
            }

            return false;
        }

        public bool TryIncreaseStock(Guid productId, int count)
        {
            if (_productsStocks.Stocks.ContainsKey(productId))
            {
                _productsStocks.Stocks[productId] += count;
                return true;
            }

            return false;
        }

        public int GetProductStock(Guid productId)
        {
            return _productsStocks.Stocks[productId];
        }

        public bool TryRemoveStock(Guid productId)
        {
            return _productsStocks.Stocks.Remove(productId);
        }
    }
}
