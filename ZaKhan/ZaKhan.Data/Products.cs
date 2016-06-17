using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaKhan.Data
{
    public   class  Products
    {
        [Key]
        public int Id { get; set; }

        public String Name { get; set; }

        public double price { get; set; }

        public string Description { get; set; }

        public string SerialCode { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProdCategory Category { get; set; }

        [ForeignKey("BrandId")]
        public virtual ProdBrand Brand { get; set; }
     
    }
}
