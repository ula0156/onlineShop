using onlineShop.Data;
using onlineShop.Entities;
using onlineShop.Products;
using System;
using System.Collections.Generic;

namespace onlineShop.ProductPickers
{
    public class MainPageProductPicker : IProductPicker
    {
        public List<Product> PickItems(IProductsReader productsReader, IStocksReader stocksReader, bool includeOutOfStock, int numItemsToPick)
        {
            HolidayManager holidayManager = new HolidayManager();
            List<string> toSearch;
            if (holidayManager.IsHoliday(DateTime.Now, out toSearch))
            {
                KeyWordProductPicker keyWordProductPicker = new KeyWordProductPicker(toSearch);
                return keyWordProductPicker.PickItems(productsReader, stocksReader, false, numItemsToPick);
            }
            else
            {
                RandomItemsProductPicker randomItemProductPicker = new RandomItemsProductPicker();
                return randomItemProductPicker.PickItems(productsReader, stocksReader, false, numItemsToPick);
            }
        }
    }
}
