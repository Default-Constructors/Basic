using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;

namespace ZaKhan.Service
{
    public class StoreLocationRepository :IStoreLocationRepository
    {
        private ApplicationDbContext _datacontext = null;
        private readonly IRepository<StoreLocation> _storeLocationRepository;

        public StoreLocationRepository()
        {
            _datacontext = new ApplicationDbContext();
            _storeLocationRepository = new RepositoryService<StoreLocation>(_datacontext);

        }

        public StoreLocation GetById(int id)
        {
            return _storeLocationRepository.GetById(id);
        }

        public List<StoreLocation> GetAll()
        {
            return _storeLocationRepository.GetAll().ToList();
        }

        public void Insert(StoreLocation model)
        {
            _storeLocationRepository.Insert(model);
        }

        public void Update(StoreLocation model)
        {
            _storeLocationRepository.Update(model);
        }

        public void Delete(StoreLocation model)
        {
            _storeLocationRepository.Delete(model);
        }

        public IEnumerable<StoreLocation> Find(Func<StoreLocation, bool> predicate)
        {
            return _storeLocationRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
