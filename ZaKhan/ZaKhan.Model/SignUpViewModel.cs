using System.ComponentModel.DataAnnotations;
using ZaKhan.Data.SharedData;

namespace ZaKhan.Model
{
    public class SignUpViewModel
    {
        [Key]
        [Required(ErrorMessage = "Enter your username")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [StringLength(100, ErrorMessage =
            "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage ="The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter your first name")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Enter your last name")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter your Email Address")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Enter your Cellphone number")]
        [StringLength(10, ErrorMessage =
            "The {0} must be at least {2} digits long.", MinimumLength = 10)]
        [Display(Name = "Cellphone Number")]
        public string Cell { get; set; }

        [Required]
        [Display(Name = "Security question")]
        public SecurityQuestion SecurityQuestion { get; set; }

        [Required(ErrorMessage = "Enter your security question answer")]
        [Display(Name = "Security question Answer")]
        public string SecurityAnswer { get; set; }
    }
}