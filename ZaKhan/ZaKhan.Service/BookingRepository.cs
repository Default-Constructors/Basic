using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;

namespace ZaKhan.Service
{
    public class BookingRepository : IBookingRepository
    {
        private ApplicationDbContext _datacontext = null;
        private readonly IRepository<Booking> _bookingRepository;

        public BookingRepository()
        {
            _datacontext = new ApplicationDbContext();
            _bookingRepository = new RepositoryService<Booking>(_datacontext);

        }

        public Booking GetById(int id)
        {
            return _bookingRepository.GetById(id);
        }

        public List<Booking> GetAll()
        {
            return _bookingRepository.GetAll().ToList();
        }

        public void Insert(Booking model)
        {
            _bookingRepository.Insert(model);
        }

        public void Update(Booking model)
        {
            _bookingRepository.Update(model);
        }

        public void Delete(Booking model)
        {
            _bookingRepository.Delete(model);
        }

        public IEnumerable<Booking> Find(Func<Booking, bool> predicate)
        {
            return _bookingRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
