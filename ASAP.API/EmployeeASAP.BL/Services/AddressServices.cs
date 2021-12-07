
using EmployeeASAP.BL.Dtos;
using EmployeeASAP.BL.IServices;
using EmployeeASAP.Data.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeASAP.BL.Services
{
    public class AddressServices : IAddressServices
    {
        #region Fields
        private readonly IAddressRepository _addressRepository;
        #endregion
        public AddressServices(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }



        #region Methods     

        public async Task<List<AddressStatisticsDto>> GetAddressStatistics()
        {
            var query = await _addressRepository.TableNoTracking
                .Include(x => x.Employees)
                .Select(x =>
               new AddressStatisticsDto
               {
                   Id = x.Id,
                   Name = x.Name,
                   EmployeeCount = x.Employees.Count()
               })
                .ToListAsync();


            return query;
        }

        #endregion

    }
}
