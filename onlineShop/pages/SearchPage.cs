using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop
{
    class SearchPage : IPage
    {
        private Inventory _inventory;
        private Cart _cart;
        private string _searchText;
        private bool _shouldAskSearchTextFirst;

        // This constructor is used when the user wants to search but did not enter any
        // search text yet. When the object is constructed using this constructor it will
        // just ask the user to enter some search text and navigate to a new SearchPage
        // that will be constructed using the other constructor.
        public SearchPage(Inventory inventory, Cart cart)
        {
            _shouldAskSearchTextFirst = true;
            _inventory = inventory;
            _cart = cart;
        }

        // This constructor is used when the user already entered the search text.
        // When the object is constructed using this constructor it will create
        // a SearchProductPicker and give it the search text. Then it will display
        // the list of items that are returned by the SearchProductPicker together
        // with the A. Search and B. Back options.
        public SearchPage(string searchText, Inventory inventory, Cart cart)
        {
            _shouldAskSearchTextFirst = false;
            _searchText = searchText;
            _inventory = inventory;
            _cart = cart;
        }

        // This method behaves differently based on which constructor was used to
        // create the object.
        public string GetContent()
        {
            if (_shouldAskSearchTextFirst)
            {
                return "Please enter your search text: ";
            } else
            {
                // TODO
                // use the _searchText to create a new SearchProductPicker, get the list of
                // items that the picker returns and display them like in the main page:
                // 1. Harry Potter - The chamber of secrets
                // 2. Harry Potter - My wand
                // 3. Meeting Harry
                // A. Search
                // B. Back
            }
            return "";
        }

        public IPage OnUserInput(string input)
        {
            // TODO - handle the user selection just like in the main page:
            // - if user selects an item, then return a product page for that item
            // - if the user selects search then return a search page constructed using the 
            // constructor without the searchtext(the user first needs to enter the search text)
            // - if the user selects Back, then return a MainPage.

            return null;
        }
    }
}
