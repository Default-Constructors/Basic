using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data.Orderz;

namespace ZaKhan.Service.Orderz
{
    public interface IOrderRepository : IDisposable
    {
        Order GetById(int id);
        List<Order> GetAll();
        void Insert(Order model);
        void Update(Order model);
        void Delete(Order model);
        IEnumerable<Order> Find(Func<Order, bool> predicate);
    }
}
