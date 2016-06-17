using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZaKhan.Data;

namespace ZaKhan.Data
{
   public class StoreLocation
    {
        [Key]
        public int LocationId { get; set; }

        [Display(Name = "Descrption")]
        [StringLength(100)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter Operating Hours")]
        [Display(Name = "Operating Hours")]
        [DataType(DataType.MultilineText)]
        public string OpHours { get; set; }


        [Required(ErrorMessage = "Address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Contact Number")]
        [Display(Name = "Contact Number")]
        [StringLength(10)]
        public string Contact { get; set; }

    }
}
