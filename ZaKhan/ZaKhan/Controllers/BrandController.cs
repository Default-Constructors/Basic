using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZaKhan.BusinessLogic;
using ZaKhan.Model;

namespace ZaKhan.Controllers
{
    public class BrandController : Controller
    {

         ProdBrandBusiness obj = new ProdBrandBusiness();

        // GET: Product
        public ActionResult Index()
        {
            return View(obj.ViewAll());
        }

        public ActionResult Create()
        {
            return View(new ProdBrandView());
        }

        [HttpPost]
        public ActionResult Create(ProdBrandView model)
        {
            var user = User.Identity.Name;
            try
            {
                if (!ModelState.IsValid) return View(model);
                obj.Insert(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult Update(int id)
        {
            return View(obj.JustGetOne(id));
        }

        //Update Address
        [HttpPost, ActionName("Update")]
        public ActionResult Update(ProdBrandView model, int id)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                model.BrandId = id;
                obj.Update(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult Details(int id)
        {
            return View(obj.JustGetOne(id));
        }


        public ActionResult Delete(int id)
        {
            return View(obj.JustGetOne(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var model = obj.JustGetOne(id);
            obj.Delete(model.BrandId);
            return RedirectToAction("Index");
        }
    }
}