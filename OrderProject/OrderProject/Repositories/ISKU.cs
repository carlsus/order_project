using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderProject.Models;

namespace OrderProject.Repositories
{
    public interface ISKU
    {
        IEnumerable<SKU> GetSKU();
        IEnumerable<SKU> GetActive();
        SKU GetSkuById(int id);
        void AddSku(SKU sku);
        void UpdateSku(SKU sku);
        void DeleteSku(int id);
        void Save();
    }
}
