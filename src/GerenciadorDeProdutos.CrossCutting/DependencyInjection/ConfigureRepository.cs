using GerenciadorDeProdutos.Domain.Interfaces;
using GerenciadorDeProdutos.Infra.Data.Context;
using GerenciadorDeProdutos.Infra.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace GerenciadorDeProdutos.CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static IServiceCollection ConfigureDependenciesRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddDbContext<MyContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());


            return services;
        }
    }
}
