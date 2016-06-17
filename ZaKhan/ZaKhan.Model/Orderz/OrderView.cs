using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaKhan.Model.Orderz
{
   public class OrderView
    {
        public int OrderId { get; set; }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public double TotalCost { get; set; }
    }
}
