using EmployeeManagement.DTO;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public interface IEmployee 
    {
        void Add(Manager user);
        void Update(Guid id);
        void Delete(Manager user);
        IEnumerable<Manager> GetAllManagers();
        Manager Get(Guid id);
    }
}
