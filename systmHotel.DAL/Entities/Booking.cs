using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systmHotel.DAL.Entities
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int ClientID { get; set; }
        public int RoomID { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalAmount { get; set; }

        public bool IsActive { get; set; }  

        public virtual Room? Room { get; set; }
        public virtual Client? Client { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
