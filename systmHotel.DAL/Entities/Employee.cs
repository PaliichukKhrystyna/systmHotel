using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systmHotel.DAL.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public Position? Position { get; set; } //Створити клас Посада
        public DateTime HireDate { get; set; }
        public string? ContactNumber { get; set; }
    }

    public enum Position
    {
        Admin,
        Clener
    }
}
