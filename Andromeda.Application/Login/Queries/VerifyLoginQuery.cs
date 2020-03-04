using Andromeda.Application.Employee.Queries;
using Andromeda.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Andromeda.Domain.Entities;

namespace Andromeda.Application.Login.Queries
{
    public class VerifyLoginQuery : IRequest<UserLoginsVM>
    {
        public string Username { get; set; }   

        public class VerifyLoginQueryHandler : IRequestHandler<VerifyLoginQuery, UserLoginsVM>
        {
            private readonly IAndromedaDbContext dbContext;
            public VerifyLoginQueryHandler(IAndromedaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<UserLoginsVM> Handle(VerifyLoginQuery request, CancellationToken cancellationToken)
            {
                var _employee = dbContext.UserLogins                 
                    .Where(a => a.Username == request.Username)
                    .SingleOrDefault();

                if (_employee != null)
                {
                    var _employeeDetails = new UserLoginsVM
                    {
                        Username = _employee.Username,
                        Password = _employee.Password,
                        Salt = _employee.Salt
                        
                    };
                    return _employeeDetails;
                }
                return null;                  
            }
        }
    }
}
