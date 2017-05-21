using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop
{
    class Product
    {
        public Product(string name, double price, double weight)
        {
            Id = new Guid();
            Name = name;
            Price = price;
            Weight = weight;
        }

        #region Properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        #endregion
    }
}
