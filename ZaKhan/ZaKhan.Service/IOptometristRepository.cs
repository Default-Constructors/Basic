using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;

namespace ZaKhan.Service
{
    public interface IOptometristRepository : IDisposable
    {

        Optometrist GetById(Int32 id);
        List<Optometrist> GetAll();
        void Insert(Optometrist model);
        void Update(Optometrist model);
        void Delete(Optometrist model);
        IEnumerable<Optometrist> Find(Func<Optometrist, bool> predicate);
    }

}
