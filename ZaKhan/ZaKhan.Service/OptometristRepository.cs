using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;

namespace ZaKhan.Service
{
    public class OptometristRepository : IOptometristRepository
    {

        private ApplicationDbContext _datacontext = null;
        private readonly IRepository<Optometrist> _optometristRepository;

        public OptometristRepository()
        {
            _datacontext = new ApplicationDbContext();
            _optometristRepository = new RepositoryService<Optometrist>(_datacontext);

        }

        public Optometrist GetById(int id)
        {
            return _optometristRepository.GetById(id);
        }

        public List<Optometrist> GetAll()
        {
            return _optometristRepository.GetAll().ToList();
        }

        public void Insert(Optometrist model)
        {
            _optometristRepository.Insert(model);
        }

        public void Update(Optometrist model)
        {
            _optometristRepository.Update(model);
        }

        public void Delete(Optometrist model)
        {
            _optometristRepository.Delete(model);
        }

        public IEnumerable<Optometrist> Find(Func<Optometrist, bool> predicate)
        {
            return _optometristRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
