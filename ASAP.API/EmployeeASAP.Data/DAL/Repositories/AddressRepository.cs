

using AMS.DAL.Persistance;
using EmployeeASAP.Data.DAL.IPersistance;
using EmployeeASAP.Data.DAL.IRepositories;
using EmployeeASAP.Data.Models;

namespace EmployeeASAP.Data.DAL.Repositories
{
   public class AddressRepository :RepositoryBase<Address> , IAddressRepository
    {
        public AddressRepository(IDbFactory dbFactory)
        : base(dbFactory) { }
    }
}
