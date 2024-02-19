using AutoMapper;
using ET.Application.Cars.UseCases.Models;
using ET.BuildingBlocks.Application.Mediator;
using ET.Domain.Cars.Persistence;
using ET.Domain.Cars.Specifications;

namespace ET.Application.Cars.UseCases;

public class GetCarsUseCase : UseCase<GetCarsRequest, List<CarModel>>
{
    private readonly ICarRepository _repository;
    private readonly IMapper _mapper;

    public GetCarsUseCase(ICarRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    protected override async Task<List<CarModel>> HandleAsync(GetCarsRequest request, CancellationToken cancellationToken)
    {
        var spec = new CarSpecification();
        spec.IncludeColor().Paginate(request.Page, request.PageSize);

        var result = await _repository.GetListAsync(spec, cancellationToken);
        return _mapper.Map<List<CarModel>>(result);
    }
}

public class GetCarsRequest(int page, int pageSize) : IQuery<List<CarModel>>
{
    public int Page { get; set; } = page;
    public int PageSize { get; set; } = pageSize;
}