using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaKhan.Data
{
   public class Audit
   {
       public Guid AuditID { get; set; }
       public string UserName { get; set; }
       public string Event { get; set; }
       public DateTime TimeAccessed { get; set; }
   }
}
