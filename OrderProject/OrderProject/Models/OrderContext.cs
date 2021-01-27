using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrderProject.Models
{
    public class OrderContext:DbContext
    {
        public OrderContext():base("default")
        {
            
        }
    }
}