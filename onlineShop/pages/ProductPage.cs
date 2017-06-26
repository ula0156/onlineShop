using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop
{
    class ProductPage : IPage
    {
        private Product _product;
        private Inventory _inventory;
        private Cart _cart;

        public ProductPage(Product product, Inventory inventory, Cart cart)
        {
            _product = product;
            _inventory = inventory;
            _cart = cart;
        }

        public string GetContent()
        {
            string content = _product.Name + "\nPrice: $" + _product.Price;
            if (_product is Book)
            {
                var book = _product as Book;
                content += "\nPages: " + book.NumberOfPages;
            } else if (_product is Backpack)
            {
                var backpack = _product as Backpack;
                content += $"\nVolume: {backpack.Volume} liters";
            }

            content += "\n";

            // TODO - add more details about the product and the 2 options:
            // A. Add(remove) to cart - you need to check if the product is in the cart 
            // in order to determine which one you display
            // B. Back
            bool existsInCart = false;
            foreach (var productInCart in _cart.Products)
            {
                if (productInCart.Id == _product.Id)
                {
                    existsInCart = true;
                    break;
                }
            }

            if (existsInCart)
            {
                content += "\nA. Remove from cart";
            } else
            {
                content += "\nA. Add to cart";
            }
            content += "\nB. Back";

            return content;
        }

        public IPage OnUserInput(string input)
        {
            // TODO - just like in MainPage, you need to check what the user entered and 
            // see which option it selected.

            if (input == "A")
            {
                if (_cart.Products.Contains(_product))
                {
                    _cart.Products.Remove(_product);
                } else
                {
                    _cart.Products.Add(_product);
                }

                return new ProductPage(_product, _inventory, _cart);
            }
            else if (input == "B")
            {
                return new MainPage(_inventory, _cart);
            }

            return new ProductPage(_product, _inventory, _cart);
        }
    }
}
