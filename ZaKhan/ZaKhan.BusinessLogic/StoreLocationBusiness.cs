using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Model;
using ZaKhan.Service;
using ZaKhan.Data;

namespace ZaKhan.BusinessLogic
{
   public class StoreLocationBusiness : IStoreLocationBusiness
    {
        public List<StoreLocationView> GetAllLocations()
        {
            using (var locationrepo = new StoreLocationRepository())
            {
                return locationrepo.GetAll().Select(x => new StoreLocationView()
                {
                    LocationId = x.LocationId,
                    Description = x.Description,
                    OpHours = x.OpHours, 
                    Address = x.Address,
                    Contact = x.Contact 
                }).ToList();
            }
        }

        public void Insert(StoreLocationView storeLocationModel)
        {
            using (var repo = new StoreLocationRepository())
            {
                var dis = new StoreLocation();
                if (true)
                {
                    dis.LocationId = storeLocationModel.LocationId;
                    dis.Description = storeLocationModel.Description;
                    dis.OpHours = storeLocationModel.OpHours;
                    dis.Address = storeLocationModel.Address;
                    dis.Contact = storeLocationModel.Contact;

                }
                repo.Insert(dis);
            }
        }

        public void Update(StoreLocationView storeLocationModel)
        {
            using (var repo = new StoreLocationRepository())
            {
                var dis = new StoreLocation();
                dis = repo.GetById(storeLocationModel.LocationId);
                if (true)
                {
                   
                    dis.Description = storeLocationModel.Description;
                    dis.OpHours = storeLocationModel.OpHours;
                    dis.Address = storeLocationModel.Address;
                    dis.Contact = storeLocationModel.Contact;

                }
                repo.Update(dis);


            }
        }

        public void Delete(StoreLocationView storeLocationModel)
        {
            using (var repo = new StoreLocationRepository())
            {
                var dis = new StoreLocation();
                dis = repo.GetById(storeLocationModel.LocationId);
                repo.Delete(dis);
            }

        }
        public StoreLocationView GetById(int id)
        {
            using (var repo = new StoreLocationRepository())
            {
                return GetAllLocations().Find(x => x.LocationId == id);
            }
        }
        public void Dispose(bool disposing)
        {
            using (var repo = new StoreLocationRepository())
            {
                repo.Dispose();
            }
        }
    }
}



 