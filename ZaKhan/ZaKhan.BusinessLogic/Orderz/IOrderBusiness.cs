using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Model.Orderz;
using ZaKhan.Model.Products;

namespace ZaKhan.BusinessLogic.Orderz
{
    public  interface  IOrderBusiness
    {
        List<OrderView> ViewAll();
        void Insert(string usernam);
        void Update(OrderView modelVie);
        void Delete(int model);
        OrderView JustGetOne(int id);
        List<OrderView> MyOrdrsList(string username);
    }
}
