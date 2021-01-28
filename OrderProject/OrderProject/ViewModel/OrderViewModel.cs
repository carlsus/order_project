using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderProject.Models;

namespace OrderProject.ViewModel
{
    public class OrderViewModel
    {
        public int CustomerId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }
        public double AmountDue { get; set; }
        public List<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}