using onlineShop.Data;
using onlineShop.Pages;
using System.Collections.Generic;

namespace onlineShop.App
{
    /// <summary>
    /// This contains data that will be passed to the pages when we are navigating to them.
    /// </summary>
    public class NavigationData
    {
        public IProductsReader ProductsReader;
        public IStocksReader StocksReader;
        public Cart Cart;
        public Stack<IPage> PreviousPages;

        public NavigationData()
        {
            PreviousPages = new Stack<IPage>();
        }
    }
}
