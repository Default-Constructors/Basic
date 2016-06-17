using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;

namespace ZaKhan.Service.Product
{
    public class ProductRepository : IProductRepository
    {

        private ApplicationDbContext _datacontext = null;
        private readonly IRepository<Products> _produtsRepository;

        public ProductRepository()
        {
            _datacontext = new ApplicationDbContext();
            _produtsRepository = new RepositoryService<Products>(_datacontext);

        }

        public Products GetById(int id)
        {
            return _produtsRepository.GetById(id);
        }

        public List<Products> GetAll()
        {
            return _produtsRepository.GetAll().ToList();
        }

        public void Insert(Products model)
        {
            _produtsRepository.Insert(model);
        }

        public void Update(Products model)
        {
            _produtsRepository.Update(model);
        }

        public void Delete(Products model)
        {
            _produtsRepository.Delete(model);
        }

        public IEnumerable<Products> Find(Func<Products, bool> predicate)
        {
            return _produtsRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
