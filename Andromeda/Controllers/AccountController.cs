using Andromeda.Application.Account.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andromeda.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator mediator;
        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> ChangeUsername(string newUsername)
        {
            var _retVal = await mediator.Send(new ChangeUsernameCommand { UserID = Startup.UserDashboard.ID , NewUsername = newUsername});

            return Json(true);
        }
      
    }
}
