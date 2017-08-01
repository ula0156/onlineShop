using System;

namespace onlineShop.Data
{
    /// <summary>
    /// Interface for providing read access to the stocks, mostly used by pages and product pickers.
    /// </summary>
    public interface IStocksReader
    {
        int GetProductStock(Guid productId);
    }
}
