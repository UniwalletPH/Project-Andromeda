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
    public class TimeOutCheckerQuery : IRequest<bool>
    {
        public int EmployeeID { get; set; }
        public class TimeOutCheckerQueryHandler : IRequestHandler<TimeOutCheckerQuery, bool>
        {
            private readonly IAndromedaDbContext dbContext;
            public TimeOutCheckerQueryHandler(IAndromedaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(TimeOutCheckerQuery request, CancellationToken cancellationToken)
            {
                var _timeOutRecord = dbContext.TimeRecords
                    .Where(a => a.EmployeeDetailsID == request.EmployeeID
                             && a.RecordType == RecordType.TimeOut
                             && a.Time.Date == DateTime.Now.Date).SingleOrDefault();

                if (_timeOutRecord != null)
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
