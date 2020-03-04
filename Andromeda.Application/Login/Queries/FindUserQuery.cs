using Andromeda.Application.Interfaces;
using Andromeda.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Andromeda.Application.Employee.Queries;

namespace Andromeda.Application.Login.Queries
{
    public class FindUserQuery : IRequest<EmployeeDetailVM>
    {
        public string Username { get; set; }
        public class FindUserQueryHandler : IRequestHandler<FindUserQuery, EmployeeDetailVM>
        {
            private readonly IAndromedaDbContext dbContext;
            public FindUserQueryHandler(IAndromedaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<EmployeeDetailVM> Handle(FindUserQuery request, CancellationToken cancellationToken)
            {
                var _user = dbContext.UserLogins
                    .Where(a => a.Username == request.Username)
                    .Include(a => a.EmployeeDetails).SingleOrDefault();

                var _userDetails = new EmployeeDetailVM
                { 
                ID = _user.ID,
                Firstname = _user.EmployeeDetails.Firstname,
                Lastname = _user.EmployeeDetails.Lastname,
                Address = _user.EmployeeDetails.Address,
                Email = _user.EmployeeDetails.Email,
                Number = _user.EmployeeDetails.Number,
                Role = _user.EmployeeDetails.Role
                };

                return _userDetails;
            }
        }
    }
}
