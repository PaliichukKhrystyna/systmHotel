using Microsoft.AspNetCore.Mvc;
using systmHotel.BLL.Services;

namespace systmHotel.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeServices _employeeServices;

        public EmployeeController(EmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }
        public IActionResult Index()
        {
            var data = _employeeServices.GetEmployeesAsync().Result;
            return View(data);
        }
    }
}
