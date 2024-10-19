using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Application.Mappings;
using ProductCatalog.Application.Services;
using ProductCatalog.Application.Services.IServices;
using ProductCatalog.Domain.Interface;
using ProductCatalog.Domain.Models;
using ProductCatalog.Infra.Data.Repository;

namespace ProductCatalog.Infra.IoC
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton(new List<Product>());

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductServices, ProductServices>();

            services.AddAutoMapper(typeof(ProfileMap));

            return services;
        }
    }
}
