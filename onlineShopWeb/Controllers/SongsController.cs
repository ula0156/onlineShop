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
    public class SongsController : Controller
    {
        public ActionResult Index()
        {
            var songModel = GetSongs();
            return View(songModel);
        }
        private List<Song> GetSongs()
        {
            RandomItemsProductPicker randomItemsPicker = new RandomItemsProductPicker();
            var listOfSongs = randomItemsPicker.PickItems(
                ReadersFactory.GetProductsReader(),
                ReadersFactory.GetStocksReader(),
                Filters.GetFilterByType(typeof(Song)), 4);
            return listOfSongs.ConvertAll(x => (Song)x);
        }

        // in the index view -> see hyperLink where id is indicated!
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
