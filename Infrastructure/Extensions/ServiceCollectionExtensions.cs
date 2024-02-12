using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using UseCases;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddKudaGo(
        this IServiceCollection services)
    {
        services.AddScoped<IKudaGoService, KudaGoService>();
        services.AddScoped<ITypeConverter, TypeConverter>();
        services.AddScoped<IAPIAccesser, APIAccesser>();
        services.AddScoped<IKudaGoService, KudaGoService>();

        return services;
    }
}