using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop.Data
{
    public interface IStocksManager
    {
        bool TryIncreaseStock(Guid productId);

        bool TryDecreaseStock(Guid productId);
    }
}
