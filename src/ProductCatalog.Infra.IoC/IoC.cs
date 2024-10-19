using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Application.Services;
using ProductCatalog.Application.Services.IServices;
using ProductCatalog.Domain.Interface;
using ProductCatalog.Infra.Data.Repository;

namespace ProductCatalog.Infra.IoC
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IProductServices, ProductServices>();
            return services;
        }
    }
}
