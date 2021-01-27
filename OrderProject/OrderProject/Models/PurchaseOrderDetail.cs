using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderProject.Models
{
    public class PurchaseOrderDetail
    {
        public int Id { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual SKU Sku { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }

    }
}