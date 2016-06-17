using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ZaKhan.Data.SharedData;

namespace ZaKhan.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public override string UserName { get; set; }

       
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string IdentificationNumber { get; set; }
        public string Cellphone { get; set; }
        public string Password { get; set; }

        public SecurityQuestion SecurityQuestion { get; set; }

        public string SecurityAnswer { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        
    }

    

       
    }
