using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Model;
using ZaKhan.Service;

namespace ZaKhan.BusinessLogic
{
   public interface IStoreLocationBusiness
    {
        List<ZaKhan.Model.StoreLocationView> GetAllLocations();
        void Insert(StoreLocationView storeLocationModel);
        void Update(StoreLocationView storeLocationModel);
        void Delete(StoreLocationView storeLocationModel);
        StoreLocationView GetById(int id); 
        void Dispose(bool disposing);
    }
}
