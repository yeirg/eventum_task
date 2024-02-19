using ET.BuildingBlocks.Domain;

namespace ET.Domain.CarColors;

public class CarColor : AggregateRoot
{
    public Color Color { get; private set; }
    
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