using EmployeeASAP.BL.Dtos;
using EmployeeASAP.BL.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeASAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpGet]
        [Route("search")]
        public async Task<List<EmployeeDto>> Get()
        {
            return await _employeeServices.GetEmployees();
        }


    }
}
