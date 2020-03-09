using Andromeda.Application.Identities.Queries;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Threading.Tasks;

namespace Andromeda.Extensions
{
    public static class IdentityExtensions
    {
        public static AndromedaUser GetUserData(this IIdentity identity)
        {
            ClaimsIdentity _claimsIdentity = identity as ClaimsIdentity;
            Claim _claim = _claimsIdentity?.FindFirst(ClaimTypes.UserData);

            var _userData = _claim?.Value;

            if (string.IsNullOrWhiteSpace(_userData))
            {
                return null;
            }

            var _retVal = JsonConvert.DeserializeObject<AndromedaUser>(_userData);

            return _retVal;
        }
    }
}
