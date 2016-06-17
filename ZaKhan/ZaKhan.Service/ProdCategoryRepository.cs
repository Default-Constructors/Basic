using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;

namespace ZaKhan.Service
{
    public class ProdCategoryRepository : IProdCategoryRepository
    {
         private ApplicationDbContext _datacontext = null;
        private readonly IRepository<ProdCategory> _prodCategoryRepository;

        public ProdCategoryRepository()
        {
            _datacontext = new ApplicationDbContext();
            _prodCategoryRepository = new RepositoryService<ProdCategory>(_datacontext);

        }

        public ProdCategory GetById(int id)
        {
            return _prodCategoryRepository.GetById(id);
        }

        public List<ProdCategory> GetAll()
        {
            return _prodCategoryRepository.GetAll().ToList();
        }

        public void Insert(ProdCategory model)
        {
            _prodCategoryRepository.Insert(model);
        }

        public void Update(ProdCategory model)
        {
            _prodCategoryRepository.Update(model);
        }

        public void Delete(ProdCategory model)
        {
            _prodCategoryRepository.Delete(model);
        }

        public IEnumerable<ProdCategory> Find(Func<ProdCategory, bool> predicate)
        {
            return _prodCategoryRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
