using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaKhan.Model
{
    public class ProdCategoryView
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Enter Category Name")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

    }
}
