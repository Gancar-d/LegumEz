namespace LegumEz.Infrastructure.Persistance.Exceptions;

public class EntityNotFoundException : Exception
{
    public Guid EntityId { get; set; }
    public Type EntityType { get; set; }

    public EntityNotFoundException(Guid entityId, Type entityType)
    {
        EntityId = entityId;
        EntityType = entityType;
    }

    public EntityNotFoundException(Guid entityId, Type entityType, string? message)
        : base(message)
    {
        EntityId = entityId;
        EntityType = entityType;
    }
    
    public EntityNotFoundException(Guid entityId, Type entityType, string? message, Exception? exception)
        : base(message, exception)
    {
        EntityId = entityId;
        EntityType = entityType;
    }
}