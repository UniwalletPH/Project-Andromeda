using Andromeda.Application.Employee.Queries;
using Andromeda.Application.Interfaces;
using Andromeda.Application.Login.Queries;
using Andromeda.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Andromeda.Application.Employee.Commands
{
    public class AddEmployeeCommand : IRequest<LoginDetailsVM>
    {
        public EmployeeDetailVM Employee { get; set; }

        public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, LoginDetailsVM>
        {
            private readonly IAndromedaDbContext dbContext;
            private readonly IMediator mediator;
            private readonly IPasswordHasher passwordHasher;
            public AddEmployeeCommandHandler(IAndromedaDbContext dbContext, IMediator mediator, IPasswordHasher passwordHasher)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
                this.passwordHasher = passwordHasher;
            }

            public async Task<LoginDetailsVM> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
            {
                var _employeeDetails = new EmployeeDetails
                {
                    Firstname = request.Employee.Firstname,
                    Lastname = request.Employee.Lastname,
                    Address = request.Employee.Address,
                    Email = request.Employee.Email,
                    Number = request.Employee.Number,                 
                    Role = request.Employee.Role
                   
                };

                dbContext.EmployeeDetails.Add(_employeeDetails);          
                await dbContext.SaveChangesAsync();

                var salt = passwordHasher.GenerateSalt();

                var _userLoginDetails = new UserLogins
                {
                    ID = await mediator.Send(new GetIdentifierQuery { Employee = _employeeDetails }),
                    Username = _employeeDetails.Email,
                    Salt = salt,
                    Password = passwordHasher.HashPassword(salt,"uniwallet")
                };

                dbContext.UserLogins.Add(_userLoginDetails);
                await dbContext.SaveChangesAsync();


                var _loginDetails = new LoginDetailsVM
                { 
                Username = _employeeDetails.Email,
                Password = "uniwallet"
                };

                return _loginDetails;
               
            }
        }
    }
}
