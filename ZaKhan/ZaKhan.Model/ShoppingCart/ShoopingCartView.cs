using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaKhan.Model.ShoppingCart
{
    public class ShoopingCartView
    {
        public int Id { get; set; }

        public String Username { get; set; }

        public int ProductID { get; set; }

        [Display(Name = "Product Name")]
        public String ProuductName { get; set; }

        public double Price { get; set; }

        [Display(Name="Quantity")]
        [Required(ErrorMessage = "Quantity is Required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive number")]
        public int Qty { get; set; }

        [Display(Name = "Cost")]
        public double SubCost { get; set; }

        public bool isBought { get; set; }
    }
}
