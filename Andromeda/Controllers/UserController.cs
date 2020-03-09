using Andromeda.Application.Employee.Commands;
using Andromeda.Application.Employee.Queries;
using Andromeda.Application.Interfaces;
using Andromeda.Application.Login.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andromeda.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMediator mediator;
        private readonly ISignInManager signInManager;

        public UserController(IMediator mediator, ISignInManager signInManager)
        {
            this.mediator = mediator;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            if (CurrentUser != null)
            {
                return Redirect("/Dashboard/Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDetailsVM loginDetails)
        {
            var x = await signInManager.PasswordSignInAsync(loginDetails.Username, loginDetails.Password);

            if (x.Succeeded)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }           
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddEmployee()
        {
            return View();
        }

        public async Task<IActionResult>  SaveEmployee(EmployeeDetailVM employee)
        {
            var _retVal = await mediator.Send(new AddEmployeeCommand { Employee = employee});

            return PartialView("~/Views/User/Partial/_UserLoginDetails.cshtml", _retVal);
        }
    }
}
