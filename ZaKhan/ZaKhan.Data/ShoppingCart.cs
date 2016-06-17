using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaKhan.Data
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }

        public String Username { get; set; }

        public int ProductID { get; set; }

        public String ProuductName { get; set; }

        public double Price { get; set; }

        public int Qty { get; set; }

        public double SubCost { get; set; }

        public bool isBought { get; set; }

        public virtual Products Product { get; set; }

    }
}
