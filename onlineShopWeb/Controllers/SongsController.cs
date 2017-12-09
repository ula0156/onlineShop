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
    public class SongsController : Controller
    {
        public ActionResult Index(string genre)
        {
            var songModel = GetCategorizedSongs(genre);
            return View(songModel);
        }

        public ActionResult GetSongsNoCategory()
        {
            var songModel = GetSongs();
            return View(songModel);
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
                    Filters.GetFilterByKeyWords(toSearch, typeof(Song)), 20);
                listOfSongs = listOfSearchedSongs.ConvertAll(x => (Song)x);
                return listOfSongs;
            }
            else
            {
                var listOfRandomBooks = randomItemsProductPicker.PickItems(
                    ReadersFactory.GetProductsReader(),
                    ReadersFactory.GetStocksReader(),
                    Filters.GetFilterByType(typeof(Song)), 20);
                listOfSongs = listOfRandomBooks.ConvertAll(x => (Song)x);
            }

            return listOfSongs;
        }

        private List<Song> GetCategorizedSongs(string genre)
        {
            var productReader = ReadersFactory.GetProductsReader();
            var listOfSongs = new List<Song>();
            foreach (var item in productReader.GetProducts())
            {
                if (item is Song && ((Song)item).Genre == genre)
                {
                    listOfSongs.Add((Song)item);
                }
            }

            return listOfSongs;
        }

        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var song = ReadersFactory.GetProductsReader().GetProducts().First(i => i.Id == id);
            return View(song);
        }
    }
}
