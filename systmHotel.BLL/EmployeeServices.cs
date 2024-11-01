using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using systmHotel.DAL.Entities;

namespace systmHotel.BLL
{
    internal class EmployeeServices
    { 
        public EmployeeServices() { }

        public Task<List<Employee>> GetEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddEmployeeAsync(Employee employee)
        {
            throw new NotSupportedException();
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            throw new NotSupportedException();
        }

        public Task DeleteEmployeeAsync(Employee employee)
        {
            throw new NotSupportedException();
        }



    }

}
