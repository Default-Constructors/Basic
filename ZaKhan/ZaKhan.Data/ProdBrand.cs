using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaKhan.Data
{
    public class ProdBrand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Enter The Brand Name")]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
    }
}
