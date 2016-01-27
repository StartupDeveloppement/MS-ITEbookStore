using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITBookStore.Models;
using ITBookStore.Properties;

namespace ITBookStore.Controllers
{
    public class ShopController : Controller
    {
        private ITStoreEntities db = new ITStoreEntities();

        // nbre de Products par page :
        // private const int PAGE_SIZE = 3;
        private int PAGE_SIZE = Settings.Default.NbreItemperPage;


        public ActionResult Index(int page = 1, int categoryID = 0, string searchString = "")
        {
            // retourne dans la Vue un objet de type "ProductsModel"
            return View(GetModel(page, categoryID, searchString));
        }

        [HttpPost]
        public ActionResult Index(ITProductsModel productsModel)
        {
            int page = 1;
            int categoryID = productsModel.CategoryID;

            // retourne dans la Vue un objet de type "ProductsModel"
            return View(GetModel(page, categoryID, productsModel.SearchString));
        }

        private ITProductsModel GetModel(int page, int categoryID, string searchString)
        {
            /* Récupère la Liste des 4 Produits
            * à afficher sur la page courante
             * et appartenant à la Catégorie 
             * demandée dans la requête Url : */
            var data = db.ITProducts.Select(p => p)
                    .Where(p => categoryID == 0 || p.CategoryID == categoryID)
                    .Where(p => string.IsNullOrEmpty(searchString) || p.ProductName.Contains(searchString)  
                        || p.Description.Contains(searchString)
                        )
                        .OrderBy(p => p.ProductName)
                        .Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);

            ITProductsModel model = new ITProductsModel
            {
                /* La liste des 4 produits à afficher
                 * appartenant à la même Catégorie: */
                ITProductList = data,

                Pagination = new PaginationModel
                {
                    CurrentPage = page,
                    ItemsPerPage = PAGE_SIZE,

                    /* Si la Catégorie sélectionnée est égale à O,
                     *      => alors on récupère le nombre total des Produits de la Base de données
                     * 
                     * si la Catégorie sélectionnée est différente de 0,
                     *      => alors on récupère le Nombre de Produits 
                     *          dont la CategoryID est identique à la CategoryID de la requête Url : */
                    TotalItems = categoryID == 0 ?
                        db.ITProducts.Count() :
                        db.ITProducts.Select(p => p)
                            .Where(p => p.CategoryID == categoryID)
                            .Where(p => p.Description.Contains(searchString)).Count()
                },
                CategoryID = categoryID
            };

            // retourne un objet de type "ProductsModel"
            return model;
        }

    }
}

