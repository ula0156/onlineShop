using System;

namespace onlineShop.Data
{
    public interface IStocksProvider: IStocksReader
    {
        bool TryIncreaseStock(Guid productId, int count);

        bool TryDecreaseStock(Guid productId, int count);

        bool TryRemoveStock(Guid productId);
    }
}
