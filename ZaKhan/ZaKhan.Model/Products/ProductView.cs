using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaKhan.Model.Products
{
    public class ProductView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Product Name")]
        [Display(Name = "Product Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Enter Product Price")]
        [Display(Name = "Product Price")]
        [DataType(DataType.Currency)]
        public double price { get; set; }


        [Required(ErrorMessage = "Enter Description")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter Serial Code")]
        [Display(Name = "Serial Code")]
        public string SerialCode { get; set; }

        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Enter Product Category name")]
        public int CategoryId { get; set; }
        public ProdCategoryView ProdCategoryView { get; set; }

        [Required(ErrorMessage = "Enter Product Brand Name")]
        public int BrandId { get; set; }
        public ProdBrandView ProdBrandView { get; set; }
    }
}
