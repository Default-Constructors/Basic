using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;

namespace ZaKhan.Service.ShoppingCartz
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private ApplicationDbContext _datacontext = null;
        private readonly IRepository<ShoppingCart> _CartRepository;

        public ShoppingCartRepository()
        {
            _datacontext = new ApplicationDbContext();
            _CartRepository = new RepositoryService<ShoppingCart>(_datacontext);

        }

        public ShoppingCart GetById(int id)
        {
            return _CartRepository.GetById(id);
        }

        public List<ShoppingCart> GetAll()
        {
            return _CartRepository.GetAll().ToList();
        }

        public void Insert(ShoppingCart model)
        {
            _CartRepository.Insert(model);
        }

        public void Update(ShoppingCart model)
        {
            _CartRepository.Update(model);
        }

        public void Delete(ShoppingCart model)
        {
            _CartRepository.Delete(model);
        }

        public IEnumerable<ShoppingCart> Find(Func<ShoppingCart, bool> predicate)
        {
            return _CartRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
