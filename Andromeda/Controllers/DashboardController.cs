using Andromeda.Application.Employee.Queries;
using Andromeda.Application.Interfaces;
using Andromeda.Application.Record.Commands;
using Andromeda.Application.Record.Queries;
using Andromeda.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Andromeda.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly IMediator mediator;
        private readonly ISignInManager signInManager;
     
        public DashboardController(IMediator mediator, ISignInManager signInManager)
        {
            this.mediator = mediator;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {

          
            if (CurrentUser != null)
            {

                try
                {
                    var _currentUser = CurrentUser;

                    var _user = new EmployeeDetailVM
                    {
                        ID = _currentUser.ID,
                        Firstname = _currentUser.Firstname,
                        Lastname = _currentUser.Lastname,
                        Address = _currentUser.Address,
                        Email = _currentUser.Email,
                        Number = _currentUser.Number,
                        Role = _currentUser.Role
                    };

                    var _userDashboard = new DashboardVM
                    {
                        EmployeeDetails = _user
                    };

                    var _timeInCheck = await mediator.Send(new TimeInCheckerQuery { EmployeeID = _userDashboard.EmployeeDetails.ID });
                    var _timeOutCheck = await mediator.Send(new TimeOutCheckerQuery { EmployeeID = _userDashboard.EmployeeDetails.ID });

                    if (_timeInCheck == true && _timeOutCheck == true)
                    {
                        _userDashboard.LogType = LogType.None;
                    }
                    else if (_timeInCheck == false && _timeOutCheck == false)
                    {
                        _userDashboard.LogType = LogType.TimeIn;
                    }
                    else if (_timeInCheck == true && _timeOutCheck == false)
                    {
                        _userDashboard.LogType = LogType.TimeOut;
                    }

                    return View(_userDashboard);
                }

                catch (Exception ex)
                {
                    return ErrorView(ex);
                }
            }

            else
            {
                return Redirect("/User/Login");
            }
        }


        public async Task<IActionResult> TimeIn()
        {
            var _retVal = await mediator.Send(new SaveTimeInCommand { EmployeeID = CurrentUser.ID }); 

            return Json(_retVal);
        }

        public async Task<IActionResult> TimeOut()
        {
            var _retVal = await mediator.Send(new SaveTimeOutCommand { EmployeeID = CurrentUser.ID});

            return Json(_retVal);
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DTRReport()
        {

            var _employeeList = await mediator.Send(new GetListOfEmployeeQuery { });

            var _employeeNameList = new List<EmployeeDetailVM>();

            foreach (var item in _employeeList)
            {
                _employeeNameList.Add(item);
            }

            var mod = new DTRReportVM();
            var selectList = new List<SelectListItem>();

            foreach (var item in _employeeNameList)
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
