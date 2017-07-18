using OnlineShop;
using OnlineShop.Data;
using OnlineShop.Pages;
using System.Collections.Generic;

namespace onlineShop.App
{
    /// <summary>
    /// This contains data that will be passed to the pages when we are navigating to them.
    /// </summary>
    public class NavigationData
    {
        public ProductsDescriptions ProductsDescriptions;
        public ProductsStocks Stocks;
        public Cart Cart;
        public Stack<IPage> PreviousPages;

        public NavigationData()
        {
            PreviousPages = new Stack<IPage>();
        }
    }
}
