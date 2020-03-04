using Andromeda.Application.Interfaces;
using Andromeda.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Andromeda.Application.Employee.Queries
{
    public class GetAllEmployeeQuery : IRequest<List<EmployeeDetails>>
    {
        public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, List<EmployeeDetails>>
        {
            private readonly IAndromedaDbContext dbContext;
            public GetAllEmployeeQueryHandler( IAndromedaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<EmployeeDetails>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
            {
                var _employeeList = await dbContext.EmployeeDetails.ToListAsync();

                return _employeeList;
            }
        }
    }
}
