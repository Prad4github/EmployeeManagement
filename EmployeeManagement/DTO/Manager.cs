using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DTO
{
    public class Manager
    {
        public Guid ManagerId { get; set; }
        [Required]
        [MaxLength(200)]
        public string ManagerName { get; set; }
        [MaxLength(1000)]
        public string Email { get; set; }
        [MaxLength(1000)]
        public string Alias { get; set; }
        [MaxLength(1000)]
        public string FirstName { get; set; }
        [MaxLength(1000)]
        public string LastName { get; set; }
        public int Positon { get; set; }
    }
}
