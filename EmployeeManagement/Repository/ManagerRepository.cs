using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeManagement.Repository
{
    public class ManagerRepository : Repository<Managers>, IManagerRepository
    {
        private readonly ApiContext _apiContext;
        public ManagerRepository(ApiContext context) : base(context)
        {
            _apiContext = context;
        }

        public IEnumerable<Managers> GetAllManagerWithClients()
        {
            return _apiContext.Managers.Include(x=> x.Clients).ToList();
        }

        public IEnumerable<Clients> GetAllClientsWithManager()
        {
            return _apiContext.Clients.Include(x => x.Manager).ToList();
        }

        public IEnumerable<Clients> GetAllClientForManager(Guid managerId)
        {
            return _apiContext.Clients.Include(x => x.Manager).Where(x=>x.ManagerId == managerId);
        }
    }
}
