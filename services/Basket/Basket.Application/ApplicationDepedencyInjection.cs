using Basket.Application.Commands;
using Basket.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Basket.Application;

public static class ApplicationDepedencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BasketMappingProfile).Assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(),
            Assembly.GetAssembly(typeof(CreateShoppingCartCommand))));

        return services;
    }
}

