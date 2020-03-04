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

        public string NewUsername { get; set; }

        public class ChangeUsernameCommandHandler : IRequestHandler<ChangeUsernameCommand, bool>
        {
            
            private readonly IAndromedaDbContext dbContext;
            public ChangeUsernameCommandHandler(IAndromedaDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<bool> Handle(ChangeUsernameCommand request, CancellationToken cancellationToken)
            {
                var _user = dbContext.UserLogins.Find(request.UserID);

                if (_user != null)
                {
                    _user.Username = request.NewUsername;
                    await dbContext.SaveChangesAsync();

                    return true;
                }
                else
                {
                    throw new Exception("does not exist");
                }
            }
        }
    }
}
