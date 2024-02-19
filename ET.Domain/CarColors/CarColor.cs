using ET.BuildingBlocks.Domain;
using ET.Domain.Cars;

namespace ET.Domain.CarColors;

public class CarColor : AggregateRoot
{
    public Color Color { get; private set; }

    public virtual List<Car>? Cars { get; private set; }
    public IEnumerable<Guid> CarIds => Cars?.Select(s => s.Id) ?? Enumerable.Empty<Guid>();
    
    private CarColor() {}
    
    public CarColor(Color color) : this(Guid.NewGuid(), color)
    {
    }

    public CarColor(Guid id, Color color)
    {
        Id = id;
        Color = color;
    }
}