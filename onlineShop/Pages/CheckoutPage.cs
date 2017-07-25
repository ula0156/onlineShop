using onlineShop.App;
using onlineShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop.Pages
{
    public class CheckoutPage: IPage
    {
        private NavigationData _navData;

        public string OnNavigatedTo(NavigationData data)
        {
            _navData = data;
            StringBuilder menu = new StringBuilder();

            menu.AppendLine($"Total Price: {_navData.Cart.TotalPrice():C}\nSelect payment method:\n1. Credit Card\n2. Debit Card\n3. PayPal");
            menu.AppendLine("");
            menu.AppendLine("A. Return to cart\nB. Go to the main page\n----------");

            return menu.ToString();
        }

        public IPage OnUserInput(string input)
        {
            int userSelection;
            if (int.TryParse(input, out userSelection))
            {
                switch (userSelection)
                {
                    case 1:
                        { //return new CreditCardPage();
                            break;
                        }
                    case 2:
                        {
                            //return new DebitCardPage();
                            break;
                        }
                        case 3:
                        {
                            //return new PayPalPage();
                            break;
                        }
                }
            } 
            else if (input.ToUpper() == "A")
            {
                return new CartPage();
            }

            return new MainPage();
        }
    }
}
