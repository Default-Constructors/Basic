using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZaKhan.BusinessLogic;
using ZaKhan.Data;
using ZaKhan.Model;

namespace ZaKhan.Controllers
{
    [Authorize]
    public class PatientUpdateController : Controller
    {
        PatientBusiness obj = new PatientBusiness();

        public ActionResult GetAll()
        {
            return View(obj.GetAllPatients());
        }


        public ActionResult MyDetails()
        {
            Patient model;

            model = obj.get(User.Identity.Name);
            return View(model);
        }


        [HttpPost]
        public ActionResult MyDetails(PatientViewModel model, string username)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                model.UserName = username;
                obj.Update(model);



                return RedirectToAction("MyAccount");
            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult MyAccount()
        {
            return View(obj.get(User.Identity.Name));
        }
        
    }
}