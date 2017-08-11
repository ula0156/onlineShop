using onlineShop;
using onlineShop.ProductPickers;
using onlineShop.Products;
using onlineShopWeb.DataAccess;
using onlineShopWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace onlineShopWeb.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        [HttpPost]
        public ActionResult Index(string searchText)
        {
            List<string> userSearchText = new List<string>();
            userSearchText.Add(searchText.ToLower());

            SearchViewModel model = new SearchViewModel();
            model.ListOfProducts = GetProducts(userSearchText);
            return View(model);
        }

        private List<Product> GetProducts(List<string> userSearchText)
        {
            var filter = Filters.GetFilterByKeyWords(userSearchText, typeof(Product), false);
            RandomItemsProductPicker randomProductPicker = new RandomItemsProductPicker();
            List<Product> pickedProducts = randomProductPicker.PickItems(ReadersFactory.GetProductsReader(), ReadersFactory.GetStocksReader(), filter, Constants.UNLIMITED);
            return pickedProducts;
        }
    }
}