using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Model;

namespace ZaKhan.BusinessLogic
{
    public interface IOptometristBusiness
    {
        //List<ZA_Khan.Model.OptometristView> GetOptometrist();
        List<ZaKhan.Model.OptometristModel> GetOptometrists();
        void Insert(OptometristModel optometristView);
        void Update(OptometristModel optometristView);
        void Delete(OptometristModel optometristView);
        OptometristModel GetById(int id);
        //OptometristModel GetByBranchId(int id);
        void Dispose(bool disposing);
    }
}
