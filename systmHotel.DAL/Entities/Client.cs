using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systmHotel.DAL.Entities
{
    internal class Client
    {
        public int ClientID { get; set;}
        public string Name { get; set;}
        public string Surname { get; set;}
        public string PhoneNumber {get; set; }
        public string Email { get;set; }
        public string Address { get;set; }
        public string PassportDetails {get; set; }
    }
}
