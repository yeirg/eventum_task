using MediatR;

namespace ET.BuildingBlocks.Application.Mediator;

public interface IQuery : IRequest<Unit>
{
    
}

public interface IQuery<out TResponse> : IRequest<TResponse>
{
    
}