using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using systmHotel.DAL.Context;
using systmHotel.DAL.Entities;
using systmHotel.DAL.IRepositoryy;

namespace systmHotel.DAL.Repositoryy
{
    public class AdminRepository : IAdminRepository
    {
        private readonly systHotelContext _context;

        public AdminRepository(systHotelContext context)
        {
            _context = context;
        }

        public async Task<Admin?> GetAdminByUsernameAndPasswordAsync(string username, string password)
        {
            return await _context.Admin
                .FirstOrDefaultAsync(a => a.Name == username && a.Password == password);
        }
    }
}
//FirstOrDefaultAsync