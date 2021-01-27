using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderProject.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public double AmountDue { get; set; }
        public enum EnumStatus
        {
            New,
            Completed,
            Cancelled
        }
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


        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails  { get; set; }
    }
}