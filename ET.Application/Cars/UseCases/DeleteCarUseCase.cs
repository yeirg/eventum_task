using ET.BuildingBlocks.Application.Consistence.Abstractions;
using ET.BuildingBlocks.Application.Mediator;
using ET.BuildingBlocks.Application.Validation.Extensions;
using ET.BuildingBlocks.Domain.Specification;
using ET.Domain.Cars;
using ET.Domain.Cars.Persistence;
using MediatR;

namespace ET.Application.Cars.UseCases;

public class DeleteCarUseCase(ICarRepository carRepository, IUnitOfWork unitOfWork) : UseCase<DeleteCarRequest>
{
    private readonly ICarRepository _carRepository = carRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    protected override async Task HandleRequestAsync(DeleteCarRequest request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetFirstOrDefaultAsync(
            new AggregateSpecification<Car>()
                .ById(request.Id), cancellationToken);
        car.EnsureExists(request.Id);
        car!.Delete();
        
        await _carRepository.HardDeleteAsync(car!);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}

public class DeleteCarRequest(Guid id) : ICommand
{
    public Guid Id { get; } = id;
}