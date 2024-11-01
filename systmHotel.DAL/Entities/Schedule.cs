using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systmHotel.DAL.Entities
{
    internal class Schedule
    {
        public int ScheduleID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime ShiftDate { get; set; }
        public string ShiftTime { get; set; }
    }
}
