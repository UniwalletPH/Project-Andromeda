using Andromeda.Application.Interfaces;
using Andromeda.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Andromeda.Application.Record.Queries
{
    public class TimeInCheckerQuery : IRequest<bool>
    {
        public int EmployeeID { get; set; }

        public class TimeInCheckerQueryHandler : IRequestHandler<TimeInCheckerQuery, bool>
        {
            private readonly IAndromedaDbContext dbContext;
            public TimeInCheckerQueryHandler(IAndromedaDbContext dbContext)
            {
                this.dbContext = dbContext;          
            }


            public async Task<bool> Handle(TimeInCheckerQuery request, CancellationToken cancellationToken)
            {
                var _timeInRecord = dbContext.TimeRecords
                    .Where(a => a.EmployeeDetailsID == request.EmployeeID
                             && a.RecordType == RecordType.TimeIn
                             && a.Time.Date == DateTime.Now.Date).SingleOrDefault();

                if (_timeInRecord != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
