using ET.BuildingBlocks.Security.Abstractions;
using ET.BuildingBlocks.Security.Options;
using ET.BuildingBlocks.Security.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ET.BuildingBlocks.Security.Extensions;

public static class DependencyInjectionExtensions
{
    /// <summary>
    /// Регистрирует компоненты для JWT-аутентификации на основе настроек из конфигурации.
    /// </summary>
    /// <param name="services">Коллекция служб для регистрации компонентов.</param>
    /// <param name="configuration">Конфигурация приложения.</param>
    public static void RegisterJwtAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        const string tokenConfigurationKey = "Authentication:Token";

        var jwtOptionsSection = configuration.GetSection(tokenConfigurationKey);
        var jwtOptions = jwtOptionsSection.Get<JwtTokenOptions>();

        _ = jwtOptions ?? throw new ArgumentNullException("jwtOptions");
        _ = jwtOptions.SecretKey ?? throw new ArgumentNullException($"{tokenConfigurationKey}:SecretKey");
        
        services.Configure<JwtTokenOptions>(jwtOptionsSection);
        services.AddScoped<IAuthenticationContext, AuthenticationContext>();
        services.AddHttpContextAccessor();
        
        services
            .AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opts =>
            {
                opts.RequireHttpsMetadata = false;

                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,

                    RequireSignedTokens = true,
                    IssuerSigningKey = jwtOptions.CreateKey(),
                };

                opts.MapInboundClaims = false;
            });

        services.AddAuthorizationBuilder()
            .SetDefaultPolicy(new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build());
    }
}