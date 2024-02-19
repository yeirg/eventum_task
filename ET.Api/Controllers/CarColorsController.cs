using System.Net;
using ET.BuildingBlocks.Presentation;
using ET.Domain.CarColors;
using ET.Domain.CarColors.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ET.Api.Controllers;

[Authorize]
public class CarColorsController : BaseController
{
    private readonly ICarColorRepository _repository;

    public CarColorsController(ICarColorRepository repository)
    {
        _repository = repository;
    }

        
    [HttpGet]
    [ProducesResponseType(typeof(List<ColorModel>), (int) HttpStatusCode.OK)]
    public async Task<Result> Get()
    {
        var colors = await _repository.GetListAsync();

        var result = new List<ColorModel>();
        foreach (var color in colors)
        {
            result.Add(new ColorModel() { Id = color.Id, Name = color.Color.Value });
        }
        return Success(result);
    }

    class ColorModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}