using Andromeda.Application.Interfaces;
using Andromeda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromeda.Infrastructure.Persistence
{
    public class AndromedaDbContext : DbContext, IAndromedaDbContext
    {
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<TimeRecords> TimeRecords { get; set; }
        public DbSet<UserLogins> UserLogins { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AndromedaDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AndromedaDbContext).Assembly);

        }
    }
}
