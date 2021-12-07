using EmployeeASAP.Data.Models;
using System;


namespace EmployeeASAP.Data.DAL.IPersistance
{
    public interface IDbFactory : IDisposable
    {
        EmployeeASAPContext Init();
    }
}
