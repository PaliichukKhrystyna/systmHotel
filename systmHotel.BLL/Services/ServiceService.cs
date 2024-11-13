using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using systmHotel.DAL.Entities;
using systmHotel.DAL.IRepository;

namespace systmHotel.BLL.Services
{
    public class ServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            return await _serviceRepository.GetAllServicesAsync();
        }

        public async Task AddServiceAsync(Service service)
        {
            await _serviceRepository.AddServiceAsync(service);
        }

        public async Task UpdateServiceAsync(Service service)
        {
            await _serviceRepository.UpdateServiceAsync(service);
        }

        public async Task DeleteServiceAsync(int serviceId)
        {
            
                await _serviceRepository.DeleteServiceAsync(serviceId);
        }
    }
}
