using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using onlineShop.Data.Database;
using onlineShop.Products;
using onlineShop.ProductPickers;
using onlineShopWeb.DataAccess;

namespace onlineShopWeb.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            var BookModel = GetBooks();
            return View(BookModel);
        }

        private List<Book> GetBooks()
        {
            RandomItemsProductPicker randomItemsProductPicker = new RandomItemsProductPicker();
            var listOfBooks = randomItemsProductPicker.PickItems(ReadersFactory.GetProductsReader(),
                ReadersFactory.GetStocksReader(), Filters.GetFilterByType(typeof(Book)), 4);
            //convert list of type Products into the list of type Book
            return listOfBooks.ConvertAll(x => (Book)x);
        }

        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = ReadersFactory.GetProductsReader().GetProducts().First(guid => guid.Id == id);
            return View(book);
        }
    }
}
