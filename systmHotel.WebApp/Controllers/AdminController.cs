using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using systmHotel.BLL.Services;
using systmHotel.DAL.Entities;

namespace systmHotel.WebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminService _adminService;
        private readonly ClientService _clientService;
        private readonly BookingService _bookingService;

        public AdminController(AdminService adminService, ClientService clientService, BookingService bookingService)
        {
            _adminService = adminService;
            _clientService = clientService;
            _bookingService = bookingService;
        }

        // GET: Вхід адміністратора
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Вхід адміністратора
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var admin = await _adminService.AuthenticateAsync(username, password);
            if (admin == null)
            {
                ViewBag.Error = "Invalid username or password.";
                return View();
            }

            return RedirectToAction("Dashboard", new { adminId = admin.AdminID });
        }

        // GET: Панель адміністратора
        public IActionResult Dashboard(int adminId)
        {
            ViewBag.AdminID = adminId;
            return View();
        }

        // GET: Управління клієнтами
        [HttpGet]
        public async Task<IActionResult> ManageClients(int adminId)
        {
            var clients = await _clientService.GetAllClientsAsync();
            ViewBag.AdminID = adminId;
            return View(clients);
        }

        // POST: Редагування клієнта
        [HttpPost]
        public async Task<IActionResult> EditClient(Client client, int adminId)
        {
            if (ModelState.IsValid)
            {
                await _clientService.UpdateClientAsync(client);
                return RedirectToAction("ManageClients", new { adminId });
            }

            var clients = await _clientService.GetAllClientsAsync();
            ViewBag.AdminID = adminId;
            ViewBag.EditClient = client;
            return View("ManageClients", clients);
        }

        // GET: Видалення клієнта
        public async Task<IActionResult> DeleteClient(int adminId, int clientId)
        {
            await _clientService.DeleteClientAsync(clientId);
            return RedirectToAction("ManageClients", new { adminId });
        }

        // GET: Управління бронюваннями
        [HttpGet]
        public async Task<IActionResult> ManageBookings(int adminId)
        {
            var bookings = await _bookingService.GetBookingsAsync();
            ViewBag.AdminID = adminId;
            return View(bookings);
        }

        // POST: Редагування бронювання
        [HttpPost]
        public async Task<IActionResult> EditBooking(Booking booking, int adminId)
        {
            if (ModelState.IsValid)
            {
                await _bookingService.UpdateBookingAsync(booking);
                return RedirectToAction("ManageBookings", new { adminId });
            }

            var bookings = await _bookingService.GetBookingsAsync();
            ViewBag.AdminID = adminId;
            ViewBag.EditBooking = booking;
            return View("ManageBookings", bookings);
        }

        // GET: Видалення бронювання
        public async Task<IActionResult> DeleteBooking(int adminId, int bookingId)
        {
            await _bookingService.DeleteBookingAsync(bookingId);
            return RedirectToAction("ManageBookings", new { adminId });
        }
    }
}
