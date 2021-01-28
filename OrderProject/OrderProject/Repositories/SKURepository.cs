using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OrderProject.Models;

namespace OrderProject.Repositories
{
    public class SKURepository:ISKU
    {

        private readonly OrderContext _context;

        public SKURepository()
        {
            _context = new OrderContext(); 
        }

        public SKURepository(OrderContext context)  
        {  
            _context = context;  
        } 
        public IEnumerable<SKU> GetSKU()
        {
            return _context.Sku.ToList();  
        }

        public IEnumerable<SKU> GetActive()
        {
            return _context.Sku.Where(m=>m.IsActive==true).ToList(); 
        }

        public SKU GetSkuById(int id)
        {
            return _context.Sku.Find(id);  
        }

        public void AddSku(SKU sku)
        {
            _context.Sku.Add(sku);
            Save(); 
        }

        public void UpdateSku(SKU sku)
        {
            sku.TimeStamp = DateTime.Now;
            sku.UserId = "User 1";
            _context.Entry(sku).State = EntityState.Modified;  
        }

        public void DeleteSku(int id)
        {
            var sku = _context.Sku.Find(id);
            if (sku != null) _context.Sku.Remove(sku); 
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
    }
}