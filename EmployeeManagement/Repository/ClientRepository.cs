using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class ClientRepository : Repository<Clients>, IClientsRepository
    {
        public ClientRepository(ApiContext context) : base(context)
        {

        }
    }
}
