using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;
using ZaKhan.Data.Orderz;

namespace ZaKhan.Service.Orderz
{
   public class OrderRepository : IOrderRepository
    {
       private ApplicationDbContext _datacontext = null;
        private readonly IRepository<Order> _produtsRepository;

        public OrderRepository()
        {
            _datacontext = new ApplicationDbContext();
            _produtsRepository = new RepositoryService<Order>(_datacontext);

        }

        public Order GetById(int id)
        {
            return _produtsRepository.GetById(id);
        }

        public List<Order> GetAll()
        {
            return _produtsRepository.GetAll().ToList();
        }

        public void Insert(Order model)
        {
            _produtsRepository.Insert(model);
        }

        public void Update(Order model)
        {
            _produtsRepository.Update(model);
        }

        public void Delete(Order model)
        {
            _produtsRepository.Delete(model);
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
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
