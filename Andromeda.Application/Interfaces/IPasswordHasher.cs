using System;
using System.Collections.Generic;
using System.Text;

namespace Andromeda.Application.Interfaces
{
    public interface IPasswordHasher
    {
        byte[] GenerateSalt();

        byte[] HashPassword(byte[] salt, string password);

        bool IsPasswordVerified(byte[] salt, byte[] hashedPassword, string password);
    }
}
