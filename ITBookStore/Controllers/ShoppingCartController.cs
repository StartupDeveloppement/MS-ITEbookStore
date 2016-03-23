using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITBookStore.Models;

namespace ITBookStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ITStoreEntities db = new ITStoreEntities();

        public ShoppingCartController()
        {
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new ShoppingCartViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(int productID, string returnUrl)
        {
            ITProduct product = db.ITProducts.SingleOrDefault(p => p.ProductID == productID);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            GetCart().RemoveItem(productId);
            return RedirectToAction("Index", new { returnUrl });
        }

        private ShoppingCartModel GetCart()
        {
            ShoppingCartModel cart = (ShoppingCartModel)Session["Cart"];
            if (cart == null)
            {
                cart = new ShoppingCartModel();
                Session["Cart"] = cart;
            }
            return cart;
        }

    }
}