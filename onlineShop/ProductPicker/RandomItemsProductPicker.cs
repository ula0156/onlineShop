using OnlineShop.Data;
using OnlineShop.Products;
using System.Collections.Generic;

namespace OnlineShop.ProductPickers
{
    public class RandomItemsProductPicker: IProductPicker
    {
        public List<Product> PickItems(ProductsDescriptions inventory, ProductsStocks stocks, bool includeOutOfStock, int numberOfItems)
        {
            List<Product> products = new List<Product>();
            int count = 0;
            foreach (var item in inventory.Products)
            {
                if (count < numberOfItems || numberOfItems == Constants.UNLIMITED) 
                {
                    if (stocks.Stocks[item.Key] > 0 || stocks.Stocks[item.Key] == Constants.UNLIMITED)
                    {
                        products.Add(item.Value);
                        count++;
                    }
                } else
                {
                    break;
                }
            }

            return products;
        }
    }
}
