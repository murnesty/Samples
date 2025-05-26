using System.Text.Json.Serialization;

namespace WebProject.Domains;

public abstract class AuditableEntityBase
{
    [JsonInclude]
    public DateTimeOffset DateCreated { get; protected set; }

    [JsonInclude]
    public DateTimeOffset DateUpdated { get; protected set; }

    [JsonInclude]
    public string CreatedBy { get; protected set; }

    [JsonInclude]
    public string UpdatedBy { get; protected set; }

    public bool IsDeleted { get; protected set; }

    public void ApplyAddedEntityState(DateTimeOffset now, string userId)
    {
        DateCreated = now;
        DateUpdated = now;
        CreatedBy = userId;
        UpdatedBy = userId;
        IsDeleted = false;
    }

    public void ApplyModifiedEntityState(DateTimeOffset now, string userId)
    {
        DateUpdated = now;
        UpdatedBy = userId;
    }

    public void Delete() =>
        IsDeleted = true;
}
