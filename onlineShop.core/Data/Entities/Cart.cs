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
                /*
                 * Because EF can't read property List of obj -> created property string, which contains guids.
                 * After initiating a cart obj, in order to load the required data (_Products),
                 * converted Products (which is a List<Guid>) into the string, where each Guid is separetate from its neighbors by ;
                 */
                return String.Join(";", Products);
            }

            set
            {
                /*
                 * In order to set a value of Products to DB, convert the List<Guid> into the string. Where each guid got separated by ;
                 */
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
