using Andromeda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromeda.Application.Login.Queries
{
    public class UserLoginsVM
    {
        public string Username { get; set; }

        public byte[] Salt { get; set; }
        public byte[] Password { get; set; }
    }
}
