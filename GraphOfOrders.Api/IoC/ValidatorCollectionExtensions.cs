using GraphOfOrders.Api.Validator;
using GraphOfOrders.Lib.DI.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace GraphOfOrders.Api.IoC;

public static class ValidatorCollectionExtensions
{
    public static IServiceCollection AddValidatorServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailValidator, EmailValidator>();
        return services;
    }
}