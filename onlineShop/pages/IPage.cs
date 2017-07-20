using onlineShop.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop.Pages
{
    public interface IPage 
    {
        // All the things in the interface are public
        string OnNavigatedTo(NavigationData data);

        IPage OnUserInput(string input);
    }
}
