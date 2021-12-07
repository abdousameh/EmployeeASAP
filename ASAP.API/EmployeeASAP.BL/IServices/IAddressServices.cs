

using EmployeeASAP.BL.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeASAP.BL.IServices
{
    public interface IAddressServices
    {
        Task<List<AddressStatisticsDto>> GetAddressStatistics();

    }
}
