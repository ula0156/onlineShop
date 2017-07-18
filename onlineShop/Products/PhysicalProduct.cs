using OnlineShop.Products.Entities;

namespace OnlineShop.Products
{
    public abstract class PhysicalProduct : Product
    {
        public PhysicalProduct(string name, double price, string tags, string color, Size size) : base(name, price, tags)
        {
            Color = color;
            Size = size;
        }

        public string Color { get; set; }
        public Size Size { get; set; }
    }
}