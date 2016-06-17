using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Model;

namespace ZaKhan.BusinessLogic
{
   public interface IAuditBusiness
   {
       List<AuditView> ViewAll();
       void Insert(AuditView modelVie);
       //void Update(AuditViewModel modelVie);
       void Delete(int model);
       AuditView JustGetOne(int id);
   }
}
