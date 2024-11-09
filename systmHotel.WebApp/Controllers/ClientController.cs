using Microsoft.AspNetCore.Mvc;
using systmHotel.DAL.Entities;

namespace systmHotel.WebApp.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
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

