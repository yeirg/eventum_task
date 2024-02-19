namespace ET.BuildingBlocks.Domain;

public interface ICreationTimeAuditable
{
    /// <summary>
    /// Получает или задает время создания записи.
    /// </summary>
    DateTime CreatedAt { get; set; }
}