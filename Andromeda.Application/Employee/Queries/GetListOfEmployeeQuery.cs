using Andromeda.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Andromeda.Application.Employee.Queries
{
    public class GetListOfEmployeeQuery : IRequest<List<EmployeeDetailVM>>
    {
        public class GetListOfEmployeeQueryHandler : IRequestHandler<GetListOfEmployeeQuery, List<EmployeeDetailVM>>
        {
            private readonly IAndromedaDbContext dbContext;
            public GetListOfEmployeeQueryHandler(IAndromedaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EmployeeDetailVM>> Handle(GetListOfEmployeeQuery request, CancellationToken cancellationToken)
            {
                var _listOFEmployee = new List<EmployeeDetailVM>();

                var _employees =  await dbContext.EmployeeDetails.ToListAsync();

                foreach (var item in _employees)
                {
                    var x = new EmployeeDetailVM
                    { 
                        ID = item.ID,
                        Firstname = item.Firstname,
                        Lastname = item.Lastname,
                        Address = item.Address,
                        Email = item.Email,
                        Number = item.Number,
                        Role = item.Role
                        
                    };

                    _listOFEmployee.Add(x);

                }

                return _listOFEmployee;

            }
        }
    }
}
