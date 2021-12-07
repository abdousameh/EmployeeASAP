

using EmployeeASAP.Data.DAL.IPersistance;
using EmployeeASAP.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeASAP.Data.DAL.Persistance
{
   public  class DbFactory : Disposable, IDbFactory
    {
		DbContextOptions<EmployeeASAPContext> _options;
		public DbFactory(DbContextOptions<EmployeeASAPContext> options)
		{
			_options = options;
		}
		EmployeeASAPContext dbContext;

		public EmployeeASAPContext Init()
		{
			return dbContext ?? (dbContext = new EmployeeASAPContext(_options));
		}

		protected override void DisposeCore()
		{
			if (dbContext != null)
				dbContext.Dispose();
		}
	
	
	//EmployeeASAPContext dbContext;
 //       public EmployeeASAPContext Init()
 //       {
 //           return dbContext ?? (dbContext = new EmployeeASAPContext());
 //       }

 //       protected override void DisposeCore()
 //       {
 //           if (dbContext != null)
 //               dbContext.Dispose();
 //       }

        
    }
}
