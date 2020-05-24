using EmployeeManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IManagerRepository ManagersRepository { get; }
        IClientsRepository ClientRepository { get; }
        int Complete();
    }
}
