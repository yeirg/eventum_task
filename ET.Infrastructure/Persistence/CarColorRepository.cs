using AutoMapper;
using ET.BuildingBlocks.Infrastructure.Persistence;
using ET.Domain.CarColors;
using ET.Domain.CarColors.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ET.Infrastructure.Persistence;

public class CarColorRepository : EfRepository<CarColor>, ICarColorRepository
{
    public CarColorRepository(AppDb dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}