using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaKhan.Model
{
    public class OptometristModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required]
        [Display(Name = "Optometrist ID")]
        public int OptometristId { get; set; }

        [Required]
        [Display(Name = "Branch ID")]
        public int LocationId { get; set; }

        [Required]
        //[RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid Optometrist Name")]
        [Display(Name = "Optometrist Name")]
        public string OptometristName { get; set; }

        [Required]
        [Phone]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Your cellphone number must be 10 Digits")]
        [Display(Name = "Cellphone Number")]
        public string Cell { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }



    }
}
