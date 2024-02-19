using AutoMapper;
using ET.Application.Cars.UseCases.Models;
using ET.BuildingBlocks.Application.Mediator;
using ET.BuildingBlocks.Application.Validation.Extensions;
using ET.Domain.Cars.Persistence;
using ET.Domain.Cars.Specifications;

namespace ET.Application.Cars.UseCases;

public class GetCarByIdUseCase(ICarRepository _repository, IMapper _mapper) : UseCase<GetCarByIdRequest, CarModel>
{
    protected override async Task<CarModel> HandleAsync(GetCarByIdRequest request, CancellationToken cancellationToken)
    {
        var spec = new CarSpecification();
        spec.IncludeColor().ById(request.Id);
        
        var car = await _repository.GetFirstOrDefaultAsync(spec, cancellationToken);
        car.EnsureExists(request.Id);
        
        return _mapper.Map<CarModel>(car);
    }
}

public class GetCarByIdRequest(Guid id) : IQuery<CarModel>
{
    public Guid Id { get; set; } = id;
}