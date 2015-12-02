using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITBookStore.Models;

namespace ITBookStore.Models
{
    public class ITProductsModel
    {
        public IEnumerable<ITProduct> ITProductList { get; set; }
        public PaginationModel Pagination { get; set; }

    }
}