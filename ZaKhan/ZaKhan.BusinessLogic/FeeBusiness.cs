using System;
using System.Collections.Generic;
using System.Linq;
using ZaKhan.Data;
using ZaKhan.Model;
using ZaKhan.Service;

namespace ZaKhan.BusinessLogic
{
   public class FeeBusiness : IFeeBusiness
   {
        
        public List<FeeView> GetFee()
        {
            using (var optometristrepo = new FeeRepository())
            {
                return optometristrepo.GetAll().Select(x => new FeeView() { FeeId = x.FeeId, Price = x.Price, Vat = x.Vat, Description = x.Description }).ToList();
            }
        }

        public void Insert(FeeView feeView)
        {
            using (var repo = new FeeRepository())
            {
                var op = new Fee();

                {
                    op.Price = feeView.Price;
                    op.Vat = feeView.Vat;
                    op.Description = feeView.Description;
                }

                repo.Insert(op);
            }
        }


        public double CalTot()
        {
            double t = 0;
            using (var repo = new FeeRepository())
            {
                FeeView feeView = new FeeView();
                var op = new Fee();
                op = repo.GetById(1);
                if (true)
                {
                    t = (op.Price) + ((op.Price) * (op.Vat / 100));
                }
                
            }
            return t;
            ;
        }


        public void Update(FeeView feeView)
        {
            using (var repo = new FeeRepository())
            {
                var op = new Fee();
                op = repo.GetById(feeView.FeeId);
                if (true)
                {

                    op.Price = feeView.Price;
                    op.Vat = feeView.Vat;
                    op.Description = feeView.Description;
                }
                repo.Update(op);
            }
        }

        public void Delete(FeeView feeView)
        {
            using (var repo = new FeeRepository())
            {
                var bo = new Fee();
                bo = repo.GetById(feeView.FeeId);
                repo.Delete(bo);
            }
        }

        public FeeView GetById(int id)
        {
            using (var repo = new FeeRepository())
            {
                return GetFee().Find(x => x.FeeId == id);
            }
        }
        public void Dispose(bool disposing)
        {
            using (var repo = new FeeRepository())
            {
                repo.Dispose();
            }
        }
    }
}
