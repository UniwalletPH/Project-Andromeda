using Andromeda.Application.Identities.Queries;
using Andromeda.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andromeda.Controllers
{
    public abstract class BaseController : Controller
    {
        public AndromedaUser CurrentUser
        {
            get
            {
                if (User == null)
                {
                    return null;
                }

                if (User.Identity == null)
                {
                    return null;
                }

                return User.Identity.GetUserData();
            }
        }

        internal ActionResult ErrorView(Exception exception)
        {
            return View("~/Views/Error/Index.cshtml", exception);
        }

    }
}
