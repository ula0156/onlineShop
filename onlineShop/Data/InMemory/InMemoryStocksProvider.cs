using System;
using onlineShop.Data.InMemory;

namespace onlineShop.Data.InMemory
{
    public class InMemoryStocksProvider : IStocksProvider
    {
        private InMemoryStocksRepository _stocksRepository;

        public InMemoryStocksProvider(InMemoryStocksRepository stocksRepository)
        {
            _stocksRepository = stocksRepository;
        }

        public bool TryDecreaseStock(Guid productId, int count)
        {
            if (_stocksRepository.Stocks.ContainsKey(productId))
            {
                _stocksRepository.Stocks[productId] -= count;
                return true;
            }

            return false;
        }

        public bool TryIncreaseStock(Guid productId, int count)
        {
            if (_stocksRepository.Stocks.ContainsKey(productId))
            {
                _stocksRepository.Stocks[productId] += count;
                return true;
            }

            return false;
        }

        public int GetProductStock(Guid productId)
        {
            return _stocksRepository.Stocks[productId];
        }

        public bool TryRemoveStock(Guid productId)
        {
            return _stocksRepository.Stocks.Remove(productId);
        }
    }
}
