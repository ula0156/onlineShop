using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop
{
    // We mark this class as abstract because we do not want to be able to create instances
    // of PhysicalProduct like "new PhysicalProduct".
    abstract class PhysicalProduct : Product
    {
        // This constructor will be called by the constructors of the subclasses(Backpack, Book).
        // Also having these parameters means that you cannot create any kind of physical product 
        // without a name, price, size and manufacturer.
        public PhysicalProduct(string name, double price, string tags, Size size, Manufacturer manufacturer) : base(name, price, tags)
        {
            Size = size;
            Manufacturer = manufacturer;
        }

        #region Properties
        // Size is a type
        public Size Size { get; }
        public Manufacturer Manufacturer { get; }
        #endregion
    }
}