using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;

namespace ZaKhan.Service.Product
{
    public interface IProductRepository : IDisposable
    {

        Products GetById(int id);
        List<Products> GetAll();
        void Insert(Products model);
        void Update(Products model);
        void Delete(Products model);
        IEnumerable<Products> Find(Func<Products, bool> predicate);
    }
}
