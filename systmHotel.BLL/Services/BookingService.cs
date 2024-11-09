using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using systmHotel.DAL.Entities;

namespace systmHotel.BLL.Services
{
    internal class BookingService
    {

        public BookingService()
        {
        }

        public Task<List<Booking>> GetBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddBookingAsync(Booking booking)
        {
            throw new NotSupportedException();
        }

        public Task UpdateBookingAsync(Booking booking)
        {
            throw new NotSupportedException();
        }

        public Task DeleteBookingAsync(Booking booking)
        {
            throw new NotSupportedException();
        }
    }
}
