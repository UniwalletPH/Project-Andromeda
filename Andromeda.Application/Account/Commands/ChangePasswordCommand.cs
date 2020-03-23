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
    public class ChangePasswordCommand : IRequest<bool>
    {
        public int UserID { get; set; }

        public ChangePasswordVM Data { get; set; }

        public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
        {
            private readonly IAndromedaDbContext dbContext;
            private readonly IPasswordHasher passwordHasher;
            public ChangePasswordCommandHandler(IAndromedaDbContext dbContext, IPasswordHasher password)
            {
                this.dbContext = dbContext;
                this.passwordHasher = password;
            }

            public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            {
                var _user = dbContext.UserLogins.Where(a => a.ID == request.UserID).SingleOrDefault();

                if (request.Data.NewPassword == request.Data.ConfirmPassword)
                {
                    if (passwordHasher.IsPasswordVerified(_user.Salt, _user.Password, request.Data.CurrentPassword))
                    {                      
                        _user.Password = passwordHasher.HashPassword(_user.Salt,request.Data.NewPassword);
                        await dbContext.SaveChangesAsync();
                    }
                    else
                    {
                     throw new Exception("Old Password is incorrect"); 
                    }
                }
                else
                {
                    throw new Exception("New Password did not match");
                }

                return true;
            }
        }
    }
}
