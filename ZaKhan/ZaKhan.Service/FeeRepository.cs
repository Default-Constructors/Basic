using System;
using System.Collections.Generic;
using System.Linq;
using ZaKhan.Data;

namespace ZaKhan.Service
{
   public class FeeRepository:IFeeRepository
   {
        private ApplicationDbContext _datacontext = null;
        private readonly IRepository<Fee> _feeRepository;

        public FeeRepository()
        {
            _datacontext = new ApplicationDbContext();
            _feeRepository = new RepositoryService<Fee>(_datacontext);

        }

        public Fee GetById(int id)
        {
            return _feeRepository.GetById(id);
        }

        public List<Fee> GetAll()
        {
            return _feeRepository.GetAll().ToList();
        }

        public void Insert(Fee model)
        {
            _feeRepository.Insert(model);
        }

        public void Update(Fee model)
        {
            _feeRepository.Update(model);
        }

        public void Delete(Fee model)
        {
            _feeRepository.Delete(model);
        }

        public IEnumerable<Fee> Find(Func<Fee, bool> predicate)
        {
            return _feeRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }

    }
}
