using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var client = new Client() {Email="Loh@sdf.com", PhoneNumber="94857923", Bookings=new List<Booking>(){ new Booking() { BookingDate=DateTime.UtcNow} } };
            return View(client);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Client client)
        {
            _clientService.AddClientAsync(client);
            return Redirect("/Client/Index");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Client client)
        {
            return RedirectToAction("Index");
        }
        public IActionResult History(int clientId)
        {
            return View();
        }
    }
}

