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

        public String SessionId { get; set; }

        private Reservation()
        {
        }

        public Reservation(Product product, string sessionId)
        {
            Id = Guid.NewGuid();
            ProductId = product.Id;
            ExpirationTime = DateTime.Now + TimeSpan.FromMinutes(10);
            SessionId = sessionId;
        }
    }
}
