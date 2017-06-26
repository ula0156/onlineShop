using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop
{
    // This class implements the IProductPicker interface. This means
    // that it must provide an implementation with actual code for the PickItems method.
    class MainPageProductPicker : IProductPicker
    {
        public List<Product> PickItems(Inventory inventory)
        {
            List<Product> result = new List<Product>();
            int count = 0;
            foreach (var item in inventory.Products)
            {
                if (count > 3)
                {
                    break;
                }

                result.Add(item.Key);
            }

            return result;
        }
    }
}
