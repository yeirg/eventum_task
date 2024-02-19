using ET.BuildingBlocks.Domain;
using ET.Domain.CarColors;
using ET.Domain.Cars.DomainEvents;

namespace ET.Domain.Cars;

public class Car : AuditableAggregateRoot
{
    public BrandName Brand { get; private set; }
    public ModelName Model { get; private set; }
    public virtual CarColor Color { get; private set; }

    private Guid _colorId;

    public Guid ColorId
    {
        get => _colorId;
        private set => _colorId = value;
    }
    
    private Car() {}

    public Car(BrandName brand, ModelName model, CarColor color) : this(Guid.NewGuid(), brand, model, color)
    {
    }
    
    public Car(Guid id, BrandName brand, ModelName model, CarColor color)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Color = color;
        
        AddEvent(new CarCreatedDomainEvent(Id, brand, model, color.Color));
    }
    
    public void Update(BrandName brand, ModelName model, CarColor color)
    {
        if (!Brand.Equals(brand))
        {
            Brand = brand;
        }
        if (!Model.Equals(model))
        {
            Model = model;
        }
        if (!ColorId.Equals(color.Id))
        {
            Color = color;
        }
        
        AddEvent(new CarUpdatedDomainEvent(Id, brand, model, color.Color));
    }
    
    public void Delete()
    {
        AddEvent(new CarDeletedDomainEvent(Id));
    }
}