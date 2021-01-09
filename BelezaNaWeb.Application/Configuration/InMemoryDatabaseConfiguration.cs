using BelezaNaWeb.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Application.Configuration
{
    public static class InMemoryDatabaseConfiguration
    {
        public static IServiceCollection ConfigInMemoryDatabase(this IServiceCollection services)
        {
            services.AddDbContext<BelezaNaWebContext>(options => { options.UseInMemoryDatabase("BelezaNaWebDB"); });

            return services;
        }
    }
}
