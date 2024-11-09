using Microsoft.AspNetCore.Mvc;
using systmHotel.DAL.Entities;

namespace systmHotel.WebApp.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            List<Service> services = new List<Service>
            {
                new Service { ServiceID = 1, ServiceName = "Спа", Price = 150 },
                new Service { ServiceID = 2, ServiceName = "Кімнатіні послуги", Price = 50 }
                new Service { ServiceID = 3, ServiceName = "Сніданок у номер", Price = 100 }
                new Service { ServiceID = 4, ServiceName = "Вечерря у номер", Price = 100 }
                 new Service { ServiceID = 5, ServiceName = "Екскурсійне обслуговування", Price = 150 }
                 new Service { ServiceID = 6, ServiceName = "Прокат автомобілів", Price = 500 }
                 new Service { ServiceID = 6, ServiceName = "Прання і хімчистка одягу", Price = 200 }
            };

            return View(services);
        }

        public IActionResult AddService()
        {
            return View();
        }

        public IActionResult EditService(int id)
        { return View();
        }

        public IActionResult DeleteService(int id)
        {
          
            return View();
        }





    }
}
