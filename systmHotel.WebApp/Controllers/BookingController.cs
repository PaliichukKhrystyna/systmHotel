using Microsoft.AspNetCore.Mvc;
using systmHotel.DAL.Entities;

namespace systmHotel.WebApp.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            List<Room> booking = new List<Room>();
            booking.Add(new Room() { RoomID=1,PricePerNight=300});
            booking.Add(new Room() { RoomID=1,PricePerNight=300});
            booking.Add(new Room() { RoomID=1,PricePerNight=300});
            booking.Add(new Room() { RoomID=1,PricePerNight=300});
            booking.Add(new Room() { RoomID=1,PricePerNight=300});
            booking.Add(new Room() { RoomID=1,PricePerNight=300});

            return View(booking);
        }

        public IActionResult AddRoom()
        {
            return View();
        }
        //public IActionResult AddRoom(Room Room)
        //{
        //    return View();
        //}

    }
}
