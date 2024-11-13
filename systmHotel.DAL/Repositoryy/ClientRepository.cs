using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using systmHotel.DAL.Context;
using systmHotel.DAL.Entities;
using systmHotel.DAL.IRepository;

namespace systmHotel.DAL.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly systHotelContext _context;

        public ClientRepository(systHotelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.ClientID == id);
        }

        public async Task AddClientAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClientAsync(Client client)
        {
            var existingClient = await _context.Clients.FirstOrDefaultAsync(c => c.ClientID == client.ClientID);
            if (existingClient != null)
            {
                existingClient.Name = client.Name;
                existingClient.Surname = client.Surname;
                existingClient.Email = client.Email;
                existingClient.PhoneNumber = client.PhoneNumber;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteClientAsync(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.ClientID == id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }
    }
}
