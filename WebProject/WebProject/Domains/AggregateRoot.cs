namespace WebProject.Domains;

public abstract class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public long Version { get; protected set; }

    public IReadOnlyCollection<IDomainEvent> DomainEvents =>
        _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        if (_domainEvents.Count == 0)
        {
            Version++;
        }

        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() =>
        _domainEvents.Clear();
}
