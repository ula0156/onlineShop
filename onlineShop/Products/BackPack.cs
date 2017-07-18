using OnlineShop.Products.Entities;

namespace OnlineShop.Products
{
    public class BackPack: PhysicalProduct
    {
        public BackPack(
            string name,
            double price, 
            string tags, 
            string color, 
            Size size, 
            double volume, 
            string material)
            : base(name, price, tags, color, size)
        {
            Volume = volume;
            Material = material;
        }

        public double Volume { get; set; }
        public string Material { get; set; }
    }
}
