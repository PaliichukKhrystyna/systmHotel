using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using systmHotel.DAL.Entities;

namespace systmHotel.DAL.IRepositoryy
{
    public interface IAdminRepository
    {
        Task<Admin?> GetAdminByUsernameAndPasswordAsync(string username, string password);
    }
}
