using OnlineShop.Products;
using System;

namespace OnlineShop.Reservations
{
    public class Reservation
    {
        public readonly Guid Id;
        public readonly Guid ProductId;
        public DateTime ExpirationTime;

        public Reservation(Product product)
        {
            Id = Guid.NewGuid();
            ProductId = product.Id;
            ExpirationTime = DateTime.Now + TimeSpan.FromMinutes(10);
        }
    }
}
