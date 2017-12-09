using System;
using System.ComponentModel.DataAnnotations;

namespace onlineShop.Products
{
    public abstract class Product
    {
        [Required]
        [Key]
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        public string Tags { get; set; }

        public string ImagePath { get; set; }

        protected Product()
        {
        }

        public Product(string name, double price, string tags, string imagePath)
        {
            Id = Guid.NewGuid(); // static method. Called it on the class
            Name = name;
            Price = price;
            Tags = tags.ToLower();
            ImagePath = imagePath;
        }

        public virtual bool DoesKeyWordMatches(string keyword)
        {
            return Name.ToLower().Contains(keyword) || Tags.ToLower().Contains(keyword);
        }
    }
}
