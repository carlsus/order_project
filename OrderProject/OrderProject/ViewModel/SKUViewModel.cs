using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderProject.Models;

namespace OrderProject.ViewModel
{
    public class SKUViewModel
    {
        public IEnumerable<SKU> Skus { get; set; }
        public SKU Sku { get; set; }
    }
}