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
    public class SaveTimeInCommand : IRequest<bool>
    {
        public int EmployeeID { get; set; }

        public class SaveTimeInCommandHandler : IRequestHandler<SaveTimeInCommand, bool>
        {
            private readonly IAndromedaDbContext dbContext;
            public SaveTimeInCommandHandler( IAndromedaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(SaveTimeInCommand request, CancellationToken cancellationToken)
            {
                var _timeIn = new TimeRecords
                { 
                EmployeeDetailsID = request.EmployeeID,
                RecordType = RecordType.TimeIn,
                Time = DateTime.Now
                };

                dbContext.TimeRecords.Add(_timeIn);
                await dbContext.SaveChangesAsync();

                return true;
            }
        }
    }
}
