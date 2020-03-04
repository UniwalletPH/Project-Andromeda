using Andromeda.Application.Interfaces;
using Andromeda.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromeda.Infrastructure
{
    public static class DependencyInjection
    {        
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AndromedaDbContext>();

            services.AddScoped<IAndromedaDbContext>(provider => provider.GetService<AndromedaDbContext>());

            return services;

        }

    }
}

