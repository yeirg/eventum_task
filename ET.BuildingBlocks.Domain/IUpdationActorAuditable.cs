namespace ET.BuildingBlocks.Domain;

public interface IUpdationActorAuditable
{
    /// <summary>
    /// Получает или задает идентификатор пользователя, последнего редактировавшего запись.
    /// </summary>
    Guid UpdatedBy { get; set; }
}