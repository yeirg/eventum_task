namespace ET.BuildingBlocks.Domain;

public interface ICreationActorAuditable
{
    /// <summary>
    /// Получает или задает идентификатор пользователя, создавшего запись.
    /// </summary>
    Guid CreatedBy { get; set; }
}