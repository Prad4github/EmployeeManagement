using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class Clients
    {
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? ManagerId { get; set; }
        public int Level { get; set; }

        public virtual Managers Manager { get; set; }
    }
}
