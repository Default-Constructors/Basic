using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;

namespace ZaKhan.Service
{
   public  class AuditRepository :IAuditRepository
   {
        private ApplicationDbContext _datacontext = null;
        private readonly IRepository<Audit> _storeLocationRepository;

        public AuditRepository()
        {
            _datacontext = new ApplicationDbContext();
            _storeLocationRepository = new RepositoryService<Audit>(_datacontext);

        }

        public Audit GetById(int id)
        {
            return _storeLocationRepository.GetById(id);
        }

        public List<Audit> GetAll()
        {
            return _storeLocationRepository.GetAll().ToList();
        }

        public void Insert(Audit model)
        {
            _storeLocationRepository.Insert(model);
        }

        public void Update(Audit model)
        {
            _storeLocationRepository.Update(model);
        }

        public void Delete(Audit model)
        {
            _storeLocationRepository.Delete(model);
        }

        public IEnumerable<Audit> Find(Func<Audit, bool> predicate)
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

