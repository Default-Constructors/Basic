using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;

namespace ZaKhan.Service
{
    public class ProdBrandRepository: IProdBrandRepository
    {
         private ApplicationDbContext _datacontext = null;
        private readonly IRepository<ProdBrand> _prodBrandRepository;

        public ProdBrandRepository()
        {
            _datacontext = new ApplicationDbContext();
            _prodBrandRepository = new RepositoryService<ProdBrand>(_datacontext);

        }

        public ProdBrand GetById(int id)
        {
            return _prodBrandRepository.GetById(id);
        }

        public List<ProdBrand> GetAll()
        {
            return _prodBrandRepository.GetAll().ToList();
        }

        public void Insert(ProdBrand model)
        {
            _prodBrandRepository.Insert(model);
        }

        public void Update(ProdBrand model)
        {
            _prodBrandRepository.Update(model);
        }

        public void Delete(ProdBrand model)
        {
            _prodBrandRepository.Delete(model);
        }

        public IEnumerable<ProdBrand> Find(Func<ProdBrand, bool> predicate)
        {
            return _prodBrandRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
