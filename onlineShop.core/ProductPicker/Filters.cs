using onlineShop.Products;
using System;
using System.Collections.Generic;

namespace onlineShop.ProductPickers
{
    public static class Filters
    {
        public static bool InStock(Product product, int stock)
        {
            return stock > 0 || stock == Constants.UNLIMITED;
        }

        public static ProductPickerFilter GetFilterByType(Type t)
        {
            return new ProductPickerFilter((Product product, int stock) =>
            {
                if (!t.IsInstanceOfType(product) || !InStock(product, stock))
                {
                    return false;
                }
                
                return true;
            });
        }

        public static bool InStock(Product product, int stock, Type t)
        {
            return stock > 0 || stock == onlineShop.Constants.UNLIMITED && t == product.GetType();       
        }

        public static ProductPickerFilter GetFilterByKeyWords(List<string> keyWords, Type t, bool shouldBeInStock = true)
        {
            return new ProductPickerFilter((Product product, int stock) =>
            {
                if (shouldBeInStock && !InStock(product, stock, t))
                {
                    return false;
                }

                if (!t.IsInstanceOfType(product))
                {
                    return false;
                }

                foreach (var keyWord in keyWords)
                {
                    if (product.DoesKeyWordMatches(keyWord))
                    {
                        return true;
                    }
                }

                return false;
            });
        }
    }
}