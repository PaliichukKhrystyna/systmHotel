using Microsoft.AspNetCore.Mvc;
using systmHotel.DAL.Entities;
using System.Threading.Tasks;
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

        public async Task<IActionResult> Index()
        {
            var bookings = await _service.GetBookingsAsync();
            return View(bookings);
        }

        public IActionResult AddBooking()
        {
            return View(new Booking { BookingDate = DateTime.UtcNow });
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(Booking booking)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.AddBookingAsync(booking);
                    TempData["SuccessMessage"] = "Booking successfully added.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Failed to add booking.");
            }
            return View(booking);
        }

        public async Task<IActionResult> EditBooking(int id)
        {
            var booking = await _service.GetBookingByIdAsync(id);
            if (booking == null)
            {
                TempData["ErrorMessage"] = "Booking not found.";
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> EditBooking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateBookingAsync(booking);
                TempData["SuccessMessage"] = "Booking successfully updated.";
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _service.GetBookingByIdAsync(id);
            if (booking == null)
            {
                TempData["ErrorMessage"] = "Booking not found.";
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        [HttpPost, ActionName("DeleteBooking")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _service.DeleteBookingAsync(id);
                TempData["SuccessMessage"] = "Booking successfully deleted.";
            }
            catch
            {
                TempData["ErrorMessage"] = "Failed to delete booking.";
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var booking = await _service.GetBookingByIdAsync(id);
            if (booking == null)
            {
                TempData["ErrorMessage"] = "Booking not found.";
                return RedirectToAction("Index");
            }
            return View(booking);
        }
    }
}

