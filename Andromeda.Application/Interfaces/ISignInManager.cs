using Andromeda.Application.Login.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Andromeda.Application.Interfaces
{
    public interface ISignInManager
    {
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);

        Task<SignInResult> SignInAsync(string userName);

        Task SignOutAsync();
    }
}
