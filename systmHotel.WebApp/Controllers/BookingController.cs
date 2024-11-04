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
            booking.Add(new Room() { RoomID=2,PricePerNight=350});
            booking.Add(new Room() { RoomID=3,PricePerNight=400});
            booking.Add(new Room() { RoomID=4,PricePerNight=450});
            booking.Add(new Room() { RoomID=5,PricePerNight=500});
            booking.Add(new Room() { RoomID=6,PricePerNight=550});

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
