using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class Managers
    {
        public Managers()
        {
            Clients = new HashSet<Clients>();
        }

        public Guid ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Positon { get; set; }

        public virtual ICollection<Clients> Clients { get; set; }
    }
}
