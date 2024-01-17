using Api.Mapping;

namespace Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        // services.AddControllers();
        services.AddMapping();
        return services;
    }
}