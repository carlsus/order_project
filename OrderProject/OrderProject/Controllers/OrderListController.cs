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
    public class OrderListController : Controller
    {
        private readonly IPurchaseOrder _po;
        private readonly ICustomer _customer;
        public OrderListController()  
        {
            _po = new PurchaseOrderRepository(new OrderContext());  
            _customer=new CustomerRepository(new OrderContext());
        }

        public OrderListController(IPurchaseOrder po)  
        {
            _po = po;  
        }

        public OrderListController(ICustomer customer)
        {
            _customer = customer;
        }  
        // GET: OrderList
        public ActionResult Index()
        {
            var po = _po.GetPurchaseOrders();
            return View(po);
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new OrderListViewModel
            {
                Customers = _customer.GetCustomers(),
                PurchaseOrder = new PurchaseOrder()
            };
            return View(viewModel);
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchaseOrder po)
        {
            
           
            if (ModelState.IsValid)
            {
                if (po.Id == 0)
                {
                    _po.AddPO(po);
                    _po.Save();
                    
                }
                else
                {
                    _po.UpdatePO(po);
                    _po.Save();
                }   
             }
           

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var po = _po.GetPOById(id);
            var list = JsonConvert.SerializeObject(po,
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
            _po.DeletePO(id);
            _po.Save();
            
        }
    }
}