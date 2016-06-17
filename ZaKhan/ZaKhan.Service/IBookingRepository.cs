using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;

namespace ZaKhan.Service
{
    public interface IBookingRepository : IDisposable
    {
        Booking GetById(Int32 id);
        List<Booking> GetAll();
        void Insert(Booking model);
        void Update(Booking model);
        void Delete(Booking model);
        IEnumerable<Booking> Find(Func<Booking, bool> predicate);
    }
}
