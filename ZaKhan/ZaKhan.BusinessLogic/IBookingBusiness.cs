using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Model;

namespace ZaKhan.BusinessLogic
{
    public interface IBookingBusiness
    {
        List<ZaKhan.Model.BookingModel> GetAllBookings();
        void Insert(BookingModel bookingModel);
        void Update(BookingModel bookingModel);
        void Delete(BookingModel bookingModel);
        BookingModel GetById(int id);
        BookingModel GetByUser(string user);
        void Dispose(bool disposing);
    }
}
