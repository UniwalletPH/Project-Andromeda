using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Andromeda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Text.Json;
using Andromeda.Application.Employee.Queries;
using Andromeda.Application.Record.Queries;
using MediatR;
using System.Threading.Tasks;

namespace Andromeda.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMediator mediator;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IMediator mediator)
        {
            _logger = logger;
            this.httpContextAccessor = httpContextAccessor;
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            if (CurrentUser != null)
            {
                return Redirect("/Home/Dashboard");
            }

            return Redirect("/User/Login");
        }
    

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
