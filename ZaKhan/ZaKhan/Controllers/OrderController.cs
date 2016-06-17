using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZaKhan.BusinessLogic.Orderz;
using ZaKhan.BusinessLogic.ShoppingCartz;

namespace ZaKhan.Controllers
{
    public class OrderController : Controller
    {
        OrderBusiness obj = new OrderBusiness();
        // GET: Order

      

        public ActionResult Index()
        {
            return View(obj.ViewAll());
        }

        public ActionResult MyOrders()
        {
            string user = User.Identity.Name;

            return View(obj.MyOrdrsList(user));
        }
        
        public ActionResult CheckOut()
        {
            
            obj.Insert(User.Identity.Name);
            return RedirectToAction("MyOrders");
            
        }



        public ActionResult Delete(int id)
        {
            return View(obj.JustGetOne(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var model = obj.JustGetOne(id);
            obj.Delete(model.OrderId);
            return RedirectToAction("MyOrders");
        }

        public ActionResult Details(int id)
        {
            return View(obj.JustGetOne(id));
        }

    }
}