namespace WebProject.Domains;

public abstract class Entity : AuditableEntityBase, IEquatable<Entity>
{
    public Guid Id { get; protected set; }

    public bool Equals(object? other) =>
        other is Entity entity && Id.Equals(entity.Id);

    public bool Equals(Entity? other) =>
        Equals((object?)other);

    public static bool operator ==(Entity? left, Entity? right) =>
        Equals(left, right);

    public static bool operator !=(Entity? left, Entity? right) =>
        !Equals(left, right);

    public override int GetHashCode() =>
        Id.GetHashCode();
}
