using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITBookStore.Models;

namespace ITBookStore.Controllers
{
    public class ShopController : Controller
    {

        private ITStoreEntities db = new ITStoreEntities();

        // nbre de Products par page :
        private const int PAGE_SIZE = 3;

        public ActionResult Index(int page = 1)
        {
            /* Récupère la Liste des 3 prochains Products
             * à afficher sur la page courante : */
            var data = db.ITProducts.Select(p => p)
                .OrderBy(p => p.ProductName)
                .Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);

            ITProductsModel model = new ITProductsModel
            {
                // récupération des 3 Products à afficher :
                ITProductList = data,

                Pagination = new PaginationModel
                {
                    CurrentPage = page,
                    ItemsPerPage = PAGE_SIZE,
                    TotalItems = db.ITProducts.ToList().Count()
                }
            };

            return View(model);
        }


    }
}
