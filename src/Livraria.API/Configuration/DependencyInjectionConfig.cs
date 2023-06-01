using Livraria.Domain.Interfaces.Service;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Services;
using Livraria.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Livraria.Infrastructure.Context;

namespace Livraria.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<LivrariaDbContext>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();

            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ILivroService, LivroService>();

            return services;
        }
    }
}
