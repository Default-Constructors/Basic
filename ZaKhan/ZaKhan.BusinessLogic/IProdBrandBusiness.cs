using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Model;

namespace ZaKhan.BusinessLogic
{
   public interface IProdBrandBusiness
    {
        List<ProdBrandView> ViewAll();
        void Insert(ProdBrandView modelVie);
        void Update(ProdBrandView modelVie);
        void Delete(int model);
        ProdBrandView JustGetOne(int id);
    }
}
