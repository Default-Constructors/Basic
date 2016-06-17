using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;

namespace ZaKhan.Service.ShoppingCartz
{
    public interface IShoppingCartRepository : IDisposable
    {

        ShoppingCart GetById(int id);
        List<ShoppingCart> GetAll();
        void Insert(ShoppingCart model);
        void Update(ShoppingCart model);
        void Delete(ShoppingCart model);
        IEnumerable<ShoppingCart> Find(Func<ShoppingCart, bool> predicate);


    }
}
