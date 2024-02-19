using AutoMapper;
using ET.Application.Cars.UseCases.Models;
using ET.Domain.Cars;

namespace ET.Application.Cars;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarModel>();
        
    }
}