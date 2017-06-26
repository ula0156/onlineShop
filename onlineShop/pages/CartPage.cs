using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop
{
    class CartPage : IPage
    {
        private Inventory _inventory;
        private Cart _cart;

        public CartPage(Inventory inventory, Cart cart)
        {
            _inventory = inventory;
            _cart = cart;
        }

        public string GetContent()
        {
            // TODO - display the elements in the cart:
            // 1. Remove Harry Potter $3
            // 2. Remove Backpack $4
            // Total price: $7
            // Total weight: 2kg
            //
            // A. Back
            return "";
        }

        public IPage OnUserInput(string input)
        {
            // TODO - Just like in MainPage, you need to handle the user input 
            // (either to remove from cart, or to go back).
            // If the user removes from cart, then you remove that product from the 
            // cart and navigate back to the cart.
            // Back navigates to MainPage.
            return null;
        }
    }
}
