﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systmHotel.DAL.Entities
{
    public class Service
    {
        public int ServiceID { get; set; }
        public int BookingId { get; set; }
        public Booking? Booking { get; set; }
        public string? ServiceName { get; set; }
        public decimal Price { get; set; }
    }
}
