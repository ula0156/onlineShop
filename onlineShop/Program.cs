using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Product("watch", 250, 50);
            var chocolate = new Product("dark chocolate", 7, 100);
            var fruit = new Product("apple", 2, 150);
            var cart1 = new Cart();
            cart1.Products.Add(watch);
            cart1.Products.Add(chocolate);
            cart1.Products.Add(fruit);
        }
    }
}
