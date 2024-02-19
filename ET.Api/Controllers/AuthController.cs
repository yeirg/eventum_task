using ET.BuildingBlocks.Presentation;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ET.Api.Controllers;

public class AuthController(ISender sender) : BaseController
{
    [HttpPost("login")]
    public async Task<Result> Login(LoginRequest request)
    {
        var token = await sender.Send(request);

        return Success(token);
    }
}