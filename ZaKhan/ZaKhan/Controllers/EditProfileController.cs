using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ZaKhan.Data;
using ZaKhan.Model;
using ZaKhan.BusinessLogic;

namespace ZaKhan.Controllers
{
    public class EditProfileController : Controller
    {
        // GET: EditProfile
        public UserManager<ZaKhan.Data.ApplicationUser> UserManager { get; set; }

        ApplicationDbContext con = new ApplicationDbContext();

        private readonly IPatientBusiness _client = new PatientBusiness();

        public EditProfileController()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(con));
        }

        public ActionResult Index()
        {
            string username = User.Identity.Name;
            SignUpViewModel model = new SignUpViewModel();
            ApplicationUser user = UserManager.Users.FirstOrDefault(x => x.UserName.Equals(username));
            model.UserName = user.UserName;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.EmailAddress = user.Email;
           
            //model.WorkNum = user.WorkNum;
            model.Cell = user.Cellphone;
            model.Password = user.Password;

            

            return View(model);
        }

        public ActionResult GetUser()
        {
            return View(_client.ReturnPatient(User.Identity.Name));
        }
        
        [HttpGet]
        public ActionResult Edit()
        {
            string username = User.Identity.Name;


            // Fetch the user
            ApplicationUser user = UserManager.Users.FirstOrDefault(u => u.UserName.Equals(username));

            // Construct the viewmodel
            SignUpViewModel model = new SignUpViewModel();
            model.UserName = user.UserName;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.EmailAddress = user.Email;

            //model.WorkNum = user.WorkNum;
            model.Cell = user.Cellphone;
            model.Password = user.Password;

            //model.WorkNum = user.WorkNum;


            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(SignUpViewModel model)
        {

            string username = User.Identity.Name;
            // Get the user
            ApplicationUser user = UserManager.Users.FirstOrDefault(u => u.UserName.Equals(username));

            // Update fields
            model.UserName = user.UserName;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.EmailAddress = user.Email;

            //model.WorkNum = user.WorkNum;
            model.Cell = user.Cellphone;
            model.Password = user.Password;






            UserManager.Update(user);

            con.Entry(user).State = EntityState.Modified;



            return RedirectToAction("Index");


        }


    }
}