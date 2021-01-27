using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderProject.Models;

namespace OrderProject.ViewModel
{
    public class OrderListViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
    }
}