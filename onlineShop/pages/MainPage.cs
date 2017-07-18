using onlineShop.App;
using OnlineShop.Data;
using OnlineShop.ProductPickers;
using OnlineShop.Products;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Pages
{
    public class MainPage: IPage
    {
        private List<Product> _itemsToDisplay; // use a private member in order to store the value and use it in other methods too

        public string OnNavigatedTo(NavigationData data)
        {
            StringBuilder menu = new StringBuilder();
            MainPageProductPicker productPicker = new MainPageProductPicker(); 
            _itemsToDisplay = productPicker.PickItems(data.ProductsDescriptions, data.Stocks, false, 5);

            int index = 1;
            foreach(var item in _itemsToDisplay)
            {
                menu.AppendLine($"{index}. {item.Name} - {item.Price:C} ");
                index++;
            }
            menu.AppendLine("");
            menu.AppendLine("A. Search");
            menu.AppendLine("B. Go to the Cart Page\n------------");

            return menu.ToString();
        }

        public IPage OnUserInput(string input)
        {
            int userSelection = 0;
            // TODO implement method
            if (int.TryParse(input, out userSelection) && (userSelection > 0 && userSelection <= _itemsToDisplay.Count))
            {
                return new ProductPage(_itemsToDisplay[userSelection - 1]);
            } else if (input.ToUpper() == "A")
            {
                return new SearchPage(null);
            } else if (input.ToUpper() == "B")
            {
                return new CartPage();
            }

            return new MainPage();
        }
    }
}
