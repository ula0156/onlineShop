﻿using onlineShop.App;
using OnlineShop.Products;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Pages
{    
    public class CartPage: IPage
    {
        private NavigationData _navData;
        private Dictionary<int, Product> _menuMapping;

        // This method create a menu what is in the cart - menu
        // 1. Remove item 1 - $3
        // 2. Remove item 2 - $2
        //  total price
        //  total weight
        // A. Go to Main
        // B. Checkout
        public string OnNavigatedTo(NavigationData data)
        {
            _navData = data;
            StringBuilder menu = new StringBuilder();
            _menuMapping = new Dictionary<int, Product>();

            int count = 1;
            foreach (var item in _navData.Cart.Products)
            {
                if (item.Value > 0)
                {
                    _menuMapping.Add(count, item.Key);
                    menu.AppendLine($"{count}. {item.Key.Name} - {item.Key.Price:C}\nNumber of copies: {item.Value}");
                    count++;
                }
                
            }
            menu.AppendLine($"Total price: {_navData.Cart.TotalPrice()}");
            menu.AppendLine($"Total weight: {_navData.Cart.TotalWeight()}");
            menu.AppendLine("");
            menu.AppendLine("A. Go to the main page");
            if (_navData.Cart.TotalPrice() > 0)
            {
                menu.AppendLine("B. Checkout");
            }
            return menu.ToString();
        }

        public IPage OnUserInput(string input)
        {
            int userSelection;
            if (int.TryParse(input, out userSelection) && (userSelection > 0 && userSelection <= _navData.Cart.Products.Count))
            {
                return new CartProductPage(_menuMapping[userSelection]);
            }
            else if (input.ToUpper() == "A")
            {
                return new MainPage();
            }
            else if (_navData.Cart.TotalPrice() > 0 && (input.ToUpper() == "B"))
            {
                _navData.Cart.UpdateCart();
               return new CheckoutPage();
            }

            return new CartPage();
        }
    }
}