using Andromeda.Application.Employee.Commands;
using Andromeda.Application.Employee.Queries;
using Andromeda.Application.Interfaces;
using Andromeda.Application.Login.Queries;
using Andromeda.Application.Record.Queries;
using Andromeda.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andromeda.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMediator mediator;
        private readonly ISignInManager signInManager;
        public LoginController(IMediator mediator, ISignInManager signInManager)
        {
            this.mediator = mediator;
            this.signInManager = signInManager;             
        }


        public async Task<IActionResult> VerifyLogin(LoginDetailsVM loginDetails)
        {
            await signInManager.PasswordSignInAsync(loginDetails.Username, loginDetails.Password, false, false);

            if (Startup.UserDashboard != null)
            {              
                var _timeInCheck = await mediator.Send(new TimeInCheckerQuery { EmployeeID = Startup.UserDashboard.ID });
                var _timeOutCheck = await mediator.Send(new TimeOutCheckerQuery { EmployeeID = Startup.UserDashboard.ID });

                if (_timeInCheck == true && _timeOutCheck == true)
                {
                    Startup.UserDashboard.LogType = LogType.None;
                }
                else if (_timeInCheck == false && _timeOutCheck == false)
                {
                    Startup.UserDashboard.LogType = LogType.TimeIn;
                }
                else if (_timeInCheck == true && _timeOutCheck == false)
                {
                    Startup.UserDashboard.LogType = LogType.TimeOut;
                }

                return Json(true);
            }

            else

            {
                return Json(false);
            }
            
        }

    }
}
