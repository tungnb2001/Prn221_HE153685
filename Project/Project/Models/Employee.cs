using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string CardId { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
