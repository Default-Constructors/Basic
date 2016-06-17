using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using ZaKhan.Data;
using ZaKhan.Model;

namespace ZaKhan.BusinessLogic
{
    public class SignUpBusiness
    {
        public UserManager<ApplicationUser> UserManager { get; set; }

        public SignUpBusiness()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }

        public bool FindUser(string userName, IAuthenticationManager authenticationManager)
        {
            var user = UserManager.FindByName(userName);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> SignUpUser(SignUpViewModel objSignUpViewModel, IAuthenticationManager authenticationManager)
        {
            var newuser = new ApplicationUser()
            {
                //Id = objRegisterModel.UserName,
                UserName = objSignUpViewModel.UserName,
                Email = objSignUpViewModel.EmailAddress,
                Password = objSignUpViewModel.Password,
                SecurityQuestion = objSignUpViewModel.SecurityQuestion,
                SecurityAnswer = objSignUpViewModel.SecurityAnswer,
                 LastName = objSignUpViewModel.LastName,
                FirstName = objSignUpViewModel.FirstName,
                Cellphone = objSignUpViewModel.Cell

            };

            var result = await UserManager.CreateAsync(
               newuser, objSignUpViewModel.Password);

            if (result.Succeeded)
            {
                await SignInAsync(newuser, false, authenticationManager);
                return true;
            }
            return false;
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent, IAuthenticationManager authenticationManager)
        {
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }
    }
}
