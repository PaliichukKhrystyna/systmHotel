using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systmHotel.DAL.Entities
{
    public class Admin
    {
        public int AdminID { get; set; } // Унікальний ідентифікатор
        public string? Name { get; set; } // Логін
        public string? Email { get; set; } // Електронна пошта
        public string? Password { get; set; } // Пароль
    }
}
