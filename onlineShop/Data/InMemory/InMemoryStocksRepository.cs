using System;
using System.Collections.Generic;

namespace onlineShop.Data.InMemory
{
    public class InMemoryStocksRepository
    {
        public Dictionary<Guid, int> Stocks;

        public InMemoryStocksRepository()
        {
            Stocks = new Dictionary<Guid, int>();
        }
    }
}
