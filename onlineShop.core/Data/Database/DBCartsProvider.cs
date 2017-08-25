using onlineShop.core.Entities;
using onlineShop.Data;
using onlineShop.Data.Database;
using System.Linq;

namespace onlineShop.core.Data.Database
{
    public class DBCartsProvider : ICartsProvider
    {
        private ReservationsModel _reservationsModel;

        public DBCartsProvider()
        {
            _reservationsModel = new ReservationsModel();
        }

        public Cart GetCartForSession(string sessionId)
        {
            var cart = _reservationsModel.Carts.Where(sId => sId.SessionId == sessionId).FirstOrDefault();
            if (cart == null)
            {
                cart = new Cart(sessionId);
            }

            return cart;
        }

        public void SaveCart(Cart cart)
        {
            var existingCart = _reservationsModel.Carts.FirstOrDefault(c => c.SessionId == cart.SessionId);
            if (existingCart != null)
            {
                existingCart._Products = cart._Products;
            } else
            {
                _reservationsModel.Carts.Add(cart);
            }
            _reservationsModel.SaveChanges();
        }
    }
}
