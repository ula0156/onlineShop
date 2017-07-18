using onlineShop.App;
using OnlineShop.ProductPickers;
using OnlineShop.Products;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Pages
{
    class SearchPage : IPage
    {
        private NavigationData _navData;
        private List<string> _userInput;
        private List<Product> _itemsToDisplay;

        public SearchPage(List<string> userInput)
        {
            _userInput = userInput;
        }

        public string OnNavigatedTo(NavigationData data)
        {
            _navData = data;
            StringBuilder menu = new StringBuilder();
            if (_userInput != null)
            {
                KeyWordProductPicker searchPageProductPicker = new KeyWordProductPicker(_userInput);
                _itemsToDisplay = searchPageProductPicker.PickItems(_navData.ProductsDescriptions, _navData.Stocks, true, int.MaxValue);
                int count = 1;
                foreach (var item in _itemsToDisplay)
                {
                    if (_navData.Stocks.Stocks[item.Id] == 0)
                    {
                        menu.AppendLine($"{count}. {item.Name} - {item.Price:C} - out of stock!");                    }
                    else
                    {
                        menu.AppendLine($"{count}. {item.Name} - {item.Price:C}");
                    }

                    count++;
                }
            }
            else
            {
                menu.AppendLine("Please enter your query!");
            }

            if (_userInput != null)
            {
                menu.AppendLine("A. Search again");
            }

            menu.AppendLine("B. Go to the main page");

            return menu.ToString();
        }

        public IPage OnUserInput(string input)
        {
            int userSelection;
            if (_userInput != null)
            {
                if (int.TryParse(input, out userSelection) && userSelection > 0 && userSelection <= _itemsToDisplay.Count)
                {
                    return new ProductPage(_itemsToDisplay[userSelection - 1]);
                }
                else if (input.ToUpper() == "A")
                {
                    return new SearchPage(null);
                }
            }
            else
            {
                if (input.ToUpper() != "B")
                {

                    return new SearchPage(new List<string>() { input });
                }
            }

            return new MainPage();
        }
    }
}

