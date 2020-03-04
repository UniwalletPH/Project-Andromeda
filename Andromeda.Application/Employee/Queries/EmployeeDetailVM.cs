using Andromeda.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromeda.Application.Employee.Queries
{
    public class EmployeeDetailVM
    {
        public int ID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }
      
        public UserRole Role { get; set; }    
     
    }
}
