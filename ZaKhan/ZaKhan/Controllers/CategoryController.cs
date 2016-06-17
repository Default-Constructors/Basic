using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZaKhan.BusinessLogic;
using ZaKhan.Model;

namespace ZaKhan.Controllers
{
    public class CategoryController : Controller
    {

        ProdCategoryBusiness obj = new ProdCategoryBusiness();

        // GET: Product
        public ActionResult Index()
        {
            return View(obj.ViewAll());
        }

        public ActionResult Create()
        {
            return View(new ProdCategoryView());
        }

        [HttpPost]
        public ActionResult Create(ProdCategoryView model)
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
        public ActionResult Update(ProdCategoryView model, int id)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                model.CategoryId = id;
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
            obj.Delete(model.CategoryId);
            return RedirectToAction("Index");
        }
    }
}