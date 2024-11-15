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

        // Відображає список бронювань
        public async Task<IActionResult> Index()
        {
            //var bookings = await _service.GetBookingsAsync();
            //return View(bookings);
            return View(_service.GetBookingsAsync().Result);
        }

        // Відображає форму для додавання нового бронювання
        public IActionResult AddBooking()
        {
            return View();
        }

        // Додає нове бронювання
        [HttpPost]
        public async Task<IActionResult> AddBooking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                await _service.AddBookingAsync(booking);
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // Відображає форму для редагування існуючого бронювання    GetBookingByIdAsync
        public async Task<IActionResult> EditBooking(int id)
        {
            var booking = await _service.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // Оновлює існуюче бронювання
        [HttpPost]
        public async Task<IActionResult> EditBooking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateBookingAsync(booking);
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // Видаляє бронювання
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _service.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // Підтвердження видалення бронювання
        [HttpPost, ActionName("DeleteBooking")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteBookingAsync(id);
            return RedirectToAction("Index");
        }

        // Відображає деталі бронювання
        public async Task<IActionResult> Details(int id)
        {
            var booking = await _service.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }
    }
}
