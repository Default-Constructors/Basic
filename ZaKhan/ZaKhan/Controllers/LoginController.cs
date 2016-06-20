using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using ZaKhan.BusinessLogic;
using ZaKhan.Model;

namespace ZaKhan.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            var loginview = new LoginModel();
            return View(loginview);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin").Equals(true))
                {


                    var loginbusiness = new LoginBusiness();
                    var result = await loginbusiness.LogUserIn(model, AuthenticationManager);
                    if (result)
                        return RedirectToAction("Admin","Login");
                    else
                    {
                        ModelState.AddModelError("", "Invalid username or password.");
                    }
                }
                else
                {
                    var loginbusiness = new LoginBusiness();
                    var result = await loginbusiness.LogUserIn(model, AuthenticationManager);
                    if (result)
                        return RedirectToLocal(returnUrl);
                    else
                    {
                        ModelState.AddModelError("", "Invalid username or password.");
                    }
                }
            }

            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignOut()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        public ActionResult Admin()
        {
            if (User.IsInRole("Admin").Equals(true))
            return View();
            else
            return RedirectToAction("Login", "Login");
        }
    }
}