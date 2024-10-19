using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Domain.Interface;
using ProductCatalog.Infra.Data.Repository;

namespace ProductCatalog.Infra.IoC
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
