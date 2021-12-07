using EmployeeASAP.BL.Dtos;
using EmployeeASAP.BL.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeASAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressServices _addressServices;

        public AddressController(IAddressServices addressServices)
        {
            _addressServices = addressServices;
        }

  
        [HttpGet]
        [Route("getAddressStatistics")]
        public async Task<List<AddressStatisticsDto>> GetAddressStatistics()
        {
            return await _addressServices.GetAddressStatistics();
        }


    }
}
