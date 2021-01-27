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
    public class SKUController : Controller
    {
        private readonly ISKU _sku;  
   
        public SKUController()  
        {
            _sku = new SKURepository(new OrderContext());  
        }

        public SKUController(ISKU sku)  
        {
            _sku = sku;  
        }  
        
        public ActionResult Index()
        {

            var viewModel = new SKUViewModel
            {
                Skus = _sku.GetSKU(),
                Sku = new SKU()
            };
            return View(viewModel);
            
        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SKU sku)
        {
            
           
            if (ModelState.IsValid)
            {
                if (sku.Id == 0)
                {
                    _sku.AddSku(sku);
                    _sku.Save();
                    
                }
                else
                {
                    _sku.UpdateSku(sku);
                    _sku.Save();
                }   
             }
           

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sku = _sku.GetSkuById(id);
            var list = JsonConvert.SerializeObject(sku,
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
            _sku.DeleteSku(id);
            _sku.Save();
            
        } 
    }
}