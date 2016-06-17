using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZaKhan.BusinessLogic.Product;
using ZaKhan.Model.Products;
using ZaKhan.BusinessLogic;
using ZaKhan.Data;
using ZaKhan.Model;

namespace ZaKhan.Controllers
{
    public class ProductController : Controller
    {

        ProductBusiness obj = new ProductBusiness();
        private readonly IProdCategoryBusiness _category = new ProdCategoryBusiness();
        private readonly IProdBrandBusiness _brand = new ProdBrandBusiness();
       
        // GET: Product
        public ActionResult Index(string SearchString)
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                //page = 1;
                return View(obj.Search(SearchString));
            }
            return View(obj.ViewAll());
        }

        public ActionResult CustomerIndex(string SearchString)
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                //page = 1;
                return View(obj.Search(SearchString));
            }
            return View(obj.ViewAll());
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_category.ViewAll(), "CategoryId", "CategoryName");
            ViewBag.BrandId = new SelectList(_brand.ViewAll(), "BrandId", "BrandName");
            return View(new ProductView());
        }

        //[HttpPost]
        //public ActionResult Create(ProductView model,HttpPostedFileBase file)
        //{
        //    var user = User.Identity.Name;
        //    try
        //    {
        //        if (!ModelState.IsValid) return View(model);
        //        string str = file.FileName.Substring(file.FileName.Length - 3);
        //        string path = string.Empty;
        //        path = Server.MapPath("~/images/");
        //        file.SaveAs(path = file.FileName);
        //        model.ImageUrl = file.FileName;
        //        obj.Insert(model);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        ViewBag.CategoryId = new SelectList(_category.ViewAll(), "CategoryId", "CategoryName");
        //        ViewBag.BrandId = new SelectList(_brand.ViewAll(), "BrandId", "BrandName");
        //        return View(model);
        //    }
        //}

        [HttpPost]
        public ActionResult Create(ProductView model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string str = file.FileName.Substring(file.FileName.Length - 3);
                    string path = string.Empty;
                    path = Server.MapPath("~/Content/Images/");
                    file.SaveAs(path + file.FileName);

                    model.ImageUrl = file.FileName;
                    obj.Insert(model);
                    TempData["message"] = string.Format("{0} has been created!", model.Name);
                    ViewBag.CategoryId = new SelectList(_category.ViewAll(), "CategoryId", "CategoryName");
                    ViewBag.BrandId = new SelectList(_brand.ViewAll(), "BrandId", "BrandName");
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }   

        public ActionResult Update(int id)
        {
            ViewBag.CategoryId = new SelectList(_category.ViewAll(), "CategoryId", "CategoryName");
            ViewBag.BrandId = new SelectList(_brand.ViewAll(), "BrandId", "BrandName");
            var pro = obj.JustGetOne(id);
            return View(pro);
        }

        //Update Address
        //[HttpPost, ActionName("Update")]
        //public ActionResult Update(ProductView model, int id, HttpPostedFileBase file)
        //{

        //    if (!ModelState.IsValid) 
        //    {
        //        if (file != null)
        //        {
        //            model.Id = id;
        //            string str = file.FileName.Substring(file.FileName.Length - 3);
        //            string path = string.Empty;
        //            path = Server.MapPath("~/Content/Images/");
        //            file.SaveAs(path + file.FileName);
                    
        //            model.ImageUrl = file.FileName;
        //            obj.Update(model);
        //            ViewBag.CategoryId = new SelectList(_category.ViewAll(), "CategoryId", "CategoryName");
        //            ViewBag.BrandId = new SelectList(_brand.ViewAll(), "BrandId", "BrandName");
                    
        //        }
        //            return RedirectToAction("Index");
 
        //       }
        //    return View(model);
                 
        //}

        [HttpPost, ActionName("Update")]
        public ActionResult Update(ProductView model, int id, HttpPostedFileBase file)
        {
            try
            {
                if (!ModelState.IsValid) 
                model.Id = id;
                string str = file.FileName.Substring(file.FileName.Length - 3);
                string path = string.Empty;
                path = Server.MapPath("~/Content/Images/");
                file.SaveAs(path + file.FileName);

                model.ImageUrl = file.FileName;
                obj.Update(model);
                
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.CategoryId = new SelectList(_category.ViewAll(), "CategoryId", "CategoryName");
                ViewBag.BrandId = new SelectList(_brand.ViewAll(), "BrandId", "BrandName");
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
            obj.Delete(model.Id);
            return RedirectToAction("Index");
        }
    }
}