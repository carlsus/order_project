using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace OrderProject.Models
{
    public class PurchaseOrderDetail
    {
        public int Id { get; set; }
        public  PurchaseOrder PurchaseOrder { get; set; }
        [ForeignKey("Sku")]
        public int Sku_Id { get; set; }
        public  SKU Sku { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        private DateTime _date = DateTime.Now;
        public DateTime TimeStamp
        {
            get { return _date; }
            set { _date = value; }
        }
        private string _userid = "User 1";
        public string UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }

    }
}