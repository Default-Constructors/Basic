using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Model;

namespace ZaKhan.BusinessLogic
{
    public interface IProdCategoryBusiness
    {
        List<ProdCategoryView> ViewAll();
        void Insert(ProdCategoryView modelVie);
        void Update(ProdCategoryView modelVie);
        void Delete(int model);
        ProdCategoryView JustGetOne(int id);
    }
}
