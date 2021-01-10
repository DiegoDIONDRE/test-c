using BelezaNaWeb.Application.Interfaces;
using BelezaNaWeb.Application.Services;
using BelezaNaWeb.Domain.Interfaces;
using BelezaNaWeb.Infraestructure.Context;
using BelezaNaWeb.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Application.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<BelezaNaWebContext>();

            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoInventarioRepository, ProdutoInventarioRepository>();
            services.AddScoped<IProdutoArmazemRepository, ProdutoArmazemRepository>();

            return services;
        }
    }
}
