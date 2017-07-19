using System;
using System.Collections.Generic;

namespace OnlineShop.Data
{
    public class ProductsStocks
    {
        public Dictionary<Guid, int> Stocks;

        public ProductsStocks()
        {
            Stocks = new Dictionary<Guid, int>();
        }
    }
}
