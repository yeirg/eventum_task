using MediatR;

namespace ET.BuildingBlocks.Application.Mediator;

/// <summary>
/// Интерфейс для команд, использующих MediatR.
/// </summary>
public interface ICommand : IRequest<Unit>
{
}

/// <summary>
/// Интерфейс для команд, использующих MediatR с типом.
/// </summary>
/// <typeparam name="TResponse">Тип возвращаемого значения.</typeparam>
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}