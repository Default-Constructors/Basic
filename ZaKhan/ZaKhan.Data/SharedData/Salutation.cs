using System.ComponentModel.DataAnnotations;

namespace ZaKhan.Data.SharedData
{
    public enum Salutation
    {
        [Display(Name = "Mr.")]
        Mr,
        [Display(Name = "Mrs.")]
        Mrs,
        [Display(Name = "Ms.")]
        Ms,
        [Display(Name = "Dr.")]
        Doctor,
        [Display(Name = "Prof.")]
        Professor
    }
}
