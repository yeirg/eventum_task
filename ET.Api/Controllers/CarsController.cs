using System.Net;
using ET.Application.Cars.UseCases;
using ET.Application.Cars.UseCases.Models;
using ET.BuildingBlocks.Presentation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ET.Api.Controllers;

public class CarsController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<Result> Create(CreateCarRequest request)
    {
        var car = await sender.Send(request);

        return Success(car);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<CarModel>), (int)HttpStatusCode.OK)]
    public async Task<Result> GetCars(GetCarsRequest request)
    {
        var cars = await sender.Send(request);

        return Success(cars);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(List<CarModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<Result> GetCar(Guid id)
    {
        var car = await sender.Send(new GetCarByIdRequest(id));

        return Success(car);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<Result> UpdateCar(Guid id, UpdateCarRequest request)
    {
        var car = await sender.Send(request);

        return Success(car);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<Result> DeleteCar(Guid id)
    {
        await sender.Send(new DeleteCarRequest(id));

        return Success();
    }
}