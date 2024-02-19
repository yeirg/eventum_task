using Microsoft.AspNetCore.Builder;

namespace ET.BuildingBlocks.Presentation.ErrorHandling.Extensions;

public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Использует промежуточное ПО для обработки исключений приложения.
    /// </summary>
    /// <param name="appBuilder">Сборщик приложения.</param>
    public static void UseApplicationExceptionHandlerMiddleware(this IApplicationBuilder appBuilder)
    {
        appBuilder.UseMiddleware<ApplicationErrorHandlerMiddleware>();
    }
}