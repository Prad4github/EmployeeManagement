using EmployeeManagement.DTO;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DTOModelConverter
{
    public class DTOModelClass : IDTOModel
    {
        public Manager GetDTOObject(Managers user)
        {
            Manager mgr = new Manager()
            {
                Alias = user.Alias,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ManagerName = user.ManagerName,
                Positon = user.Positon,
                ManagerId = user.ManagerId,
            };
            return mgr;
        }

        public Managers GetModelObject(Manager manager)
        {
            Managers managers = new Managers()
            {
                Alias = manager.Alias,
                Email = manager.Email,
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                ManagerName = manager.ManagerName,
                Positon = manager.Positon,
                ManagerId = Guid.NewGuid()
            };
            return managers;
        }

        public IEnumerable<Managers> GetManagersEntities(IEnumerable<Manager> managers)
        {
            List<Managers> lstManagers = new List<Managers>();
            foreach (var entity in managers)
            {
                lstManagers.Add(GetModelObject(entity));
            }
            return lstManagers;
        }

        public Clients GetModelObject(Client client)
        {
            Clients clientconverted = new Clients()
            {
                Alias = client.Alias,
                Email = client.Email,
                FirstName = client.FirstName,
                LastName = client.LastName,
                ClientName = client.ClientName,
                ManagerId = client.ManagerId,
                Level = client.Level,
                ClientId = Guid.NewGuid()
            };
            return clientconverted;
        }

        public Client GetDTOObject(Clients client)
        {
            Client clientconverted = new Client()
            {
                Alias = client.Alias,
                Email = client.Email,
                FirstName = client.FirstName,
                LastName = client.LastName,
                ClientName = client.ClientName,
                ManagerId = client.ManagerId,
                Level = client.Level,
                ClientId = client.ClientId
            };
            return clientconverted;
        }
    }
}
