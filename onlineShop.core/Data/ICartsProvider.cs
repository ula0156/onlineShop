using onlineShop.core.Entities;

namespace onlineShop.Data
{
    public interface ICartsProvider
    {
        Cart GetCartForSession(string sessionId);
        void SaveCart(Cart cart);
    }

}
