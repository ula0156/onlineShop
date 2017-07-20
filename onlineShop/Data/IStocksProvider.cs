using System;

namespace onlineShop.Data
{
    /// <summary>
    /// Interface for providing read and write access to the stocks.
    /// </summary>
    public interface IStocksProvider: IStocksReader
    {
        bool TryIncreaseStock(Guid productId, int count);

        bool TryDecreaseStock(Guid productId, int count);

        bool TryAddStock(Guid productId, int count);

        bool TryRemoveStock(Guid productId);
    }
}
