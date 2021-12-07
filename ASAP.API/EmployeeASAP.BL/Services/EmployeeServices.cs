
using EmployeeASAP.BL.Dtos;
using EmployeeASAP.BL.IServices;
using EmployeeASAP.Data.DAL.IPersistance;
using EmployeeASAP.Data.DAL.IRepositories;
using EmployeeASAP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeASAP.BL.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        #region Fields
        private readonly IEmployeeRepository _employeeRepository;
        #endregion
        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #region Methods     

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            var employee = await _employeeRepository.TableNoTracking
                .Include(x=>x.Address)
                .Select(x => new EmployeeDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address=x.Address.Name
                }).ToListAsync();
            return employee;
        }
        #endregion

    }
}
