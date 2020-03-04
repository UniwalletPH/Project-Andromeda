using System;
using System.Collections.Generic;
using System.Text;

namespace Andromeda.Application.Login.Queries
{
    public class SignInResult
    {
        public bool IsLockedOut { get; protected set; }
        public bool IsNotAllowed { get; protected set; }
        public bool RequiresTwoFactor { get; protected set; }
        public bool Succeeded { get; protected set; }
        public string Message { get; set; }

        public static SignInResult Success
        {
            get
            {
                return new SignInResult
                {
                    Succeeded = true
                };
            }
        }

        public static SignInResult Failed
        {
            get
            {
                return new SignInResult
                {
                    Succeeded = false
                };
            }
        }
    }
}
