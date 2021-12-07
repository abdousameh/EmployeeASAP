

using EmployeeASAP.Data.DAL.IPersistance;
using EmployeeASAP.Data.Models;

namespace EmployeeASAP.Data.DAL.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly IDbFactory _dbFactory;
        private EmployeeASAPContext _dbcontext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
            this._dbcontext = this._dbcontext ?? (this._dbcontext = dbFactory.Init());

        }
        public EmployeeASAPContext DbContext
        {
            get { return _dbcontext ?? (_dbcontext = _dbFactory.Init()); }

        }

        public void SaveChanges()
        {
            this._dbcontext.SaveChanges();
        }
    }
}

