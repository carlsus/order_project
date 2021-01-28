using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderProject.Models;
using OrderProject.ViewModel;

namespace OrderProject.Repositories
{
    public interface IPurchaseOrder
    {
        IEnumerable<PurchaseOrder> GetPurchaseOrders();
        PurchaseOrder GetPOById(int id);
        void AddPO(OrderViewModel po);
        void UpdatePO(PurchaseOrder po);
        void DeletePO(int id);
        void Save(); 
    }
}
