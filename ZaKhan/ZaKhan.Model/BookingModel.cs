using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ZaKhan.Model
{
    public class BookingModel
    {
        [Key]
        public int BookingID { get; set; }
        public string Username { get; set; }

        [Required(ErrorMessage = "You must select a Branch")]
        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }

        [Display(Name = "Optometrist Name")]
        public string OptometristName { get; set; }

        [Required(ErrorMessage = "You must select a Date")]
        [Display(Name = "Booked Date")]
        public string BookedDate { get; set; }

        [Required(ErrorMessage = "You must select a Time")]
        [Display(Name = "Booked Time")]
        public string BookedTime { get; set; }

        public string Status { get; set; }

        [Display(Name = "Total cost")]
        public double TotalCost { get; set; }


        public IList<SelectListItem> Branch { get; set; }


        public IList<SelectListItem> Optometrist { get; set; }
    }
}
