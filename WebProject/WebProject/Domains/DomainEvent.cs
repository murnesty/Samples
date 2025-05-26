namespace WebProject.Domains;

public class DomainEvent : IDomainEvent
{
    public Guid Id { get; init; } = Guid.NewGuid();
}
