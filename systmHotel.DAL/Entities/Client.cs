using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systmHotel.DAL.Entities
{
    public class Client
    {
        public int ClientID { get; set;}
        public string? Name { get; set;}
        public string? Surname { get; set;}
        public string? PhoneNumber {get; set; }
        public string? Email { get;set; }
        public string? PassportNumber { get; set; }
        public string? Password { get; set; }
        public string? PasswordSecret { get; set; }
        public bool Status { get; set; }
    }
}
