using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop.productpickers
{
    // This class implements the IProductPicker interface. This means that it must provide
    // a code implementation for the PickItems method.
    class SearchProductPicker : IProductPicker
    {
        private string _searchText;   // it's a property

        // When we create an instance of this class we are required to pass the searchText
        // that it will look for in the inventory.
        public SearchProductPicker(string searchText)
        {
            // searchText is just a parameter to the constructor. When the constructor
            // finishes executing we will not have access to the searchText anymore from
            // this object.
            // Because of that, we save the search text inside the object in order to use 
            // it when the PickItems method is actually called and it needs the search text.
            _searchText = searchText;
        }
        
        public List<Product> PickItems(Inventory inventory)
        {
            // return a list of items from the inventory that matches _searchText
            List<Product> _pickedItems = new List<Product>();
            foreach (var item in inventory.Products)
            {
                if (item.Key.Name.Contains(_searchText))
                {
                    _pickedItems.Add(item.Key);
                }
            }

            return _pickedItems;
        }
    }
}
