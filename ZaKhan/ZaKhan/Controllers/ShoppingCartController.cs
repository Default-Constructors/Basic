using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZaKhan.BusinessLogic.ShoppingCartz;
using ZaKhan.Model.ShoppingCart;

namespace ZaKhan.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoppingCartBusiness _cartrepository = new ShoppingCartBusiness();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View(_cartrepository.GetAllCarts());
        }

        public ActionResult MyCart()
        {
            ViewBag.Total = _cartrepository.ComputeTotal(User.Identity.Name);
            return View(_cartrepository.GetMyCart(User.Identity.Name));
        }


        public ActionResult AddToCart(int id)
        {
            if (User.Identity.IsAuthenticated.Equals(false))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
            

            _cartrepository.AddToCart(User.Identity.Name, id);
            return RedirectToAction("MyCart");
        }
    }

        public ActionResult CartDetails(int id)
        {
            return View(_cartrepository.JustGetOne(id));
        }


        public ActionResult Delete(int id)
        {
            return View(_cartrepository.JustGetOne(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var model = _cartrepository.JustGetOne(id);
            _cartrepository.Delete(model.Id);
            return RedirectToAction("MyCart");
        }


        public ActionResult Update(int id)
        {
            return View(_cartrepository.JustGetOne(id));
        }

        //Update Address
        [HttpPost, ActionName("Update")]
        public ActionResult Update(ShoopingCartView model, int id)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                model.Id = id;
                _cartrepository.Update(model);
                return RedirectToAction("MyCart");
            }
            catch
            {
                return View(model);
            }
        }
    }
}