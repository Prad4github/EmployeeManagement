using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public interface IManagerRepository : IRepository<Managers>
    {
        IEnumerable<Managers> GetAllManagerWithClients();
        IEnumerable<Clients> GetAllClientsWithManager();

        IEnumerable<Clients> GetAllClientForManager(Guid managerId);
    }
}
