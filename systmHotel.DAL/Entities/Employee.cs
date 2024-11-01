using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systmHotel.DAL.Entities
{
    internal class Employee
    {
        public int EmployeeId { get; set; }
        public decimal? Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string ContactNumber { get; set; }
    }
}
