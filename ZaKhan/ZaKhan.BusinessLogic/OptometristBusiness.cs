using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;
using ZaKhan.Model;
using ZaKhan.Service;

namespace ZaKhan.BusinessLogic
{
    public class OptometristBusiness : IOptometristBusiness
    {

        public List<OptometristModel> GetOptometrists()
        {
            using (var optometristrepo = new OptometristRepository())
            {
                return optometristrepo.GetAll().Select(x => new OptometristModel() { OptometristId = x.OptometristId, LocationId = x.LocationId, OptometristName = x.OptometristName, Email = x.Email, Cell = x.Cell }).ToList();
            }
        }

        public void Insert(OptometristModel optometristView)
        {
            using (var repo = new OptometristRepository())
            {
                var op = new Optometrist();

                {

                    op.LocationId = optometristView.LocationId;
                    op.OptometristName = optometristView.OptometristName;
                    op.Cell = optometristView.Cell;
                    op.Email = optometristView.Email;

                }

                repo.Insert(op);

            }

        }

        public void Update(OptometristModel optometristView)
        {
            using (var repo = new OptometristRepository())
            {
                var op = new Optometrist();
                op = repo.GetById(optometristView.OptometristId);
                if (true)
                {
                    op.LocationId = optometristView.LocationId;
                    op.OptometristName = optometristView.OptometristName;
                    op.Cell = optometristView.Cell;
                    op.Email = optometristView.Email;
                }
                repo.Update(op);
            }
        }

        public void Delete(OptometristModel optometristView)
        {
            using (var repo = new OptometristRepository())
            {
                var bo = new Optometrist();
                bo = repo.GetById(optometristView.OptometristId);
                repo.Delete(bo);
            }
        }

        public OptometristModel GetById(int id)
        {
            using (var repo = new OptometristRepository())
            {
                return GetOptometrists().Find(x => x.OptometristId == id);
            }
        }

        //public List<OptometristView> GetOptometrist()
        //{
        //    using (var optometristrepo = new OptometristRepository())
        //    {
        //        return optometristrepo.GetAll().Select(x => new OptometristView() { OptometristName =x.OptometristName }).ToList();
        //    }
        //}
        //public OptometristModel GetByBranchId(int id)
        //{
        //    using (var repo = new OptometristRepository())
        //    {
        //        return GetOptometrists().Find(x => x.BranchId == id);
        //    }
        //}
        public void Dispose(bool disposing)
        {
            using (var repo = new OptometristRepository())
            {
                repo.Dispose();
            }
        }
    }
}
