using onlineShop.Products;
using System;
using System.ComponentModel.DataAnnotations;

namespace onlineShop.Data.Entities
{
    public class Reservation
    {
        [Key]
        public Guid Id { get; private set; }

        public Guid ProductId { get; private set; }

        public DateTime ExpirationTime { get; set; }

        private Reservation()
        {
        }

        public Reservation(Product product)
        {
            Id = Guid.NewGuid();
            ProductId = product.Id;
            ExpirationTime = DateTime.Now + TimeSpan.FromMinutes(10);
        }
    }
}
