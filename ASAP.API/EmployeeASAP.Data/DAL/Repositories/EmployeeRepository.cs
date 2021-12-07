

using AMS.DAL.Persistance;
using EmployeeASAP.Data.DAL.IPersistance;
using EmployeeASAP.Data.DAL.IRepositories;
using EmployeeASAP.Data.Models;

namespace EmployeeASAP.Data.DAL.Repositories
{
   public class EmployeeRepository : RepositoryBase<Employee> , IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory)
         : base(dbFactory) { }
    }
}
