using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;



namespace ITBookStore.Models
{
    public class ITProductsModel
    {
        public IEnumerable<ITProduct> ITProductList { get; set; }
        public PaginationModel Pagination { get; set; }

        public int CategoryID { get; set; }

        public string SearchString { get; set; }
        public SelectList Categories()
        {
            ITStoreEntities db = new ITStoreEntities();
            var categories = from c in db.ITCategories
                             orderby c.CategoryName
                             select new
                             {
                                 c.CategoryID,
                                 c.CategoryName,
                             };
            return new SelectList(categories, "CategoryID", "CategoryName");
        }

    }
}