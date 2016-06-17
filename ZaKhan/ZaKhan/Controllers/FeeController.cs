using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZaKhan.BusinessLogic;
using ZaKhan.Data;
using ZaKhan.Model;
using ZaKhan.Service;

namespace ZaKhan.Controllers
{
    [Audit]
    public class FeeController : Controller
    {
        private readonly IFeeBusiness _feeBusiness = new FeeBusiness();

        // GET: Fee
        [Audit]
        public ActionResult Index()
        {
            return View(_feeBusiness.GetFee());
        }

        // GET: Fee/Details/5
        public ActionResult Details(int id)
        {
            var fee = _feeBusiness.GetById(id);
            return View(fee);
        }

        // GET: Feee/Create
        [Audit]
        public ActionResult Create()
        {
            return View(new FeeView());
        }

        // POST: Fee/Create
        [HttpPost]
        public ActionResult Create(FeeView feeView)
        {
            if (ModelState.IsValid)
            {
                _feeBusiness.Insert(feeView);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Please Fill In Your Figuse Correctly");
            }

            return View(feeView);
        }

        // GET: Fee/Edit/5
        public ActionResult Edit(int id)
        {
            var optometrist = _feeBusiness.GetById(id);
            return View(optometrist);
        }

        // POST: Fee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FeeView feeView)
        {
            if (ModelState.IsValid)
            {
                _feeBusiness.Update(feeView);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Fee/Delete/5
        public ActionResult Delete(int id)
        {
            var optometist = _feeBusiness.GetById(id);
            return View(optometist);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            var fee = _feeBusiness.GetById(id);
            _feeBusiness.Delete(fee);
            return RedirectToAction("Index");
        }

        
    }
}