using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;
using ZaKhan.Model.Products;
using ZaKhan.Service.Product;
using ZaKhan.Model;
using ZaKhan.Service;

namespace ZaKhan.BusinessLogic.Product
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly ProdCategoryRepository _cat = new ProdCategoryRepository();
        private readonly ProdBrandRepository _brand = new ProdBrandRepository();
        
       public List<ProductView> ViewAll()
       {
           using (var rep = new ProductRepository())
           {
               return rep.GetAll().Select(x => new ProductView
               {
                   Id = x.Id,
                   Name = x.Name,
                   Description = x.Description,
                   price = x.price,
                   SerialCode = x.SerialCode,
                   ImageUrl=x.ImageUrl,

                   ProdCategoryView = new ProdCategoryView()
                   {
                       CategoryId = x.CategoryId,
                       CategoryName = _cat.GetAll().ToList().Find(y => y.CategoryId == x.CategoryId).CategoryName,

                   },

                   ProdBrandView = new ProdBrandView()
                   {
                       BrandId = x.BrandId,
                       BrandName = _brand.GetAll().ToList().Find(y => y.BrandId == x.BrandId).BrandName,
                   }
                   

               }).ToList();
           }
       }

       public List<ProductView> Search(string SearchString)
       {
           using (var patientrepo = new ProductRepository())
           {
               return patientrepo.GetAll().Select(x => new ProductView() { Id = x.Id, Name = x.Name, Description = x.Description, price = x.price, ImageUrl = x.ImageUrl }).Where(s => s.Name.ToUpper().Contains(SearchString.ToUpper())
               || s.Name.ToUpper().Contains(SearchString.ToUpper())).ToList();
           }
       }

       private static Products ConvertToProduct(ProductView modelView)
       {
           var dev = new Products
           {

               Id = modelView.Id,
               Name = modelView.Name,
               Description = modelView.Description,
               price = modelView.price,
               SerialCode = modelView.SerialCode,
               ImageUrl = modelView.ImageUrl,
               CategoryId = modelView.CategoryId,
               BrandId = modelView.BrandId,
               
           };
           return dev;
       }

       public void Insert(ProductView model)
       {
           using (var rep = new ProductRepository())
           {
               rep.Insert(ConvertToProduct(model)); 
           }
       }

       public void Update(ProductView modelView)
       {
           using (var rep = new ProductRepository())
           {
               var dev = rep.GetById(modelView.Id);

               if (dev != null)
               {


                   dev.Name = modelView.Name;
                   dev.Description = modelView.Description;
                   dev.price = modelView.price;
                   dev.SerialCode = modelView.SerialCode;
                   dev.ImageUrl = modelView.ImageUrl;
                   dev.CategoryId = modelView.CategoryId;
                   dev.BrandId = modelView.BrandId;

                   rep.Update(dev);
               }
           }
       }

       public void Delete(int model)
       {
           using (var rep = new ProductRepository())
           {
               var dev = rep.GetById(model);
               rep.Delete(dev);
           }
       }


       public ProductView JustGetOne(int id)
       {

           return ViewAll().SingleOrDefault(x => x.Id.Equals(id));

       }

       
    }
}
