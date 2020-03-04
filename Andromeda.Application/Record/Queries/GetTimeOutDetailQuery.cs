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
    public class GetTimeOutDetailQuery : IRequest<List<DateTime?>>
    {
        public int EmployeeID { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public class GetTimeOutDetailQueryHandler : IRequestHandler<GetTimeOutDetailQuery, List<DateTime?>>
        {
            private readonly IAndromedaDbContext dbContext;
            public GetTimeOutDetailQueryHandler(IAndromedaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<DateTime?>> Handle(GetTimeOutDetailQuery request, CancellationToken cancellationToken)
            {
                var _listOfTimeOut = new List<DateTime?>();


                var _listOfTimeOutRecords = dbContext.TimeRecords
                    .Where(a => a.EmployeeDetailsID == request.EmployeeID
                            && a.RecordType == RecordType.TimeOut
                            && a.Time >= request.From.Date && a.Time <= request.To.Date).ToList();

                foreach (var item in _listOfTimeOutRecords)
                {
                    _listOfTimeOut.Add(item.Time);

                }

                return _listOfTimeOut;

            }
        }
    }
}
