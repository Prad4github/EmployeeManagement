using EmployeeManagement.DTO;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DTOModelConverter
{
    public interface IDTOModel
    {
        Managers GetModelObject(Manager manager);
        Manager GetDTOObject(Managers user);

        Clients GetModelObject(Client client);
        Client GetDTOObject(Clients Clients);

        IEnumerable<Managers> GetManagersEntities(IEnumerable<Manager> managers);

    }
}
