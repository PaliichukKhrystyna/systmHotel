using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
    public class ServiceRepository : IServiceRepository
    {
        private readonly systHotelContext _context;

        public ServiceRepository(systHotelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _context.Services.FirstOrDefaultAsync(s => s.ServiceID == id);
        }

        public async Task AddServiceAsync(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceAsync(Service service)
        {
            var existingService = await _context.Services.FirstOrDefaultAsync(s => s.ServiceID == service.ServiceID);
            if (existingService != null)
            {
                existingService.ServiceName = service.ServiceName;
                existingService.ServiceID = service.ServiceID;
                existingService.Price = service.Price;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.ServiceID == id);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
        }
    }
}
