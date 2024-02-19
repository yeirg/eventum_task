using AutoMapper;
using ET.Application.Cars.UseCases.Models;
using ET.Domain.Cars;

namespace ET.Application.Cars;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarModel>()
            .ForMember(c => c.Color, d => d.MapFrom(
                    g => g.Color.Color.Value))
            .ForMember(c => c.Brand, d => d.MapFrom(
                g => g.Brand.Value))
            .ForMember(c => c.Model, d => d.MapFrom(
                g=> g.Model.Value));
    }
}