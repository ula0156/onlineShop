using onlineShop.Data;
using onlineShop.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onlineShopWeb.DataAccess
{
    public static class ProvidersFactory
    {
        public static IProductsReader GetProductsReader()
        {
            return new DBProductsProvider();
        }

        public static IStocksReader GetStocksReader()
        {
            return new DBStocksProvider();
        }
    }
}