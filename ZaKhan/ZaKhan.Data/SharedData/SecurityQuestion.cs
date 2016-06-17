using System.ComponentModel.DataAnnotations;

namespace ZaKhan.Data.SharedData
{
    public enum SecurityQuestion
    {
        
        [Display(Name = "Your mom's maiden name?")]
        Maiden,
        [Display(Name = "Your first pet name?")]
        Pet,
        [Display(Name = "Your first library card number?")]
        CardNumber,
        [Display(Name = "Your best friend's name?")]
        BestFriend,
        [Display(Name = "Colour of your first car?")]
        Colour
    }
}
