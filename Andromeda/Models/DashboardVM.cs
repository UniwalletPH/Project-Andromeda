using Andromeda.Application.Employee.Queries;
using Andromeda.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andromeda.Models
{
    public class DashboardVM
    {

        public int ID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }

        public UserRole Role { get; set; }

        public LogType LogType { get; set; }
    }
}
