

using EmployeeASAP.BL.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeASAP.BL.IServices
{
    public interface IEmployeeServices
    {
        Task<List<EmployeeDto>> GetEmployees();

    }
}
