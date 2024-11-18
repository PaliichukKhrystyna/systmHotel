using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using systmHotel.BLL.Services;
using systmHotel.DAL.Entities;

namespace systmHotel.WebApp.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientService _clientService;
        private readonly BookingService _bookingService;


        public ClientController(ClientService clientService, BookingService bookingService)
        {
            _clientService = clientService;
            _bookingService = bookingService;
        }

        // Головна сторінка клієнта
        public async Task<IActionResult> Index(int clientId)
        {
            var client = await _clientService.GetClientByIdAsync(clientId);

            if (client == null)
            {
                return RedirectToAction("Login");
            }

            return View(client);
        }

        // GET: Реєстрація клієнта
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Реєстрація клієнта
        [HttpPost]
        public async Task<IActionResult> Register(Client client)
        {
            if (ModelState.IsValid)
            {
                await _clientService.AddClientAsync(client);
                return RedirectToAction("Login");
            }
            return View(client);
        }

        // GET: Логін клієнта
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Логін клієнта
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var client = (await _clientService.GetAllClientsAsync())
                .FirstOrDefault(c => c.Email == email && c.Password == password);

            if (client == null)
            {
                ViewBag.Error = "Невірний email або пароль.";
                return View();
            }

            // Перенаправлення на головну сторінку з ClientID як параметром
            return RedirectToAction("Index", new { clientId = client.ClientID });
        }

        // GET: Перегляд історії бронювань
        //public async Task<IActionResult> History(int clientId)
        //{
        //    var client = await _clientService.GetClientByIdAsync(clientId);

        //    if (client == null)
        //    {
        //        return RedirectToAction("Login");
        //    }

        //    return View(client.Bookings); // Передаємо бронювання у View
        //}
        public async Task<IActionResult> History(int clientId)
        {
            // Отримати клієнта разом із бронюваннями
            var client = await _clientService.GetClientByIdAsync(clientId);

            if (client == null)
            {
                // Якщо клієнта не знайдено, перенаправляємо на сторінку логіну
                return RedirectToAction("Login");
            }

            // Якщо бронювання не завантажено або null, ініціалізуємо пустий список
            client.Bookings ??= new List<Booking>();

            // Передаємо модель клієнта у View
            return View(client);
        }


        // GET: Оновлення профілю
        [HttpGet]
        public async Task<IActionResult> EditProfile(int clientId)
        {
            var client = await _clientService.GetClientByIdAsync(clientId);

            if (client == null)
            {
                return RedirectToAction("Login");
            }

            return View(client);
        }

        // POST: Оновлення профілю
        [HttpPost]
        public async Task<IActionResult> EditProfile(Client client)
        {
            if (ModelState.IsValid)
            {
                await _clientService.UpdateClientAsync(client);
                return RedirectToAction("Index", new { clientId = client.ClientID });
            }
            return View(client);
        }

        // Логаут клієнта
        public IActionResult Logout()
        {
            // Логаут тепер просто перенаправляє на сторінку входу
            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult CreateBooking(int clientId)
        {
            var booking = new Booking
            {
                ClientID = clientId,
                BookingDate = DateTime.UtcNow // Поточна дата
            };

            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                await _bookingService.AddBookingAsync(booking); // Реалізуйте відповідний метод у BookingService
                return RedirectToAction("Index", new { clientId = booking.ClientID });
            }

            return View(booking);
        }





    }
}



