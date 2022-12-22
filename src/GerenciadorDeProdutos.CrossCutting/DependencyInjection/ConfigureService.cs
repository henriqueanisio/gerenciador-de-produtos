using GerenciadorDeProdutos.Domain.Interfaces;
using GerenciadorDeProdutos.Service.Services;
using Microsoft.Extensions.DependencyInjection;


namespace GerenciadorDeProdutos.CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
        public static IServiceCollection ConfigureDependenciesService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
