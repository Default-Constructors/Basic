using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using reCAPTCHA.MVC;
using ZaKhan.BusinessLogic;
using ZaKhan.Model;
using ZaKhan.Data;

namespace ZaKhan.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IPatientBusiness _client = new PatientBusiness();
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        // GET: Register
        public ActionResult SignUp()
        {
            return View();
        }

        

        [ValidateAntiForgeryToken]
        [HttpPost]
        [CaptchaValidator]
        //[CaptchaMvc.Attributes.CaptchaVerify("Incorrect captcha text")]
        public async Task<ActionResult> SignUp(SignUpViewModel objSignUpViewModel, bool captchaValid)
        {
            PatientViewModel patient=new PatientViewModel();
            if (ModelState.IsValid)
            {
                var signUpbusiness = new SignUpBusiness();

                if (signUpbusiness.FindUser(objSignUpViewModel.UserName, AuthenticationManager))
                {
                    ModelState.AddModelError("", "User already exists");
                    return View(objSignUpViewModel);
                }

                var result = await signUpbusiness.SignUpUser(objSignUpViewModel, AuthenticationManager);

                patient.UserName = objSignUpViewModel.UserName;
                patient.IdentificationNumber = "";
                patient.FirstName = objSignUpViewModel.FirstName;
                patient.LastName = objSignUpViewModel.LastName;

                patient.Cellphone = objSignUpViewModel.Cell;
                patient.Email = objSignUpViewModel.EmailAddress;
                patient.Occupation = "";
                patient.SecurityQuestion = objSignUpViewModel.SecurityQuestion;
                patient.SecurityAnswer = objSignUpViewModel.SecurityAnswer;

                _client.Insert(patient);


                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", result.ToString());
                }
            }
            return View(objSignUpViewModel);
            }


        

    }
}