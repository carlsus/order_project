using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OrderProject.Models;

namespace OrderProject.Repositories
{
    public class PurchaseOrderRepository:IPurchaseOrder
    {

        private readonly OrderContext _context;

        public PurchaseOrderRepository()
        {
            _context = new OrderContext(); 
        }

        public PurchaseOrderRepository(OrderContext context)  
        {  
            _context = context;  
        } 
        public IEnumerable<PurchaseOrder> GetPurchaseOrders()
        {
            return _context.PurchaseOrder.ToList(); 
        }

        public PurchaseOrder GetPOById(int id)
        {
            return _context.PurchaseOrder.Find(id);  
        }

        public void AddPO(PurchaseOrder po)
        {
            _context.PurchaseOrder.Add(po);
            Save();
        }

        public void UpdatePO(PurchaseOrder po)
        {
            po.TimeStamp = DateTime.Now;
            po.UserId = "User 1";
            _context.Entry(po).State = EntityState.Modified;  
        }

        public void DeletePO(int id)
        {
            var po = _context.PurchaseOrder.Find(id);
            if (po != null) _context.PurchaseOrder.Remove(po);  
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