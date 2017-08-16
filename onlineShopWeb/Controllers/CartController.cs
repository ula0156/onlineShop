using onlineShop;
using onlineShop.Managers;
using onlineShop.Products;
using onlineShopWeb.DataAccess;
using onlineShopWeb.Models;
using onlineShopWeb.Utility;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace onlineShopWeb.Controllers
{
    public class CartController : Controller
    {
        public RedirectToRouteResult AddToCart(Guid id)
        {
            // HttpContext contains an information about current context
            // Encapsulates all HTTP-specific information about an individual HTTP request.
            if (id == null)
            {
                throw new HttpException(404, "Product not found");

            }
            var identifier = UserIdentifier.GetIdentifier(HttpContext);
            var cart = ProvidersFactory.GetCartProvider().GetCart(identifier);
            var product = ReadersFactory.GetProductsReader().GetProducts().First(guid => guid.Id == id);

            string status;
            if (cart.TryAddProduct(product))
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
            var identifier = UserIdentifier.GetIdentifier(HttpContext);

            var cart = ProvidersFactory.GetCartProvider().GetCart(identifier);
            CartViewModel model = new CartViewModel();
            model.CartProducts = cart.Products;
            model.TotalPrice = cart.TotalPrice();
            model.TotalWeight = cart.TotalWeight();
            model.Status = status;

            return View(model);
        }

        public RedirectToRouteResult RemoveFromCart(Guid id)
        {
            // when user wants to remove from cart:
            // - find his cart by using identifier. Dictionary<Cart, identifier>
            // - find corresponding product which has to be removed
            // - call RemoveProduct method on cart, which also will take care of reservation.
            var identifier = UserIdentifier.GetIdentifier(HttpContext);
            var cart = ProvidersFactory.GetCartProvider().GetCart(identifier);
            var product = ReadersFactory.GetProductsReader().GetProducts().First(guid => guid.Id == id);
            cart.RemoveProduct(product);

            return RedirectToAction("DisplayCart");
        }
        
        public ActionResult Error()
        {
            return Content("Product is out of stock");
        }
    }
}