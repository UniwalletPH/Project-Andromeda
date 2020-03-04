using Andromeda.Application.Interfaces;
using Andromeda.Domain.Entities;
using Andromeda.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Andromeda.Application.Record.Commands
{
    public class SaveTimeOutCommand : IRequest<bool>
    {
        public int EmployeeID { get; set; }

        public class SaveTimeOutCommandHandler : IRequestHandler<SaveTimeOutCommand, bool>
        {
            private readonly IAndromedaDbContext dbContext;
            public SaveTimeOutCommandHandler(IAndromedaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(SaveTimeOutCommand request, CancellationToken cancellationToken)
            {
                var _timeOut = new TimeRecords
                {
                    EmployeeDetailsID = request.EmployeeID,
                    RecordType = RecordType.TimeOut,
                    Time = DateTime.Now
                };

                dbContext.TimeRecords.Add(_timeOut);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
