using System;

namespace OnlineShop.Products
{
    public abstract class Product
    {
        public Product(string name, double price, string tags)
        {
            Id = Guid.NewGuid(); // static method. Called it on the class
            Name = name;
            Price = price;
            Tags = tags.ToLower();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Tags { get; set; }

        public virtual bool DoesKeyWordMatches(string keyword)
        {
            return Name.ToLower().Contains(keyword) || Tags.ToLower().Contains(keyword);
        }
    }
}
