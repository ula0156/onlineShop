﻿using System;

namespace onlineShop.Products.Entities
{
    public class Size
    {
        private double _depth;

        public double Depth {
            get {
                return _depth;
            }

            set {
                if (value > 0)
                {
                    _depth = value;
                } else
                {
                    throw new InvalidOperationException("Cannot set depth to be less than 0");
                }
            }
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        /// <summary>
        /// Entity framework needs an empty constructor for all data that is stored in the database.
        /// </summary>
        private Size()
        {
        }

        public Size(double depth, double width, double height, double weight)
        {
            Depth = depth;
            Width = width;
            Height = height;
            Weight = weight;
        }
    }
}
