using Andromeda.Application.Account.Queries;
using Andromeda.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Andromeda.Application.Account.Commands
{
    public class ChangeUsernameCommand : IRequest<bool>
    {
        public int UserID { get; set; }

        public ChangeUsernameVM Data { get; set; }

        public class ChangeUsernameCommandHandler : IRequestHandler<ChangeUsernameCommand, bool>
        {
            
            private readonly IAndromedaDbContext dbContext;
            public ChangeUsernameCommandHandler(IAndromedaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(ChangeUsernameCommand request, CancellationToken cancellationToken)
            {
                return true;
            }
        }
    }
}
