using System.ComponentModel.DataAnnotations;

namespace ZaKhan.Data.SharedData
{
   public enum Region
    {
       [Display(Name = "Select Region")]
       Item,
        [Display(Name = "Upper Highway")]
        UpperHighway,
        [Display(Name = "Lower Highway")]
        LowerHighway,
        [Display(Name = "Southern Suburbs")]
        SouthernSuburbs,
        [Display(Name = "South Coast")]
        SouthCoast,
        [Display(Name = "Northern Suburbs")]
        NorthernSuburbs,
        [Display(Name = "North Coast")]
        NorthCoast,
        [Display(Name = "Durban City")]
        DurbanCity

    }
}
