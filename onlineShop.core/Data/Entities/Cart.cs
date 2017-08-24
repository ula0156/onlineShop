using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace onlineShop.core.Entities
{
    public class Cart
    {
        [Key]
        public string SessionId { get; set; }

        public string _Products {
            get
            {
                return String.Join(";", Products);
            }

            set
            {
                var list = value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                Products = new List<Guid>();
                list.ForEach(el => Products.Add(Guid.Parse(el)));
            }
        }

        public List<Guid> Products { get; set; }

        private Cart()
        {
        }

        public Cart(string sessionId)
        {
            Products = new List<Guid>();
            SessionId = sessionId;
        }
    }
}
