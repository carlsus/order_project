using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace OrderProject.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public string Firstname { get; set; }
        [Required]
       
        public string Lastname { get; set; }


        private string _fullname;
        //[Remote("IsFullName", "Customer", ErrorMessage = "Customer Already Exist")]
        public string Fullname
        {
            get { return _fullname ?? this.Firstname + ' ' + this.Lastname; }
            set { _fullname = value; }
        }
        [MaxLength(10)]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        //[Remote("IsMobileExist", "Customer", ErrorMessage = "Mobile No Already Exist")]
        public string MobileNo { get; set; }
        public string City { get; set; }
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
    }
}