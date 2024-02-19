using Ardalis.Specification;
using ET.BuildingBlocks.Domain.Specification;

namespace ET.Domain.Cars.Specifications;

public class CarSpecification : AggregateSpecification<Car>
{
    public CarSpecification()
    {
        
    }
    
    public CarSpecification Paginate(int page, int pageSize)
    {
        Query.Skip(pageSize * (page - 1)).Take(pageSize);
        return this;
    }
}