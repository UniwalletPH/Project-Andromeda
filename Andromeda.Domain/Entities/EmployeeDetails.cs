using Andromeda.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Andromeda.Domain.Entities
{
    [Table("tbl_EmployeeDetails")]
    public class EmployeeDetails
    {
        [Key]
        public int ID { get; set; }
   
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }

        public string Address { get; set; }     
        
        [InverseProperty("EmployeeDetails")]
        public UserLogins UserLogins { get; set; }

        public UserRole Role { get; set; }
    
        public ICollection<TimeRecords> TimeRecords { get; set; }
    }
}
