using Andromeda.Application.Employee.Queries;
using Andromeda.Application.Interfaces;
using Andromeda.Application.Login.Queries;
using Andromeda.Application.Record.Queries;
using Andromeda.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Andromeda.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMediator mediator;
        private readonly ISignInManager signInManager;
        private readonly IHttpContextAccessor context;
     
        public LoginController(IMediator mediator, ISignInManager signInManager, IHttpContextAccessor context)
        {
            this.mediator = mediator;
            this.signInManager = signInManager;
            this.context = context;
            
        }


        public async Task<IActionResult> VerifyLogin(LoginDetailsVM loginDetails)
        {
            await signInManager.PasswordSignInAsync(loginDetails.Username, loginDetails.Password);

            return Json(true);
            
        }

    }
}
