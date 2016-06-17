using System;
using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ZaKhan.BusinessLogic;
using ZaKhan.Data;
using ZaKhan.Model;

namespace ZaKhan.Controllers
{
    //  [AuthLog(Roles = "Administrator,", Users = "")]
    public class PatientController : Controller
    {
        private readonly IPatientBusiness _patient = new PatientBusiness();
        //private readonly  int _currentuserid;

        //public PatientController()
        //{
        //    _currentuserid = User.Identity.GetUserId<int>();
        //}

        public ActionResult PatientList()
        {
            return View(_patient.GetAllPatients());
        }

        //public ActionResult Create()
        //{
        //    return View(new PatientViewModel());
        //}

        //[HttpPost]
        //public ActionResult Create(PatientViewModel patientModel)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        patientModel.Email = User.Identity.Name;

        //        _patient.Insert(patientModel);
        //        return RedirectToAction("Index","Home");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Please Fill In Your Details Correctly");
        //    }

        //    return View(patientModel);
        //}

        //// GET: /Location/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    var Patient = _patient.GetById(id);
        //    return View(Patient);
        //}

        ////
        //// POST: /Location/Delete/5
        //[HttpPost, ActionName("Delete")]
        //public ActionResult ConfirmDelete(int id)
        //{

        //    var patient = _patient.GetById(id);
        //    _patient.Delete(patient);
        //    return RedirectToAction("Index");
        //}

        //
        // GET: /Client/Edit/5

        //
        // POST: /StoreLocation/Edit/5
        //[HttpPost]
        //public ActionResult Edit()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //  var previous = _client.GetClientById(clientView.Client_Id);
        //        int currentuserid = Convert.ToInt32(User.Identity.GetUserId());
        //        _patient.Update(currentuserid);

        //        return RedirectToAction("Index");

        //    }
        //    return View();
        //}



         //GET: /Client/Edit/5
        //public ActionResult Edit()
        //{
        //   // var currentuserid = User.Identity.GetUserId();
        //    //int p = int.Parse(currentuserid);
        //    var client = _patient.GetById(_currentuserid);
        //    return View(client);
        //}

        ////
        //// POST: /StoreLocation/Edit/5
        //[HttpPost]
        //public ActionResult Edit(PatientViewModel patientModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //  var previous = _client.GetClientById(clientView.Client_Id);

        //        _patient.Update(patientModel);

        //        return RedirectToAction("Index","Home");

        //    }
        //    return View();
        //}







        public ActionResult Edit(string username)
        {
            var user = User.Identity.Name;
            var patient = _patient.ReturnPatient(user);
            return View(patient);
        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult Edit(PatientViewModel patientModel, string username)
        {
            try
            {
                if (!ModelState.IsValid) return View(patientModel);

                //clientview.houseNumber = clientview.AddressName.Substring(0, clientview.AddressName.IndexOf(' '));
                //clientview.StreetName = clientview.AddressName.Substring(clientview.AddressName.IndexOf(' ') + 1, clientview.AddressName.IndexOf(',') - 2);
                //string x = clientview.AddressName.Substring(clientview.AddressName.IndexOf(',') + 2);
                //clientview.Suburb = x.Substring(0, x.IndexOf(','));
                _patient.UpdatePatient(patientModel);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }





    
    }



}