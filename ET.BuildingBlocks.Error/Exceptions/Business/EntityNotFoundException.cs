namespace ET.BuildingBlocks.Error.Exceptions.Business;

public class EntityNotFoundException : BusinessException
{
    public string EntityName { get; }
    public Guid EntityId { get; }
        
    public EntityNotFoundException(string entityName, Guid entityId, string code, string message) 
        : base(code, message)
    {
        EntityName = entityName;
        EntityId = entityId;
    }
}