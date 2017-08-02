using onlineShop.Data;
using onlineShop.Products;
using System.Collections.Generic;

namespace onlineShop.ProductPickers
{
    public class RandomItemsProductPicker: IProductPicker
    {
        public List<Product> PickItems(IProductsReader productsReader, IStocksReader stocksReader, ProductPickerFilter filter, int numberOfItems)
        {
            List<Product> pickedItems = new List<Product>();
            foreach (var item in productsReader.GetProducts())
            {
                if (pickedItems.Count == numberOfItems)
                {
                    break;
                }

                int stock = stocksReader.GetProductStock(item.Id);
                if (filter(item, stock))
                {
                    pickedItems.Add(item);
                }
            }

            return pickedItems;
        }
    }
}
