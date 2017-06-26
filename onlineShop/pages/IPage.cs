using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop
{
    /// <summary>
    /// This interface defines the methods that all pages have in common.
    /// An interface is a type, just like a class, with the exception that it
    /// does not contain any code, just definitions of methods.
    /// </summary>
    interface IPage
    {
        /// <summary>
        /// This method will be used to get the content of the page.
        /// </summary>
        string GetContent();

        /// <summary>
        /// This method will be used to pass in the user selection in response to 
        /// the content of the page. 
        /// Will do some actions based on the user input and it will return the 
        /// next page that will be displayed to the user.
        /// </summary>
        IPage OnUserInput(string input);
    }
}