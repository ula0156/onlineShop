using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop
{
    class Manufacturer
    {
        // TODO - finish implementing this class by adding a constructor that requires
        // all the mandatory information needed to have a Manufacturer.
        // Also add the properties that a Manufacturer has.
        public Manufacturer(string name, ContactInformation contactInformation)
        {
            Name = name;
            ContactInformation = contactInformation;
        }
        
        #region Properties:
        public ContactInformation ContactInformation { get; }
        public string Name { get; }
        #endregion;
    }
}
