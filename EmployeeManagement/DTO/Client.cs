using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DTO
{
    public class Client
    {
        public Guid ClientId { get; set; }
        [Required]
        [MaxLength(200)]
        public string ClientName { get; set; }
        [MaxLength(1000)]
        public string Alias { get; set; }
        [MaxLength(1000)]
        public string Email { get; set; }
        [MaxLength(1000)]
        public string FirstName { get; set; }
        [MaxLength(1000)]
        public string LastName { get; set; }
        public Guid? ManagerId { get; set; }
        public int Level { get; set; }
    }
}
