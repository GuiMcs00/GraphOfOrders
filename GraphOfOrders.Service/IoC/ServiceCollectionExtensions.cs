using GraphOfOrders.Lib.DI;
using Microsoft.Extensions.DependencyInjection;

namespace GraphOfOrders.Service.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}