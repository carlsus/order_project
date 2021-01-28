using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace OrderProject.Models
{
    public class SKU
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public double UnitPrice { get; set; }
        private DateTime _date = DateTime.Now;
        public DateTime DateCreated
        {
            get { return _date; }
            set { _date = value; }
        }
        private string _createdby = "User 1";
        public string CreatedBy
        {
            get { return _createdby; }
            set { _createdby = value; }
        }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public bool IsActive { get; set; }


        public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

    }
}