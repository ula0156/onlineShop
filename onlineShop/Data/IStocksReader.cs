using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop.Data
{
    public interface IStocksReader
    {
        int GetProductStock(Guid productId);
    }
}
