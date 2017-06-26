using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop
{
    // We mark this abstract because you cannot just create an object of type Product.
    // Objects can be Product, but not only Product, they must be more specific than this.
    // Example:
    // Book b = new Book(.....);
    // b is a Book, but it is also a PhysicalProduct and at the same time it is also a Product.
    abstract class Product
    {
        public Product(string name, double price)
        {
            // Generate a unique id.
            Id = new Guid();

            // Save the name and price passed as parameters inside the object.
            Name = name;
            Price = price;
        }

        #region Properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        #endregion
    }
}
