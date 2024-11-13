using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using systmHotel.DAL.Entities;
using systmHotel.DAL.IRepository;

namespace systmHotel.BLL.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _clientRepository.GetAllClientsAsync();
        }

        public async Task AddClientAsync(Client client)
        {
            await _clientRepository.AddClientAsync(client);
        }

        public async Task UpdateClientAsync(Client client)
        {
            await _clientRepository.UpdateClientAsync(client);
        }

        public async Task DeleteClientAsync(int clientId)
        {
          
            
                await _clientRepository.DeleteClientAsync(clientId);
            
        }
    }
}

