using onlineShop.Data;
using onlineShop.Products;
using System.Collections.Generic;

namespace onlineShop.ProductPickers
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

        public List<Product> PickItems(IProductsReader productsReader, IStocksReader stocksReader, bool includeOutOfStock, int numberOfItems)
        {
            List<Product> pickedItems = new List<Product>();
            foreach (var item in productsReader.GetProducts())
            {
                if ((stocksReader.GetProductStock(item.Id) > 0 || stocksReader.GetProductStock(item.Id) == Constants.UNLIMITED || includeOutOfStock)) 
                {
                    if (pickedItems.Count < numberOfItems || numberOfItems == Constants.UNLIMITED)
                    {
                        foreach (var wordToSearch in _keyWords)
                        {
                            if (item.DoesKeyWordMatches(wordToSearch))
                            {
                                pickedItems.Add(item);
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
