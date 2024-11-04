using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using systmHotel.DAL.Entities;

namespace systmHotel.BLL.Services
{
    public class EmployeeServices
    {
        public EmployeeServices() { }

        private static List<Employee> employees = new List<Employee>();

        public Task<List<Employee>> GetEmployeesAsync()
        {
            return Task.FromResult(employees);
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
