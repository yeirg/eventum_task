using ET.Application.Cars;
using ET.Application.Users;
using Serilog;

namespace ET.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static async Task SeedUsersAsync(this IApplicationBuilder appBuilder)
    {
        var scope = appBuilder.ApplicationServices.CreateScope();
        
        var seedService = scope.ServiceProvider.GetRequiredService<UserSeederService>();
        
        await seedService.SeedAsync(CancellationToken.None);
    }

    public static async Task SeedCarsAsync(this IApplicationBuilder appBuilder)
    {
        var scope = appBuilder.ApplicationServices.CreateScope();
        
        var seedService = scope.ServiceProvider.GetRequiredService<CarSeederService>();

        await seedService.SeedAsync(CancellationToken.None);
    }
}