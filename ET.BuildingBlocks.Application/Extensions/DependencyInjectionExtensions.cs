using System.Reflection;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Microsoft.Extensions.DependencyInjection;

namespace ET.BuildingBlocks.Application.Extensions;

public static class DependencyInjectionExtensions
{
    public static void RegisterAutomapper(this IServiceCollection services, params Assembly[] assemblies)
    {
        Action<IMapperConfigurationExpression> configurator = cfg =>
        {
            cfg.AllowNullCollections = true;
            cfg.AllowNullDestinationValues = true;
            cfg.AddCollectionMappers();
            cfg.AddMaps(assemblies);
        };
        
        var configuration = new MapperConfiguration(configurator);
        
        configuration.AssertConfigurationIsValid();

        services.AddAutoMapper(configurator);
    }
}