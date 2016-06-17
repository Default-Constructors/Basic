using System.Web.Mvc;
using ZaKhan.BusinessLogic;
using ZaKhan.Model;

namespace ZaKhan.MVC.Controllers
{
    //  [AuthLog(Roles = "Administrator,", Users = "")]
    public class StoreLocationController : Controller
    {
        private readonly IStoreLocationBusiness _storeLocation = new StoreLocationBusiness();

        public ActionResult Index()
        {
            return View(_storeLocation.GetAllLocations());
        }

        public ActionResult Create()
        {
            return View(new StoreLocationView());
        }

        [HttpPost]
        public ActionResult Create(StoreLocationView storeLocationModel)
        {
            if (ModelState.IsValid)
            {
                _storeLocation.Insert(storeLocationModel);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Please Fill In Your Details Correctly");
            }

            return View(storeLocationModel);
        }

        // GET: /Location/Delete/5
        public ActionResult Delete(int id)
        {
            var storeLocation = _storeLocation.GetById(id);
            return View(storeLocation);
        }

        //
        // POST: /Location/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            var storeLocation = _storeLocation.GetById(id);
            _storeLocation.Delete(storeLocation);
            return RedirectToAction("Index");
        }

        //
        // GET: /Location/Edit/5
        public ActionResult Edit(int id)
        {
            var client = _storeLocation.GetById(id);
            return View(client);
        }

        //
        // POST: /Location/Edit/5
        [HttpPost]
        public ActionResult Edit(StoreLocationView storeLocationModel)
        {
            if (ModelState.IsValid)
            {
               

                _storeLocation.Update(storeLocationModel);

                return RedirectToAction("Index");

            }
            return View();
        }
        // get address of location
        [HttpGet]
        public ActionResult View(int id)
        {
            StoreLocationBusiness storeLoc = new StoreLocationBusiness();
            var store = storeLoc.GetAllLocations().Find(x => x.LocationId.Equals(id));
            string address = store.Address;
            ViewBag.Map = address;
            return View();


        }
    }
}