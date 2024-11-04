using Microsoft.AspNetCore.Mvc;
using systmHotel.DAL.Entities;

namespace systmHotel.WebApp.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            
        private static List<Client> clients = new List<Client>
        {
            new Client { ClientID = 1, Name = "Sysla", PhoneNumber = "123-456-7890", Email = "jgq3gq3w.com", Password = "password123" },
            new Client { ClientID = 2, Name = "Ivan", PhoneNumber = "987-654-3210", Email = "afsqq3fg.com", Password = "password123" }
        };

        // список бронювань 
        private static List<Booking> bookings = new List<Booking>
        {
            new Booking { BookingID = 1, ClientID = 1, RoomID = 101, CheckInDate = DateTime.Today, CheckOutDate = DateTime.Today.AddDays(3) },
            new Booking { BookingID = 2, ClientID = 2, RoomID = 102, CheckInDate = DateTime.Today, CheckOutDate = DateTime.Today.AddDays(5) }
        };

        //rеєстрації нового клієнта
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Client newClient)
        {
            if (ModelState.IsValid)
            {
                newClient.ClientID = clients.Count + 1; 
                clients.Add(newClient);
                return RedirectToAction("Login");
            }
            return View(newClient);
        }

        //входу в систему
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var client = clients.FirstOrDefault(c => c.Email == email && c.Password == password);
            if (client != null)
            {
                // Імітація авторизації (в реальному проекті слід використовувати ASP.NET Identity)
                HttpContext.Session.SetInt32("ClientId", client.ClientID);
                return RedirectToAction("Profile", new { clientId = client.ClientID });
            }
            ViewBag.ErrorMessage = "Invalid email or password.";
            return View();
        }

        // Метод для виходу з системи (лог-аут)
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("ClientId");
            return RedirectToAction("Login");
        }

        // Метод для відображення профілю клієнта
        public IActionResult Profile(int clientId)
        {
            var client = clients.FirstOrDefault(c => c.ClientID == clientId);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        //оновлення профілю клієнта
        public IActionResult EditProfile(int clientId)
        {
            var client = clients.FirstOrDefault(c => c.ClientID == clientId);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        [HttpPost]
        public IActionResult EditProfile(Client updatedClient)
        {
            if (ModelState.IsValid)
            {
                var client = clients.FirstOrDefault(c => c.ClientID == updatedClient.ClientID);
                if (client != null)
                {
                    client.Name = updatedClient.Name;
                    client.PhoneNumber = updatedClient.PhoneNumber;
                    client.Email = updatedClient.Email;
                }
                return RedirectToAction("Profile", new { clientId = updatedClient.ClientID });
            }
            return View(updatedClient);
        }

        // Метод для перегляду історії бронювань клієнта
        public IActionResult BookingHistory(int clientId)
        {
            var clientBookings = bookings.Where(b => b.ClientID == clientId).ToList();
            return View(clientBookings);
        }
    }
    }

