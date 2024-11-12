using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using systmHotel.DAL.Entities;

namespace systmHotel.BLL.Services
{
    public class ClientService
    {

        public ClientService()
        {
        }

        public Task<List<Client>> GetClientsAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddClientAsync(Client client)
        {
            throw new NotImplementedException("Користувач типу зареєстрований");
        }

        public Task UpdateClientAsync(Client client)
        {
            throw new NotSupportedException();
        }

        public Task DeleteClientAsync(Client client)
        {
            throw new NotSupportedException();
        }



    }
}
