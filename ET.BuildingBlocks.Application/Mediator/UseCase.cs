using System.Windows.Input;
using MediatR;

namespace ET.BuildingBlocks.Application.Mediator;

/// <summary>
/// Абстрактный класс для использования в различных бизнес-сценариях.
/// /// </summary>
/// <typeparam name="TRequest">Тип запроса.</typeparam>
/// <typeparam name="TResponse">Тип ответа.</typeparam>
public abstract class UseCase<TRequest, TResponse>()
    : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var response = await HandleAsync(request, cancellationToken);

        return response;
    }
    
    /// <summary>
    /// Абстрактный метод для обработки запроса. Должен быть переопределен в производных классах.
    /// </summary>
    protected abstract Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// Абстрактный класс для использования в бизнес-сценариях, которые не возвращают значимый результат (например, команды).
/// Наследует базовый UseCase и возвращает Unit для команд.
/// </summary>
/// <typeparam name="TCommand">Тип команды.</typeparam>
public abstract class UseCase<TCommand>
    : UseCase<TCommand, Unit>
    where TCommand : ICommand
{
    protected override async Task<Unit> HandleAsync(TCommand request, CancellationToken cancellationToken)
    {
        await HandleRequestAsync(request, cancellationToken);

        return Unit.Value;
    }

    /// <summary>
    /// Абстрактный метод для обработки команды. Должен быть переопределен в производных классах.
    /// </summary>
    protected abstract Task HandleRequestAsync(TCommand request, CancellationToken cancellationToken);
}