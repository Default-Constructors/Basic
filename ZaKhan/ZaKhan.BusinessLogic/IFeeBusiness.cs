
using System.Collections.Generic;
using ZaKhan.Model;

namespace ZaKhan.BusinessLogic
{
   public interface IFeeBusiness
   {
        List<FeeView> GetFee();
        void Insert(FeeView feeView);
        double CalTot();
        void Update(FeeView feeView);
        void Delete(FeeView feeView);
        FeeView GetById(int id);
        void Dispose(bool disposing);
    }
}
