using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;
using ZaKhan.Model.ShoppingCart;

namespace ZaKhan.BusinessLogic.ShoppingCartz
{
   public interface IShoppingCartBusiness
    {
        
        List<ShoopingCartView> GetAllCarts();
       

        List<ShoopingCartView> GetMyCart(string username);



        void AddToCart(string username, int pid);


       void Delete(int model);


       ShoopingCartView JustGetOne(int id);

       void Update(ShoopingCartView modelVie);

       void UpdateCheck(string username);





    }
}
