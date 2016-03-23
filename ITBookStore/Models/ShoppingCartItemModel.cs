using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITBookStore.Models
{
    /* Cette classe représente une Ligne de commande dans un Order */
    public class ShoppingCartItemModel
    {
        public ITProduct Product { get; set; }
        public int Quantity { get; set; }

    }
}