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
    public class GetTimeInDetailQuery : IRequest<List<DateTime?>>
    {
        public int EmployeeID { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public class GetTimeInDetailsQueryHandler : IRequestHandler<GetTimeInDetailQuery, List<DateTime?>>
        {
            private readonly IAndromedaDbContext dbContext;
            public GetTimeInDetailsQueryHandler(IAndromedaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<DateTime?>> Handle(GetTimeInDetailQuery request, CancellationToken cancellationToken)
            {
                var _listOfTimeIn = new List<DateTime?>();
                
                
                var _listOfTimeInRecords = dbContext.TimeRecords
                    .Where(a => a.EmployeeDetailsID == request.EmployeeID
                            && a.RecordType == RecordType.TimeIn
                            && a.Time >= request.From.Date && a.Time <= request.To.Date).ToList();

                foreach (var item in _listOfTimeInRecords)
                {
                    _listOfTimeIn.Add(item.Time);

                }

                return _listOfTimeIn;

            }
        }
    }
}
