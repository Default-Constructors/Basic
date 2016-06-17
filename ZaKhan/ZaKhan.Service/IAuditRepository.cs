using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;

namespace ZaKhan.Service
{
   public interface IAuditRepository :IDisposable
   {
       Audit GetById(int id);
       List<Audit> GetAll();
       void Insert(Audit model);
       void Update(Audit model);
       void Delete(Audit model);
       IEnumerable<Audit> Find(Func<Audit, bool> predicate);
   }
}
