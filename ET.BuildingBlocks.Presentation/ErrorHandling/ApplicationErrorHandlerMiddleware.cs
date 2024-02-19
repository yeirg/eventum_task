using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ET.BuildingBlocks.Presentation.ErrorHandling;

/// <summary>
/// Промежуточное ПО для обработки ошибок приложения.
/// </summary>
public class ApplicationErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ApplicationErrorHandlerMiddleware> _logger;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ApplicationErrorHandlerMiddleware"/>.
    /// </summary>
    public ApplicationErrorHandlerMiddleware(
        RequestDelegate next,
        ILogger<ApplicationErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Выполняет обработку исключений в контексте HTTP-запроса.
    /// </summary>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (ValidationException validationException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            
            _logger.LogCritical(exception, "An unhandled exception occurred");
        }
    }
}