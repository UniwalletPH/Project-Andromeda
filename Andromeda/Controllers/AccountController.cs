using Andromeda.Application.Account.Commands;
using Andromeda.Application.Account.Queries;
using Andromeda.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andromeda.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IMediator mediator;
        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult ChangeUsername()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUsername(AccountVM data)
        {
            var _rV = await mediator.Send(new ChangeUsernameCommand { UserID = CurrentUser.ID , Data = data.ChangeUsername});


            return Json(true);
        }

        public IActionResult ChangePassword()
        {

             return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(AccountVM data)
        {
            var _rV = await mediator.Send(new ChangePasswordCommand { UserID = CurrentUser.ID, Data = data.ChangePassword });
            
            return Json(true);
        }
      
    }
}
