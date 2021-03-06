﻿using onlineShop.Products.Entities;

namespace onlineShop.Products
{
    public abstract class PhysicalProduct : Product
    {
        public string Color { get; set; }

        public Size Size { get; set; }

        protected PhysicalProduct()
        {
        }

        public PhysicalProduct(string name, double price, string tags, string imagePath, string color, Size size) : base(name, price, tags, imagePath)
        {
            Color = color;
            Size = size;
        }
    }
}