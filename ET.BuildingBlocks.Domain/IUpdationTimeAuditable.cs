namespace ET.BuildingBlocks.Domain;

public interface IUpdationTimeAuditable
{
    /// <summary>
    /// Получает или задает время последнего обновления записи.
    /// </summary>
    DateTime UpdatedAt { get; set; }
}