using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;

namespace ZaKhan.Service
{
    public interface IProdBrandRepository : IDisposable
    {
        ProdBrand GetById(int id);
        List<ProdBrand> GetAll();
        void Insert(ProdBrand model);
        void Update(ProdBrand model);
        void Delete(ProdBrand model);
        IEnumerable<ProdBrand> Find(Func<ProdBrand, bool> predicate);
    }
}
