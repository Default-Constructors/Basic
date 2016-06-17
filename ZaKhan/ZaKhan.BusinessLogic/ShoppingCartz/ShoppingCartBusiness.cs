using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Model.ShoppingCart;
using ZaKhan.BusinessLogic.Product;
using ZaKhan.Data;
using ZaKhan.Model.Products;
using ZaKhan.Service.ShoppingCartz;

namespace ZaKhan.BusinessLogic.ShoppingCartz
{
   public class ShoppingCartBusiness : IShoppingCartBusiness
    {
       ProductBusiness product = new ProductBusiness();

        public List<ShoopingCartView> GetAllCarts()
        {
            using (var repo = new ShoppingCartRepository())
            {
                return repo.GetAll().Select(p => new ShoopingCartView
                {
                    Id = p.Id,
                    isBought = p.isBought,
                    Username = p.Username,
                    Price = p.Price,
                    SubCost = p.SubCost,
                    ProductID = p.ProductID,
                    ProuductName = p.ProuductName,
                    Qty = p.Qty
                }).ToList();
            }
        }

       private List<ShoopingCartView> MyCartItemsNotBought()
       {
           return GetAllCarts().Where(x => x.isBought.Equals(false)).ToList();
       }
      

       public List<ShoopingCartView> GetMyCart(string username)
       {
           return MyCartItemsNotBought().Where(x => x.Username.Equals(username)).ToList();
       }

       public void AddToCart(string username, int pid)
       {
           using (var repo = new ShoppingCartRepository())
           {

               ProductView por = product.JustGetOne(pid);

               ShoppingCart obj = new ShoppingCart
               {
                   isBought = false,
                   Price = por.price,
                   ProuductName = por.Name,
                   Qty = 1,
                   SubCost = por.price,
                   Username = username,
                   ProductID = por.Id
               };

               repo.Insert(obj);
           }

       }

      

       public double ComputeTotal(string username)
       {
           return GetMyCart(username).Sum(x => x.SubCost);
       }

       public void Delete(int model)
       {
           using (var rep = new ShoppingCartRepository())
           {
               var dev = rep.GetById(model);
               rep.Delete(dev);
           }
       }

       public ShoopingCartView JustGetOne(int id)
       {

           return GetAllCarts().SingleOrDefault(x => x.Id.Equals(id));

       }

       public void Update(ShoopingCartView modelVie)
       {
           using (var rep = new ShoppingCartRepository())
           {
               var dev = rep.GetById(modelVie.Id);

               if (dev != null)
               {

                   dev.Qty = modelVie.Qty;
                   dev.SubCost = modelVie.Qty*dev.Price;
                 

                   rep.Update(dev);
               }
           }
       }

       public void UpdateCheck(string username)
       {
           using (var rep = new ShoppingCartRepository())
           {
               List<ShoppingCart> shop = rep.GetAll().Where(x => x.Username.Equals(username)).ToList();

               foreach (ShoppingCart a in shop)
               {
                   a.isBought = true;

                   rep.Update(a);
               }
           }
       }
    }
}
