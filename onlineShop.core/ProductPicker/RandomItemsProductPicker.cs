using onlineShop.Data;
using onlineShop.Products;
using System.Collections.Generic;

namespace onlineShop.ProductPickers
{
    public class RandomItemsProductPicker: IProductPicker
    {
        public List<Product> PickItems(IProductsReader productsReader, IStocksReader stocksReader, bool includeOutOfStock, int numberOfItems)
        {
            List<Product> products = new List<Product>();
            int count = 0;
            foreach (var item in productsReader.GetProducts())
            {
                if (count < numberOfItems || numberOfItems == Constants.UNLIMITED) 
                {
                    if (stocksReader.GetProductStock(item.Id) > 0 || stocksReader.GetProductStock(item.Id) == Constants.UNLIMITED)
                    {
                        products.Add(item);
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
