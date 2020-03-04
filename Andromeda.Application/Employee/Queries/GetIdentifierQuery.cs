using Andromeda.Application.Interfaces;
using Andromeda.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Andromeda.Application.Employee.Queries
{
    public class GetIdentifierQuery : IRequest<int>
    {
        public EmployeeDetails Employee { get; set; }
        public class GetIdentifierQueryHandler : IRequestHandler<GetIdentifierQuery, int>
        {
            private readonly IAndromedaDbContext dbContext;
            public GetIdentifierQueryHandler(IAndromedaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(GetIdentifierQuery request, CancellationToken cancellationToken)
            {
                var _employee = dbContext.EmployeeDetails
                    .Where(a => a.Email == request.Employee.Email 
                    && a.Lastname == request.Employee.Lastname
                    && a.Number == request.Employee.Number)
                    .SingleOrDefault();

                return _employee.ID;
            }
        }
    }
}
