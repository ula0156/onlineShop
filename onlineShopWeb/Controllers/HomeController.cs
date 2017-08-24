using onlineShop;
using onlineShop.Entities;
using onlineShop.Managers;
using onlineShop.ProductPickers;
using onlineShop.Products;
using onlineShopWeb.DataAccess;
using onlineShopWeb.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace onlineShopWeb.Controllers
{
    public class HomeController : Controller
    {
        private static bool shouldInitializeDatabase = false;

        private void InitializeDatabaseIfNeeded()
        {
            if (shouldInitializeDatabase)
            {
                shouldInitializeDatabase = false;
                var initializer = new DatabaseInitializer();
                var pm = new ProductsManager(ProvidersFactory.GetProductsProvider(), ProvidersFactory.GetStocksProvider());
                initializer.InitializeDatabase(pm);
            }
        }

        public ActionResult Index()
        {
            InitializeDatabaseIfNeeded();
            HomeViewModel model = new HomeViewModel();
            model.BooksList = GetBooks();
            model.SongsList = GetSongs();

            return View(model);
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
                    Filters.GetFilterByKeyWords(toSearch, typeof(Book)), 6);
                listOfBooks = listOfSearchedBooks.ConvertAll(x => (Book)x);
                return listOfBooks;
            }
            else
            {
                var listOfRandomBooks = randomItemsProductPicker.PickItems(
                    ReadersFactory.GetProductsReader(),
                    ReadersFactory.GetStocksReader(),
                    Filters.GetFilterByType(typeof(Book)), 6);
                listOfBooks = listOfRandomBooks.ConvertAll(x => (Book)x);
                return listOfBooks;
            }

        }

        private List<Song> GetSongs()
        {
            HolidayManager holidayManager = new HolidayManager();
            List<string> toSearch;
            RandomItemsProductPicker randomItemsProductPicker = new RandomItemsProductPicker();
            List<Song> listOfSongs = new List<Song>();

            if (holidayManager.IsHoliday(DateTime.Now, out toSearch))
            {
                // search items based on the keywords if it's a holiday
                var listOfSearchedSongs = randomItemsProductPicker.PickItems(
                    ReadersFactory.GetProductsReader(),
                    ReadersFactory.GetStocksReader(),
                    Filters.GetFilterByKeyWords(toSearch, typeof(Song)), 6);
                listOfSongs = listOfSearchedSongs.ConvertAll(x => (Song)x);
                return listOfSongs;
            }
            else
            {
                var listOfRandomBooks = randomItemsProductPicker.PickItems(
                    ReadersFactory.GetProductsReader(),
                    ReadersFactory.GetStocksReader(),
                    Filters.GetFilterByType(typeof(Song)), 6);
                listOfSongs = listOfRandomBooks.ConvertAll(x => (Song)x);
                return listOfSongs;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}