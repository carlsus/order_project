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
        private readonly ISKU _sku;
        public OrderListController()  
        {
            _po = new PurchaseOrderRepository(new OrderContext());  
            _customer=new CustomerRepository(new OrderContext());
            _sku=new SKURepository(new OrderContext());
        }

        public OrderListController(IPurchaseOrder po)  
        {
            _po = po;  
        }

        public OrderListController(ICustomer customer)
        {
            _customer = customer;
        }

        public OrderListController(ISKU sku)
        {
            _sku = sku;
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
                Skus = _sku.GetActive(),
                PurchaseOrder = new PurchaseOrder()
            };
            return View(viewModel);
            
        }
        
        [HttpPost]
 
        public ActionResult Save(OrderViewModel items)
        {

            if (ModelState.IsValid)
            {
                _po.AddPO(items);
                _po.Save(); 
            }

            return RedirectToAction("Index", "OrderList");
  
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