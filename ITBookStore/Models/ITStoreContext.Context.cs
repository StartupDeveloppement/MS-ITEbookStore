﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITBookStore.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ITStoreEntities : DbContext
    {
        public ITStoreEntities()
            : base("name=ITStoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ITCustomer> ITCustomers { get; set; }
        public virtual DbSet<ITOrderItem> ITOrderItems { get; set; }
        public virtual DbSet<ITOrder> ITOrders { get; set; }
        public virtual DbSet<ITProduct> ITProducts { get; set; }
    }
}
