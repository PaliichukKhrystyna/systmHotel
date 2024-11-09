using Microsoft.AspNetCore.Mvc;
using systmHotel.DAL.Entities;

namespace systmHotel.WebApp.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            List<Room> rooms = new List<Room>
            {
                new Room { RoomID = 1, RoomNumber = "101", RoomType = "Для одного", PricePerNight = 200 },
                new Room { RoomID = 2, RoomNumber = "102", RoomType = "Для двох", PricePerNight = 300 }
                 new Room { RoomID = 3, RoomNumber = "103", RoomType = "Для сімї", PricePerNight = 400 }
            };

            return View(rooms);
        }

        public IActionResult AddRoom()
        {
            return View();
        }

        public IActionResult EditRoom(int id)
        {
           
            return View();
        }

        public IActionResult DeleteRoom(int id)
        {
           


            return View();
        }


    }
}
