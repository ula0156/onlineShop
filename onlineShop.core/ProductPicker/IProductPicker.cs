using onlineShop.Data;
using onlineShop.Products;
using System.Collections.Generic;

namespace onlineShop.ProductPickers
{
    // what is stock??
    // if we have to pick up several different products for the main page
    public delegate bool ProductPickerFilter(Product product, int stock);

    public interface IProductPicker
    {
        List<Product> PickItems(IProductsReader productsReader, IStocksReader stocksReader, ProductPickerFilter filter, int numItemsToPick);
    }
}
