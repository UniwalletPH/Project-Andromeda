using Andromeda.Application.Account.Queries;
using Andromeda.Application.Employee.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andromeda.Models
{
    public class AccountVM
    {
        public EmployeeDetailVM User { get; set; }

        public ChangePasswordVM ChangePassword { get; set; }

        public ChangeUsernameVM ChangeUsername { get; set; }

    }
}
