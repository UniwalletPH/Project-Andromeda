using Andromeda.Application.Employee.Queries;
using Andromeda.Application.Record.Commands;
using Andromeda.Application.Record.Queries;
using Andromeda.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andromeda.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IMediator mediator;
        public DashboardController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminView()
        {
            return View(Startup.UserDashboard);
        }
      
        public IActionResult UserView()
        {
            return View(Startup.UserDashboard);
        }

        public async Task<IActionResult> TimeIn()
        {
            var _retVal = await mediator.Send(new SaveTimeInCommand { EmployeeID = Startup.UserDashboard.ID});

            return Json(_retVal);
        }

        public async Task<IActionResult> TimeOut()
        {
            var _retVal = await mediator.Send(new SaveTimeOutCommand { EmployeeID = Startup.UserDashboard.ID});

            return Json(_retVal);
        }

        public async Task<IActionResult> DailyReport()
        {

            var _retVal = await mediator.Send(new GetListOfEmployeeQuery { });

            var _x = new List<EmployeeDetailVM>();

            foreach (var item in _retVal)
            {
                _x.Add(item);
            }

            var mod = new DTRReportVM();
            var selectList = new List<SelectListItem>();

            foreach (var item in _x)
            {
                selectList.Add(new SelectListItem{
                
                Value = item.ID.ToString(),
                Text = item.Lastname +", " + item.Firstname              
                });
            }

            mod.Names = selectList;

            return View(mod);
        }

       
        public async Task<IActionResult> ViewRecord(DTRReportVM reportDetails)
        {



            var _retValIn = await mediator.Send(new GetTimeInDetailQuery { EmployeeID = reportDetails.Selected, From = reportDetails.From, To = reportDetails.To});
            var _retValOut = await mediator.Send(new GetTimeOutDetailQuery { EmployeeID = reportDetails.Selected, From = reportDetails.From, To =reportDetails.To});


            var a = new List<TimeRecordVM>();

            foreach (var i in _retValIn)
            {
                foreach (var o in _retValOut)
                {
                    if (i.Value.Date == o.Value.Date)
                    {

                        var x = new TimeRecordVM
                        { 
                        Date = i.Value.Date,
                        TimeIn = i,
                        TimeOut = o,
                        };

                        a.Add(x);
                    }
                }    
            }

            return PartialView("~/Views/Dashboard/Partial/_RecordView.cshtml", a);
      
        }
    }   
}
