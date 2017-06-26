using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop
{
    class Size
    {
        // TODO - finish implementing this class by adding a constructor that requires
        // all the mandatory information needed to have a Size.
        // Also add the properties that a Size has (length, width, depth, weight).
        public Size(double length, double width, double depth, double weight)
        {
            Length = length;
            Width = width;
            Depth = depth;
            Weight = weight;
        }
        #region Properies:
        double Length { get; }
        double Width { get; }
        double Depth { get; }
        double Weight { get; }
        #endregion;
    }
}
