using OnlineShop.Data;
using OnlineShop.Products;
using System.Collections.Generic;

namespace OnlineShop.ProductPickers
{
    public interface IProductPicker
    {
        List<Product> PickItems(ProductsDescriptions inventory, ProductsStocks stocks, bool includeOutOfStock, int numItemsToPick);
    }
}
