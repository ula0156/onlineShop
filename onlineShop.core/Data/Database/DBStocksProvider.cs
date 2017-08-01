using onlineShop.Data.Entities;
using System;
using System.Linq;

namespace onlineShop.Data.Database
{
    public class DBStocksProvider : IStocksProvider
    {
        private StocksModel _stocksModel;
        public DBStocksProvider()
        {
            _stocksModel = new StocksModel();
         }

        public int GetProductStock(Guid productId)
        {
            var stock = _stocksModel.Stocks.FirstOrDefault(s => s.ProductId == productId);
            if (stock == null)            {
                return 0;
            }

            return stock.Amount;
          }
  
        public bool TryAddStock(Guid productId, int count)
        {
            var stock = new Stock();
            stock.Amount = count;
            stock.ProductId = productId;
            _stocksModel.Stocks.Add(stock);
            _stocksModel.SaveChanges();

           return true;
         }

        public bool TryDecreaseStock(Guid productId, int count)
        {
            var stock = _stocksModel.Stocks.FirstOrDefault(s => s.ProductId == productId);
            if (stock == null)
            {
                return false;
            }

            if (stock.Amount == Constants.UNLIMITED)
            {
                return true;
            }

            if (stock.Amount < count)
            {
                return false;
            }

            stock.Amount -= count;
            _stocksModel.SaveChanges();

            return true;
        }

        public bool TryIncreaseStock(Guid productId, int count)
        {
            var stock = _stocksModel.Stocks.FirstOrDefault(s => s.ProductId == productId);
            if (stock == null)
            {
                return false;
            }

            if (stock.Amount == Constants.UNLIMITED)
            {
                return true;
            }

            stock.Amount += count;
            _stocksModel.SaveChanges();
            return true;
        }

        public bool TryRemoveStock(Guid productId)
        {
            var stock = _stocksModel.Stocks.FirstOrDefault(s => s.ProductId == productId);
            if (stock == null)
            {
                return false;
            }

            _stocksModel.Stocks.Remove(stock);
            _stocksModel.SaveChanges();
            return true;
        }
    }
}