using Andromeda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Andromeda.Application.Interfaces
{
    public interface IAndromedaDbContext
    {
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }

        public DbSet<TimeRecords> TimeRecords { get; set; }

        public DbSet<UserLogins> UserLogins { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
       
    }
}
