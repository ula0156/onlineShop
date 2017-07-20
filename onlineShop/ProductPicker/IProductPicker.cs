using onlineShop.Data;
using onlineShop.Products;
using System.Collections.Generic;

namespace onlineShop.ProductPickers
{
    public interface IProductPicker
    {
        List<Product> PickItems(IProductsReader productsReader, IStocksReader stocksReader, bool includeOutOfStock, int numItemsToPick);
    }
}
