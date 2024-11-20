using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using systmHotel.DAL.Entities;
using systmHotel.DAL.IRepository;

namespace systmHotel.BLL.Services
{
    public class BookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            return await _bookingRepository.GetAllBookingsAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByClientAsync(int ClientId)
        {
            return await _bookingRepository.GetBookingsByClienIdAsync(ClientId);
        }

        public async Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            return await _bookingRepository.GetBookingByIdAsync(bookingId);
        }

        public async Task AddBookingAsync(Booking booking)
        {
            await _bookingRepository.AddBookingAsync(booking);
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            await _bookingRepository.UpdateBookingAsync(booking);
        }

        public async Task DeleteBookingAsync(int bookingId)
        {
            await _bookingRepository.DeleteBookingAsync(bookingId);
        }







    }
}
