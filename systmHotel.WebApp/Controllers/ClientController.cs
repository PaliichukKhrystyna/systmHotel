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
            return View();
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
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult History(int clientId)
        {
            return View();
        }
    }
}

