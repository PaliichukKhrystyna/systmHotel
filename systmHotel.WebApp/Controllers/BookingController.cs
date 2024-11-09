using Microsoft.AspNetCore.Mvc;
using systmHotel.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace systmHotel.WebApp.Controllers
{
    public class BookingController : Controller
    {
        private static List<Booking> bookings = new List<Booking>();

        public IActionResult Index()
        {
            // Повертає список бронювань
            return View(bookings);
        }

        public IActionResult AddBooking()
        {
            // Повертає форму для додавання нового бронювання
            return View();
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            // Додає нове бронювання
            booking.BookingID = bookings.Count > 0 ? bookings.Max(b => b.BookingID) + 1 : 1;
            bookings.Add(booking);
            return RedirectToAction("Index");
        }

        public IActionResult EditBooking(int id)
        {
            // Знаходить бронювання за ID та повертає форму для редагування
            var booking = bookings.FirstOrDefault(b => b.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        [HttpPost]
        public IActionResult EditBooking(Booking booking)
        {
            // Оновлює дані існуючого бронювання
            var existingBooking = bookings.FirstOrDefault(b => b.BookingID == booking.BookingID);
            if (existingBooking == null)
            {
                return NotFound();
            }
            existingBooking.ClientID = booking.ClientID;
            existingBooking.RoomID = booking.RoomID;
            existingBooking.BookingDate = booking.BookingDate;
            existingBooking.CheckInDate = booking.CheckInDate;
            existingBooking.CheckOutDate = booking.CheckOutDate;
            existingBooking.TotalAmount = booking.TotalAmount;

            return RedirectToAction("Index");
        }

        public IActionResult DeleteBooking(int id)
        {
            // Повертає форму для підтвердження видалення
            var booking = bookings.FirstOrDefault(b => b.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            // Видаляє бронювання
            var booking = bookings.FirstOrDefault(b => b.BookingID == id);
            if (booking != null)
            {
                bookings.Remove(booking);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            // Повертає деталі бронювання за ID
            var booking = bookings.FirstOrDefault(b => b.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }
    }
}
