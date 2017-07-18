using OnlineShop.Data;
using OnlineShop.Products;
using System.Collections.Generic;

namespace OnlineShop.ProductPickers
{
    public class KeyWordProductPicker: IProductPicker
    {
        private List<string> _keyWords;

        public KeyWordProductPicker(List<string> keyWords)
        {
            _keyWords = new List<string>();
            foreach(var keyword in keyWords)
            {
                _keyWords.Add(keyword.ToLower());
            }
        }

        public List<Product> PickItems(ProductsDescriptions inventory, ProductsStocks stocks, bool includeOutOfStock, int numberOfItems)
        {
            List<Product> pickedItems = new List<Product>();
            foreach (var item in inventory.Products)
            {
                if ((stocks.Stocks[item.Key] > 0 || stocks.Stocks[item.Key] == Constants.UNLIMITED || includeOutOfStock)) 
                {
                    if (pickedItems.Count < numberOfItems || numberOfItems == Constants.UNLIMITED)
                    {
                        foreach (var wordToSearch in _keyWords)
                        {
                            if (item.Value.DoesKeyWordMatches(wordToSearch))
                            {
                                pickedItems.Add(item.Value);
                                break;
                            }
                        }
                    } 
                    else
                    {
                        break;
                    }
                }
            }

            return pickedItems;
        }   
    }
}
