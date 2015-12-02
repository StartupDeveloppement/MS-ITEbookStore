using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITBookStore.Models;

namespace ITBookStore.Controllers
{
    public class ItemDetailController : Controller
    {
        public ActionResult Index(int id)
        {
            using (var db = new ITStoreEntities())
            {
                var data = db.ITProducts.SingleOrDefault(p => p.ProductID == id);

                return View(data);
            }

        }
    }
}