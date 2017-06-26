using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop
{
    class MainPage : IPage
    {
        // Private members that are needed.
        private Inventory _inventory;
        private Cart _cart;
        private List<Product> _pickedProducts;

        public MainPage(Inventory inventory, Cart cart)
        {
            // We save the inventory and the cart inside the object so we can use them 
            // in the other methods.
            _inventory = inventory;
            _cart = cart;
        }

        public string GetContent()
        {
            // We need a main page product picker, so we create one.
            MainPageProductPicker productPicker = new MainPageProductPicker();

            // We save the list of picked items so we can see which product the user 
            // selects.
            _pickedProducts = productPicker.PickItems(_inventory);

            // Now we compose the content of the main page. We start with the title followed by new line(\n).
            string result = "Main page\n";

            // Now we add all the picked products.
            int option = 1;
            foreach (Product product in _pickedProducts)
            {
                result += "" + option + ". " + product.Name + " $" + product.Price + "\n";
                option++;
            }

            // And finally we add the 2 options separated by new line(\n).
            result += "\nA. Search \nB. Go to cart";

            return result;
        }

        public IPage OnUserInput(string input)
        {
            int optionAsNumber;

            // We try to transform the user text into a number in order to see if the 
            // user selected any product
            if (int.TryParse(input, out optionAsNumber)) {
                if (optionAsNumber <= _pickedProducts.Count && optionAsNumber > 0)
                {
                    // Invalid number option, we do not have enough products picked, 
                    // so we navigate again to the main page.
                    return new ProductPage(_pickedProducts[optionAsNumber - 1], _inventory, _cart);
                }
            }
            else if (input == "A")
            {
                // The user selected to go to the search page and it did not enter any 
                // search text yet
                return new SearchPage(_inventory, _cart);
            }
            else if (input == "B")
            {
                // The user selected to go to cart
                return new CartPage(_inventory, _cart);
            }
            
            // No option matched, so we navigate again to the main page.
            return new MainPage(_inventory, _cart);
        }
    }
}
