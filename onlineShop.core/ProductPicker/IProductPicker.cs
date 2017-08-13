using onlineShop.Data;
using onlineShop.Products;
using System.Collections.Generic;

namespace onlineShop.ProductPickers
{
    public delegate bool ProductPickerFilter(Product product, int stock);

    public interface IProductPicker
    {
        List<Product> PickItems(IProductsReader productsReader, IStocksReader stocksReader, ProductPickerFilter filter, int numItemsToPick);
    }
}
