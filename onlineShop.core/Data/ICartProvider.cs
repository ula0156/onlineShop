using onlineShop;
using System.Collections.Generic;

namespace onlineShop.Data
{
    public interface ICartProvider
    {
        Cart GetCart(string userIdentifier);

        void CleanUpCart(List<string> sessionIdOrLogin); 
    }
}
