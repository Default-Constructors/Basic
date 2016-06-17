using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Model.Products;

namespace ZaKhan.BusinessLogic.Product
{
    public interface IProductBusiness
    {
        List<ProductView> ViewAll();
        List<ProductView> Search(string SearchString);
        void Insert(ProductView modelVie);
        void Update(ProductView modelVie);
        void Delete(int model);
        ProductView JustGetOne(int id);
    }
}
