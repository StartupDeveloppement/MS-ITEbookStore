using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace ITBookStore.Models
{
    public class ITProductsModel
    {
        public IEnumerable<ITProduct> ITProductList { get; set; }
        public PaginationModel Pagination { get; set; }

    }
}