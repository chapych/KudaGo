using KudaGo.Infrastructure.Interfaces;
using KudaGo.Infrastructure.Services;
using KudaGo.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace KudaGo.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddKudaGo(
        this IServiceCollection services)
    {
        services.AddScoped<IKudaGoService, KudaGoService>();
        services.AddScoped<ITypeConverter, TypeConverter>();
        services.AddScoped<IAPIAccesser, APIAccesser>();
        services.AddScoped<IEndpointFactory, EndpointFactory>();
        services.AddHttpClient();

        return services;
    }
}