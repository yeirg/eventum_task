using ET.Application.Cars;
using ET.Application.Users;
using ET.Application.Users.Auth.Abstractions;
using ET.Application.Users.Auth.Services;
using ET.Application.Users.Auth.UseCases;
using ET.BuildingBlocks.Application.Consistence.Extensions;
using ET.BuildingBlocks.Application.Consistence.Services;
using ET.BuildingBlocks.Application.Extensions;
using ET.BuildingBlocks.Infrastructure.Extensions;
using ET.BuildingBlocks.Infrastructure.Persistence;
using ET.BuildingBlocks.Security.Extensions;
using ET.Domain.CarColors.Persistence;
using ET.Domain.Cars.Persistence;
using ET.Domain.Users.Persistence;
using ET.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ET.Api.Extensions;

public static class DependencyInjectionExtensions
{
    private static void RegisterJwtTokenFactory(this IServiceCollection services)
    {
        services.AddSingleton<ITokenFactory, JwtTokenFactory>();
    }
    
    public static void RegisterApplicationLayerServices(this IServiceCollection services)
    {
        services.RegisterRepositories();
        services.AddScoped<AuthenticationService>();
        services.RegisterUnitOfWork<AppDb>();
        services.AddScoped<UserSeederService>();
        services.AddScoped<CarSeederService>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(LoginRequest).Assembly));
    }

    public static void RegisterInfrastructureLayerServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterJwtAuthentication(configuration);
        services.RegisterJwtTokenFactory();
        services.RegisterJwtTokenFactory();
        services.RegisterBcryptPasswordHasher();
        services.RegisterAppDbContext<AppDb>(ob => ob.UseNpgsql(
            configuration.GetConnectionString(nameof(AppDb))));
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                    },
                    new List<string>()
                }
            });
        });
        services.AddEndpointsApiExplorer();
        services.AddAutoMapper(typeof(CarProfile).Assembly);
        services.RegisterAuditorDbContextInterceptors();
    }

    private static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICarColorRepository, CarColorRepository>();
    }

    private static void RegisterBcryptPasswordHasher(this IServiceCollection services)
    {
        services.AddSingleton<IPasswordHasher, BcryptPasswordHasher>();
    }
}