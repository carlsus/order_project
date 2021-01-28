using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using OrderProject.Models;
using OrderProject.Repositories;
using OrderProject.ViewModel;

namespace OrderProject.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomer _customer;  
   
        public CustomerController()  
        {
            _customer = new CustomerRepository(new OrderContext());  
        }

        public JsonResult IsMobileExist(string mobile)
        {
            
            return Json(_customer.SearchMobile(mobile).Any(), JsonRequestBehavior.AllowGet);
        } 
        public JsonResult IsFullName(string fullname)
        {

            return Json(_customer.SearchFullName(fullname), JsonRequestBehavior.AllowGet);
        }  
        public CustomerController(ICustomer customer)  
        {
            _customer = customer;  
        }  
        // GET: Customer
        public ActionResult Index()
        {

            var viewModel = new CustomerViewModel
            {
                Customers = _customer.GetCustomers(),
                Customer = new Customer()
            };
            return View(viewModel);
            
        }
        

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            
           
            if (ModelState.IsValid)
            {
                if (customer.Id == 0)
                {
                    _customer.AddCustomer(customer);
                    _customer.Save();
                    
                }
                else
                {
                    _customer.UpdateCustomer(customer);
                    _customer.Save();
                }   
             }
           

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = _customer.GetCustomerById(id);
            var list = JsonConvert.SerializeObject(customer,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });

            return Content(list, "application/json");
        }

        [HttpPost]
        public void ConfirmDelete(int id)
        {
            _customer.DeleteCustomer(id);
            _customer.Save();
            
        }  
    }
}