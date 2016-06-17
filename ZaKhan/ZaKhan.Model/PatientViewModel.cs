using System.ComponentModel.DataAnnotations;
using ZaKhan.Data.SharedData;

namespace ZaKhan.Model
{
    public class PatientViewModel
    {
      
        [Key]
        public int PatientId { get; set; }

        public string UserName { get; set; }

         [Display(Name = "Identification Number")]
        public string IdentificationNumber { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [Display(Name = "Cellphone")]
        public string Cellphone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "Zip Code")]
        public double? ZipCode { get; set; }
       [Display(Name = "Occupation")]
        public string Occupation { get; set; }
        [Display(Name = " Security Question ")]
        public SecurityQuestion SecurityQuestion { get; set; }
         [Display(Name = " Security Answer ")]
        public string SecurityAnswer { get; set; }
    }
}
