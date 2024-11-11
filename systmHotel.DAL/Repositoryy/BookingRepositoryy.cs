using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using systmHotel.DAL.Context;
using systmHotel.DAL.Entities;
using systmHotel.DAL.IRepository;



namespace systmHotel.DAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly systHotelContext _context;

        public BookingRepository(systHotelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings.ToListAsync();
        }
      
        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings.FirstOrDefaultAsync(b => b.BookingID == id);
        }

        public async Task AddBookingAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            var existingBooking = await _context.Bookings.FirstOrDefaultAsync(b => b.BookingID == booking.BookingID);
            if (existingBooking != null)
            {
                existingBooking.ClientID = booking.ClientID;
                existingBooking.RoomID = booking.RoomID;
                existingBooking.BookingDate = booking.BookingDate;
                existingBooking.StartDate = booking.StartDate;
                existingBooking.EndDate = booking.EndDate;
                existingBooking.TotalAmount = booking.TotalAmount;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.BookingID == id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
    }
}