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
    public class ChangePasswordCommand : IRequest<bool>
    {
        public int UserID { get; set; }

        public ChangePasswordVM Data { get; set; }


        public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
        {
            private readonly IAndromedaDbContext dbContext;
            public ChangePasswordCommandHandler(IAndromedaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            {
                return true;
            }
        }
    }
}
