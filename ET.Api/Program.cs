using ET.Api.Extensions;
using ET.BuildingBlocks.Presentation.ErrorHandling.Extensions;
using Serilog;



Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);
    
    builder.Host.UseSerilog();
    
    builder.Services.RegisterApplicationLayerServices();
    builder.Services.RegisterInfrastructureLayerServices(builder.Configuration);

    var app = builder.Build();

    await app.SeedUsersAsync();
    await app.SeedCarsAsync();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseAuthentication();
    
    app.UseApplicationExceptionHandlerMiddleware();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
}