using System.Net;
using ET.BuildingBlocks.Presentation;
using Microsoft.AspNetCore.Mvc;

namespace ET.Api.Controllers;

/// <summary>
/// Базовый контроллер API.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    /// <summary>
    /// Возвращает успешный результат с данными и кодом статуса.
    /// </summary>
    /// <typeparam name="TResult">Тип результата.</typeparam>
    /// <param name="result">Результат.</param>
    /// <param name="status">Код статуса HTTP.</param>
    /// <returns>Результат.</returns>
    protected Result Success<TResult>(TResult result, HttpStatusCode status = HttpStatusCode.OK)
    {
        Response.StatusCode = (int)status;
        return Result.Success(result);
    }
    
    /// <summary>
    /// Возвращает успешный результат без данных, только с кодом статуса.
    /// </summary>
    /// <param name="status">Код статуса HTTP.</param>
    /// <returns>Результат.</returns>
    protected Result Success(HttpStatusCode status = HttpStatusCode.OK)
    {
        Response.StatusCode = (int)status;
        return Result.Success();
    }
}