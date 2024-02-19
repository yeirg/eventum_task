using ET.BuildingBlocks.Application.Consistence.Abstractions;
using ET.BuildingBlocks.Application.Mediator;
using ET.BuildingBlocks.Application.Validation.Extensions;
using ET.BuildingBlocks.Domain.Specification;
using ET.Domain.CarColors;
using ET.Domain.CarColors.Persistence;
using ET.Domain.Cars;
using ET.Domain.Cars.Persistence;

namespace ET.Application.Cars.UseCases;

public class CreateCarUseCase(ICarColorRepository carColorRepository, ICarRepository carRepository, IUnitOfWork unitOfWork) : UseCase<CreateCarRequest, Guid>
{
    protected override async Task<Guid> HandleAsync(CreateCarRequest request, CancellationToken cancellationToken)
    {
        //var car = new Car(new BrandName(request.Brand), new ModelName(request.Model), );
        var color = await carColorRepository.GetFirstOrDefaultAsync(
            new AggregateSpecification<CarColor>()
                .ById(request.Color), 
            cancellationToken).EnsureExistsAsync(request.Color);
        
        var car = new Car(new BrandName(request.Brand), new ModelName(request.Model), color);
        await carRepository.AddAsync(car);
        await unitOfWork.CommitAsync(cancellationToken);

        return car.Id;
    }
}

public class CreateCarRequest : ICommand<Guid>
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public Guid Color { get; set; }
}