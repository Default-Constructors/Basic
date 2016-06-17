using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;

namespace ZaKhan.Service
{
   public interface IProdCategoryRepository :IDisposable
    {
        ProdCategory GetById(int id);
        List<ProdCategory> GetAll();
        void Insert(ProdCategory model);
        void Update(ProdCategory model);
        void Delete(ProdCategory model);
        IEnumerable<ProdCategory> Find(Func<ProdCategory, bool> predicate);
    }
}
