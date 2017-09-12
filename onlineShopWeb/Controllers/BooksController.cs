using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using onlineShop.Products;
using onlineShopWeb.DataAccess;
using onlineShop.Entities;
using onlineShop.ProductPickers;

namespace onlineShopWeb.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index(string genre)
        {
            var BookModel = GetCategorisedBooks(genre);
            return View(BookModel);
        }

        public ActionResult GetBooksNoCategory()
        {
            var BookModel = GetBooks();
            return View(BookModel);
        }

        private List<Book> GetBooks()
        {
            HolidayManager holidayManager = new HolidayManager();
            List<string> toSearch;
            RandomItemsProductPicker randomItemsProductPicker = new RandomItemsProductPicker();
            List<Book> listOfBooks = new List<Book>();

            if (holidayManager.IsHoliday(DateTime.Now, out toSearch))
            {
                // search items based on the keywords if it's a holiday
                var listOfSearchedBooks = randomItemsProductPicker.PickItems(
                    ReadersFactory.GetProductsReader(),
                    ReadersFactory.GetStocksReader(),
                    Filters.GetFilterByKeyWords(toSearch, typeof(Book)), 5);
                listOfBooks = listOfSearchedBooks.ConvertAll(x => (Book)x);
                return listOfBooks;
            }
            else
            {
                var listOfRandomBooks = randomItemsProductPicker.PickItems(
                    ReadersFactory.GetProductsReader(),
                    ReadersFactory.GetStocksReader(),
                    Filters.GetFilterByType(typeof(Book)), 5);
                listOfBooks = listOfRandomBooks.ConvertAll(x => (Book)x);
            }
            return listOfBooks;
        }

        private List<Book> GetCategorisedBooks(string genre)
        {
            List<Book> listOfBooks = new List<Book>();
            var productsReader = ReadersFactory.GetProductsReader();
            foreach (var product in productsReader.GetProducts())
            {
                if (product is Book && ((Book)product).Genre == genre)
                {
                    listOfBooks.Add((Book)product);
                }
            }

            return listOfBooks;
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
