using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop
{
    /// <summary>
    /// This interface defines what all IProductPickers have in common: the PickItems method.
    /// Each specific IProductPicker has its own implementation of the PickItems method
    /// and its own set of separate constructors or other methods if it needs any.
    /// We have 2 product pickers now:
    /// - MainPageProductPicker - picks the first 4 items from the inventory.
    /// - SearchProductPicker - picks the items from the inventory that match a search text.
    /// </summary>
    interface IProductPicker
    {
        List<Product> PickItems(Inventory inventory);
    }
}
