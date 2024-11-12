using Microsoft.AspNetCore.Mvc;
using systmHotel.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using systmHotel.BLL.Services;

namespace systmHotel.WebApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingService _service;

        public BookingController(BookingService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            // Повертає список бронювань
            return View(_service.GetBookingsAsync().Result);
        }

        public IActionResult AddBooking()
        {
            // Повертає форму для додавання нового бронювання
            return View();
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            _service.AddBookingAsync(booking);
            return RedirectToAction("Index","Client");
        }

        // public IActionResult EditBooking(int id)
        // {
        //     // Знаходить бронювання за ID та повертає форму для редагування
        //     var booking = bookings.FirstOrDefault(b => b.BookingID == id);
        //     if (booking == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(booking);
        // }
        //
        // [HttpPost]
        // public IActionResult EditBooking(Booking booking)
        // {
        //     // Оновлює дані існуючого бронювання
        //     var existingBooking = bookings.FirstOrDefault(b => b.BookingID == booking.BookingID);
        //     if (existingBooking == null)
        //     {
        //         return NotFound();
        //     }
        //     existingBooking.ClientID = booking.ClientID;
        //     existingBooking.RoomID = booking.RoomID;
        //     existingBooking.BookingDate = booking.BookingDate;
        //     existingBooking.StartDate = booking.StartDate;
        //     existingBooking.EndDate = booking.EndDate;
        //     existingBooking.TotalAmount = booking.TotalAmount;
        //
        //     return RedirectToAction("Index");
        // }
        //
        // public IActionResult DeleteBooking(int id)
        // {
        //     // Повертає форму для підтвердження видалення
        //     var booking = bookings.FirstOrDefault(b => b.BookingID == id);
        //     if (booking == null)
        //     {
        //         return NotFound();
        //     }
        //     return View("Index");
        // }
        //
        // [HttpPost]
        // public IActionResult DeleteConfirmed(int id)
        // {
        //     // Видаляє бронювання
        //     var booking = bookings.FirstOrDefault(b => b.BookingID == id);
        //     if (booking != null)
        //     {
        //         bookings.Remove(booking);
        //     }
        //     return RedirectToAction("Index");
        // }
        //
        // public IActionResult Details(int id)
        // {
        //     // Повертає деталі бронювання за ID
        //     var booking = bookings.FirstOrDefault(b => b.BookingID == id);
        //     if (booking == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(booking);
        // }
    }
}
