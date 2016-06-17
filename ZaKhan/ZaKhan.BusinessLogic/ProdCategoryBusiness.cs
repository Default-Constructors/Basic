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
    public class ProdCategoryBusiness: IProdCategoryBusiness
    {
        public List<ProdCategoryView> ViewAll()
       {
           using (var rep = new ProdCategoryRepository())
           {
               return rep.GetAll().Select(x => new ProdCategoryView
               {
                   CategoryId = x.CategoryId,
                   CategoryName = x.CategoryName,

           
               }).ToList();
           }
       }

       private static ProdCategory ConvertToProduct(ProdCategoryView modelView)
       {
           var dev = new ProdCategory
           {

               CategoryId = modelView.CategoryId,
               CategoryName = modelView.CategoryName,
               
           };
           return dev;
       }

       public void Insert(ProdCategoryView model)
       {
           using (var rep = new ProdCategoryRepository())
           {
               rep.Insert(ConvertToProduct(model)); 
           }
       }

       public void Update(ProdCategoryView modelView)
       {
           using (var rep = new ProdCategoryRepository())
           {
               var dev = rep.GetById(modelView.CategoryId);

               if (dev != null)
               {


                   dev.CategoryName = modelView.CategoryName;
                 
                   rep.Update(dev);
               }
           }
       }

       public void Delete(int model)
       {
           using (var rep = new ProdCategoryRepository())
           {
               var dev = rep.GetById(model);
               rep.Delete(dev);
           }
       }


       public ProdCategoryView JustGetOne(int id)
       {

           return ViewAll().SingleOrDefault(x => x.CategoryId.Equals(id));

       }
    }
}
