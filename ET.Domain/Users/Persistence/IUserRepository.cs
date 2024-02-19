using ET.BuildingBlocks.Domain.Persistence;

namespace ET.Domain.Users.Persistence;

/// <summary>
/// Интерфейс репозитория для доступа к объектам User.
/// </summary>
public interface IUserRepository : IRepository<User>
{
}