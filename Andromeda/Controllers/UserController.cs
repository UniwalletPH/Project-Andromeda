using Andromeda.Application.Employee.Commands;
using Andromeda.Application.Employee.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andromeda.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        
        public async Task<IActionResult>  SaveEmployee(EmployeeDetailVM employee)
        {
            var _retVal = await mediator.Send(new AddEmployeeCommand { Employee = employee});

            return PartialView("~/Views/Home/Partial/_loginDetails.cshtml", _retVal);
        }
    }
}
