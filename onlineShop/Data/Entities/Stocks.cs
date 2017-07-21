using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop.Data.Entities
{
    public class Stock
    {
        private Dictionary<Guid, int> _stock;

        public Stock()
        {
            _stock = new Dictionary<Guid, int>();
        }
    }
}
