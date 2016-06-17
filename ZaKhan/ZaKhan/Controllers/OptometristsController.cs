using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZaKhan.BusinessLogic;
using ZaKhan.Model;

namespace ZaKhan.Controllers
{
    public class OptometristController : Controller
    {
        private readonly IOptometristBusiness _optometristView = new OptometristBusiness();
        private readonly IStoreLocationBusiness _storelocationBusiness = new StoreLocationBusiness();
        // GET: Optometrist
        public ActionResult Index()
        {
            return View(_optometristView.GetOptometrists());
        }

        // GET: Optometrist/Details/5
        public ActionResult Details(int id)
        {
            var optometrist = _optometristView.GetById(id);
            return View(optometrist);
        }

        // GET: Optometrist/Create
        public ActionResult Create()
        {
            ViewData["optometristBranch"] = new SelectList(_storelocationBusiness.GetAllLocations(), "LocationId", "Description");
            return View(new OptometristModel());
        }

        // POST: Optometrist/Create
        [HttpPost]
        public ActionResult Create(OptometristModel optometristView)
        {
            if (ModelState.IsValid)
            {
                ViewData["optometristBranch"] = new SelectList(_storelocationBusiness.GetAllLocations(), "LocationId", "Description");
                _optometristView.Insert(optometristView);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Please Fill In Your Details Correctly");
            }

            return View(optometristView);
        }

        // GET: Optometrist/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["optometristBranch"] = new SelectList(_storelocationBusiness.GetAllLocations(), "LocationId", "Description");
            var optometrist = _optometristView.GetById(id);
            return View(optometrist);
        }

        // POST: Optometrist/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OptometristModel optometristView)
        {
            if (ModelState.IsValid)
            {
                //  var previous = _client.GetClientById(clientView.Client_Id);
                ViewData["optometristBranch"] = new SelectList(_storelocationBusiness.GetAllLocations(), "LocationId", "Description");
                _optometristView.Update(optometristView);

                return RedirectToAction("Index");

            }
            return View();
        }

        // GET: Optometrist/Delete/5
        public ActionResult Delete(int id)
        {
            var optometist = _optometristView.GetById(id);
            return View(optometist);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            var optometrist = _optometristView.GetById(id);
            _optometristView.Delete(optometrist);
            return RedirectToAction("Index");
        }

      
    }
}
