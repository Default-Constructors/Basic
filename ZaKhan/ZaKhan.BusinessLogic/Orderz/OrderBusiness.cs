using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.BusinessLogic.ShoppingCartz;
using ZaKhan.Data;
using ZaKhan.Data.Orderz;
using ZaKhan.Model;
using ZaKhan.Model.Orderz;
using ZaKhan.Model.Products;
using ZaKhan.Service.Orderz;
using ZaKhan.Service.Product;

namespace ZaKhan.BusinessLogic.Orderz
{
   public class OrderBusiness : IOrderBusiness
    {
        public List<OrderView> ViewAll()
        {
            using (var rep = new OrderRepository())
            {
                return rep.GetAll().Select(x => new OrderView
                {
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   OrderId = x.OrderId,
                   TotalCost = x.TotalCost,
                   Username = x.Username
                   

                }).ToList();
            }
        }

      

       private static Order ConvertToProduct(OrderView modelView)
        {
            var x = new Order
            {

                FirstName = modelView.FirstName,
                LastName = modelView.LastName,
                OrderId = modelView.OrderId,
                TotalCost = modelView.TotalCost,
                Username = modelView.Username
                

            };
            return x;
        }

        public void Insert(string username)
        {
            using (var rep = new OrderRepository())
            {
                ApplicationDbContext dbcon = new ApplicationDbContext();


                OrderView model = new OrderView();
                var obj = new PatientBusiness();
                var shop = new ShoppingCartBusiness();

                var person = dbcon.Patients.SingleOrDefault(x => x.UserName.Equals(username));

                var tot = shop.ComputeTotal(username);

                if (tot != 0)
                {

                    if (person != null)
                    {
                        model.FirstName = person.FirstName;
                        model.LastName = person.LastName;

                    }
                    model.TotalCost = shop.ComputeTotal(username);
                    model.Username = username;

                    rep.Insert(ConvertToProduct(model));
                }
                ShoppingCartBusiness biz = new ShoppingCartBusiness();
                biz.UpdateCheck(username);
            }
        }

        public void Update(OrderView modelView)
        {
            using (var rep = new OrderRepository())
            {
                var dev = rep.GetById(modelView.OrderId);

                if (dev != null)
                {

                    rep.Update(dev);
                }
            }
        }

        public void Delete(int model)
        {
            using (var rep = new OrderRepository())
            {
                var dev = rep.GetById(model);
                rep.Delete(dev);
            }
        }


        public OrderView JustGetOne(int id)
        {

            return ViewAll().SingleOrDefault(x => x.OrderId.Equals(id));

        }

       public List<OrderView> MyOrdrsList(string username)
       {
           return ViewAll().Where(x => x.Username.Equals(username)).ToList();
       }
    }
}
