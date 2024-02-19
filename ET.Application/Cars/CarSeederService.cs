using ET.BuildingBlocks.Application.Consistence.Abstractions;
using ET.Domain.CarColors;
using ET.Domain.CarColors.Persistence;
using ET.Domain.Cars;
using ET.Domain.Cars.Persistence;

namespace ET.Application.Cars;

public class CarSeederService
{
    private readonly ICarRepository _carRepository;
    private readonly ICarColorRepository _carColorRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CarSeederService(ICarRepository carRepository, IUnitOfWork unitOfWork, ICarColorRepository carColorRepository)
    {
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
        _carColorRepository = carColorRepository;
    }
    
    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        if (await _carRepository.CountAsync(cancellationToken: cancellationToken) > 0)
        {
            return;
        }
        
        var colors = new List<CarColor>
        {
            new CarColor("Red"),
            new CarColor("Blue"),
            new CarColor("Green"),
            new CarColor("Yellow"),
            new CarColor("Black"),
        };
        
        var cars = new List<Car>() 
        {
            new Car(new BrandName("Toyota"), new ModelName("Corolla"), colors[0]),
            new Car(new BrandName("Toyota"), new ModelName("Camry"), colors[1]),
            new Car(new BrandName("Toyota"), new ModelName("RAV4"), colors[2]),
            new Car(new BrandName("Toyota"), new ModelName("Highlander"), colors[3]),
            new Car(new BrandName("Toyota"), new ModelName("4Runner"), colors[4]),
        };

        await _carColorRepository.AddAsync(colors.ToArray());
        await _carRepository.AddAsync(cars.ToArray());
    }
}