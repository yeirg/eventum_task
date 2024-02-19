using ET.BuildingBlocks.Application.Consistence.Abstractions;
using ET.BuildingBlocks.Application.Mediator;
using ET.BuildingBlocks.Application.Validation.Extensions;
using ET.BuildingBlocks.Domain.Specification;
using ET.Domain.CarColors;
using ET.Domain.CarColors.Persistence;
using ET.Domain.Cars;
using ET.Domain.Cars.Persistence;

namespace ET.Application.Cars.UseCases;

public class UpdateCarUseCase(ICarRepository carRepository, ICarColorRepository carColorRepository, IUnitOfWork unitOfWork) : UseCase<UpdateCarRequest, Guid>
{
    protected override async Task<Guid> HandleAsync(UpdateCarRequest request, CancellationToken cancellationToken)
    {
        var color = await carColorRepository.GetFirstOrDefaultAsync(new AggregateSpecification<CarColor>().ById(request.Id), cancellationToken)
            .EnsureExistsAsync(request.Color);
        var car = await carRepository.GetFirstOrDefaultAsync(new AggregateSpecification<Car>().ById(request.Id), cancellationToken)
            .EnsureExistsAsync(request.Id);
        
        car.Update(request.Brand, request.Model, color);
        await carRepository.UpdateAsync(car);
        await unitOfWork.CommitAsync(cancellationToken);

        return car.Id;
    }
}

public class UpdateCarRequest : ICommand<Guid>
{
    public Guid Id { get; } = Guid.Empty;
    public string Brand { get; } = string.Empty;
    public string Model { get; } = string.Empty;
    public Guid Color { get; } = Guid.Empty;
}