using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using OrderProject.Migrations;

namespace OrderProject.Models
{
    public class OrderContext:DbContext
    {
        public OrderContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OrderContext,Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SKU> Sku { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}