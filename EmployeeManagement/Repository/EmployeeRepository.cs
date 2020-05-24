using EmployeeManagement.DTO;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly ApiContext _context;
        public EmployeeRepository(ApiContext context)
        {
            _context = context;
        }
        public  void  Add(Manager user)
        {
            _context.Add(GetManagers(user));
            _context.SaveChanges();
        }

        public void Delete(Manager user)
        {
            var managers = GetManagers(user);
            _context.Remove(managers);
            _context.SaveChanges();
        }

        public IEnumerable<Manager> GetAllManagers()
        {
            var managers = _context.Managers.ToList();
            List<Manager> lstmanager = new List<Manager>();
            foreach (var manager in managers)
            {
                lstmanager.Add(GetManager(manager));
            }
            return lstmanager;
        }

        public Manager Get(Guid id)
        {
            var managers = _context.Managers.FirstOrDefault(x => x.ManagerId == id);
            return GetManager(managers);
        }

        private Manager GetManager(Managers managers)
        {
            Manager manager = new Manager() {
                Alias = managers.Alias,
                Email = managers.Email,
                FirstName = managers.FirstName,
                LastName = managers.LastName,
                ManagerName = managers.ManagerName,
                Positon = managers.Positon,
                ManagerId = managers.ManagerId,
            };
            return manager;
        }

        private Managers GetManagers(Manager manager)
        {
            Managers managers = new Managers()
            {   
                Alias = manager.Alias,
                Email = manager.Email,
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                ManagerName = manager.ManagerName,
                Positon = manager.Positon
            };
            return managers;
        }

        public void Update(Guid id)
        {
            var managers = _context.Managers.FirstOrDefault(x => x.ManagerId == id);
            
            _context.SaveChanges();
        }
    }
}
