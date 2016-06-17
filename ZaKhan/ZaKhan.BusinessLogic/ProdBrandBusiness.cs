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
    public class ProdBrandBusiness : IProdBrandBusiness
    {
        public List<ProdBrandView> ViewAll()
       {
           using (var rep = new ProdBrandRepository())
           {
               return rep.GetAll().Select(x => new ProdBrandView
               {
                   BrandId = x.BrandId,
                   BrandName = x.BrandName,

           
               }).ToList();
           }
       }

       private static ProdBrand ConvertToProduct(ProdBrandView modelView)
       {
           var dev = new ProdBrand
           {

               BrandId = modelView.BrandId,
               BrandName = modelView.BrandName,
               
           };
           return dev;
       }

       public void Insert(ProdBrandView model)
       {
           using (var rep = new ProdBrandRepository())
           {
               rep.Insert(ConvertToProduct(model)); 
           }
       }

       public void Update(ProdBrandView modelView)
       {
           using (var rep = new ProdBrandRepository())
           {
               var dev = rep.GetById(modelView.BrandId);

               if (dev != null)
               {


                   dev.BrandName = modelView.BrandName;
                 
                   rep.Update(dev);
               }
           }
       }

       public void Delete(int model)
       {
           using (var rep = new ProdBrandRepository())
           {
               var dev = rep.GetById(model);
               rep.Delete(dev);
           }
       }


       public ProdBrandView JustGetOne(int id)
       {

           return ViewAll().SingleOrDefault(x => x.BrandId.Equals(id));

       }
    }
 }
