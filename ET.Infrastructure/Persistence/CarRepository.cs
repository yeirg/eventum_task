using AutoMapper;
using ET.BuildingBlocks.Infrastructure.Persistence;
using ET.Domain.Cars;
using ET.Domain.Cars.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ET.Infrastructure.Persistence;

public class CarRepository : EfRepository<Car>, ICarRepository
{
    public CarRepository(AppDb dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}