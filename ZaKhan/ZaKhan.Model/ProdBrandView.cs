using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaKhan.Model
{
    public class ProdBrandView
    {
        [Key]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Enter Brand Name")]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
    }
}
