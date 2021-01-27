using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderProject.Models;

namespace OrderProject.ViewModel
{
    public class CustomerViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public Customer Customer { get; set; }
    }
}