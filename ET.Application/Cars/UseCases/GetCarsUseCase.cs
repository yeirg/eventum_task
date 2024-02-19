using ET.Application.Cars.UseCases.Models;
using ET.BuildingBlocks.Application.Mediator;
using ET.Domain.Cars.Persistence;
using ET.Domain.Cars.Specifications;

namespace ET.Application.Cars.UseCases;

public class GetCarsUseCase : UseCase<GetCarsRequest, List<CarModel>>
{
    private readonly ICarRepository _repository;

    public GetCarsUseCase(ICarRepository repository)
    {
        _repository = repository;
    }

    protected override async Task<List<CarModel>> HandleAsync(GetCarsRequest request, CancellationToken cancellationToken)
    {
        var spec = new CarSpecification();
        spec.Paginate(request.Page, request.PageSize);
        
        var result = await _repository.GetListAsync<CarModel>(spec, cancellationToken);
        return result;
    }
}

public class GetCarsRequest(int page, int pageSize) : IQuery<List<CarModel>>
{
    public int Page { get; set; } = page;
    public int PageSize { get; set; } = pageSize;
}