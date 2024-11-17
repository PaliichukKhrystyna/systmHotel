using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using systmHotel.BLL.Services;
using systmHotel.DAL.Entities;

namespace systmHotel.WebApp.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        // Головна сторінка клієнта
        public async Task<IActionResult> Index()
        {
            // Імітація отримання даних про поточного клієнта (замінити на реальну логіку отримання даних з авторизації)
            var clientId = 1; // ID авторизованого клієнта
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

            // Збереження даних клієнта у сесії (або іншому механізмі)
            HttpContext.Session.SetString("ClientId", client.ClientID.ToString());
            return RedirectToAction("Index");
        }

        // GET: Перегляд історії бронювань
        public async Task<IActionResult> History()
        {
            // Отримання ID клієнта з сесії
            var clientId = int.Parse(HttpContext.Session.GetString("ClientId"));
            var client = await _clientService.GetClientByIdAsync(clientId);

            if (client == null)
            {
                return RedirectToAction("Login");
            }

            return View(client.Bookings); // Передача бронювань у View
        }

        // GET: Оновлення профілю
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var clientId = int.Parse(HttpContext.Session.GetString("ClientId"));
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
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // Логаут клієнта
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Очищення сесії
            return RedirectToAction("Login");
        }
    }
}


