using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using systmHotel.DAL.Entities;
using systmHotel.DAL.IRepositoryy;

namespace systmHotel.BLL.Services
{
    public class AdminService // IAdminRepository _adminRepository
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<Admin?> AuthenticateAsync(string username, string password)
        {
            return await _adminRepository.GetAdminByUsernameAndPasswordAsync(username, password);
        }
    }
}
