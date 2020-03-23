using Andromeda.Application.Account.Queries;
using Andromeda.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
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
            private readonly IPasswordHasher passwordHasher;

            public ChangeUsernameCommandHandler(IAndromedaDbContext dbContext, IPasswordHasher password)
            {
                this.dbContext = dbContext;
                this.passwordHasher = password;
            }

            public async Task<bool> Handle(ChangeUsernameCommand request, CancellationToken cancellationToken)
            {
                var _user = dbContext.UserLogins.Where(a => a.ID == request.UserID).SingleOrDefault();


                if (passwordHasher.IsPasswordVerified(_user.Salt, _user.Password, request.Data.Password))
                {
                    _user.Username = request.Data.NewUsername;
                    await dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Password Incorrect");
                }

                return true;
            }
        }
    }
}
