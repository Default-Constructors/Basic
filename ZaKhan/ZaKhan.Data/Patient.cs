using System.ComponentModel.DataAnnotations;
using ZaKhan.Data.SharedData;

namespace ZaKhan.Data
{
    public class Patient 
    {
        
        [Key]
        public int PatientId { get; set; }

        public string UserName { get; set; }

        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Telephone { get; set; }

        public string Cellphone { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public double? ZipCode { get; set; }
        
        public string Occupation { get; set; }

        public SecurityQuestion SecurityQuestion { get; set; }

        public string SecurityAnswer { get; set; }
    }
}
