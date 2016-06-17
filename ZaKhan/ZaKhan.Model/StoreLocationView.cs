using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaKhan.Model
{
    public class StoreLocationView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int LocationId { get; set; }

        [Required(ErrorMessage = "Enter mall name or description of store location ")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter Operating Hours")]
        [Display(Name = "Operating Hours")]
        [DataType(DataType.MultilineText)]
        public string OpHours { get; set; }

        [Required(ErrorMessage = "Enter store address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter store contact details ")]
        [Display(Name = "Contact")]
        public string Contact { get; set; }
    }
}
