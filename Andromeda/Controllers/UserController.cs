using Andromeda.Application.Employee.Commands;
using Andromeda.Application.Employee.Queries;
using Andromeda.Application.Interfaces;
using Andromeda.Application.Login.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                var _result = await signInManager.PasswordSignInAsync(loginDetails.Username, loginDetails.Password);

                if (_result.Succeeded)
                {
                    return Json(new
                    {
                        Success = true,
                        Redirect = "/Dashboard/Index"
                    });
                }
                else
                {
                    throw new Exception(_result.Message);
                }
               
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            } 
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOut();

            return RedirectToAction("Login", "User");

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
