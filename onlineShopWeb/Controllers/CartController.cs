using onlineShop.core.Entities;
using onlineShop.core.Managers;
using onlineShop.Products;
using onlineShopWeb.DataAccess;
using onlineShopWeb.Models;
using onlineShopWeb.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace onlineShopWeb.Controllers
{
    public class CartController : Controller
    {
        CartsManager cartManager = new CartsManager(ProvidersFactory.GetStocksProvider(), ProvidersFactory.GetProductsProvider(),ProvidersFactory.GetReservationsProvider(), ProvidersFactory.GetCartsProvider());

        public RedirectToRouteResult AddToCart(Guid id)
        {
            // HttpContext contains an information about current context
            // Encapsulates all HTTP-specific information about an individual HTTP request.
            if (id == null)
            {
                throw new HttpException(404, "Product not found");

            }
            bool isLoggedIn;
            var identifier = UserIdentifier.GetIdentifier(HttpContext, out isLoggedIn);

            //updating last active session
            ProvidersFactory.GetSessionsProvider().UpdateOrAddSession(identifier, isLoggedIn);
            
            var product = ReadersFactory.GetProductsReader().GetProducts().First(guid => guid.Id == id);

            string status;

            if (cartManager.TryAddProduct(product, identifier))
            {
                status = "Successfully added to cart.";
            }
            else
            {
                status = "Product is out of stock. Try again later.";
            }

            return RedirectToAction("DisplayCart", new { status = status });
        }

        public ActionResult DisplayCart(string status)
        {
            // HttpContext contains an information about current context
            // Encapsulates all HTTP-specific information about an individual HTTP request.
            bool isLoggedIn;
            var identifier = UserIdentifier.GetIdentifier(HttpContext, out isLoggedIn);

            ProvidersFactory.GetSessionsProvider().UpdateOrAddSession(identifier, isLoggedIn);
            var cart = cartManager.GetCartBySessionId(identifier);
            int count = 0;
            var cartToDisplay = cartManager.GetProductsCount(cart, out count);
            CartViewModel model = new CartViewModel();
            model.CartProducts = cartToDisplay;
            model.TotalPrice = cartManager.GetTotalPrice(cartToDisplay);
            model.TotalWeight = cartManager.GetTotalWeight(cartToDisplay);
            HttpContext.Session["Total"] = model.TotalPrice;
            HttpContext.Session["Count"] = count; ;
            model.Status = status;

            return View(model);
        }

        public RedirectToRouteResult RemoveFromCart(Guid id)
        {
            // when user wants to remove from cart:
            // - find his cart by using identifier. 
            // - find corresponding product which has to be removed
            // - call RemoveProduct method on cart, which also will take care of reservation.
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }

            bool isLoggedIn;
            var identifier = UserIdentifier.GetIdentifier(HttpContext, out isLoggedIn);

            ProvidersFactory.GetSessionsProvider().UpdateOrAddSession(identifier, isLoggedIn);

            var product = ReadersFactory.GetProductsReader().GetProducts().First(guid => guid.Id == id);
            cartManager.RemoveProduct(product, identifier);

            return RedirectToAction("DisplayCart");
        }

        /**
        * This method will remove only one copy of a specified product
        */
        public RedirectToRouteResult RemoveOneCopy(Guid id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }

            bool isLoggedIn;
            var identifier = UserIdentifier.GetIdentifier(HttpContext, out isLoggedIn);

            ProvidersFactory.GetSessionsProvider().UpdateOrAddSession(identifier, isLoggedIn);

            var product = ReadersFactory.GetProductsReader().GetProducts().First(guid => guid.Id == id);
            cartManager.RemoveOneCopy(product, identifier);

            return RedirectToAction("DisplayCart");
        }

        public ActionResult Error()
        {
            return Content("Product is out of stock");
        }
    }
}