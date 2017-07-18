using OnlineShop.Data;
using OnlineShop.Entities;
using OnlineShop.Products;
using System;
using System.Collections.Generic;

namespace OnlineShop.ProductPickers
{
    public class MainPageProductPicker : IProductPicker
    {
        public List<Product> PickItems(ProductsDescriptions inventory, ProductsStocks stocks, bool includeOutOfStock, int numItemsToPick)
        {
            HolidayManager holidayManager = new HolidayManager();
            List<string> toSearch;
            if (holidayManager.IsHoliday(DateTime.Now, out toSearch))
            {
                KeyWordProductPicker keyWordProductPicker = new KeyWordProductPicker(toSearch);
                return keyWordProductPicker.PickItems(inventory, stocks, false, numItemsToPick);
            }
            else
            {
                RandomItemsProductPicker randomItemProductPicker = new RandomItemsProductPicker();
                return randomItemProductPicker.PickItems(inventory, stocks, false, numItemsToPick);
            }
        }
    }
}
