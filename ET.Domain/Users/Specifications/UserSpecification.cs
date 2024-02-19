using Ardalis.Specification;
using ET.BuildingBlocks.Domain.Specification;

namespace ET.Domain.Users.Specifications;

/// <summary>
/// Спецификация для формирования запросов к репозиторию пользователей.
/// </summary>
public class UserSpecification : AggregateSpecification<User>
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="UserSpecification"/>.
    /// </summary>
    public UserSpecification()
    {
    }

    /// <summary>
    /// Устанавливает условие для выбора пользователей по логину.
    /// </summary>
    /// <param name="login">Логин пользователя.</param>
    /// <returns>Текущая спецификация с добавленным условием.</returns>
    public UserSpecification ByLogin(string login)
    {
        Query.Where(user => user.Login.Value == login);
        return this;   
    }
}