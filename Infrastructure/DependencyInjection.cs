using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Application.Services;
using Infrastructure.Authentication;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        services.Configure<JwtSettings>(builderConfiguration.GetSection(JwtSettings.SectionName));
        
        // services.AddDbContext<AppDbContext>(options =>
        //     options.UseNpgsql(builderConfiguration.GetConnectionString("DefaultConnection")));
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddSingleton<IUserRepository, UserRepository>();
        
        return services;
    }
}