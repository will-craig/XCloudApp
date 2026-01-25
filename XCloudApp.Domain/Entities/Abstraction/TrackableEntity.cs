namespace XCloudApp.Domain.Entities.Abstraction;

public abstract class TrackableEntity
{
    private readonly DateTime _currentUTC = DateTime.UtcNow;
    
    protected TrackableEntity()
    {
        CreatedDate = _currentUTC;
        UpdatedDate = _currentUTC;
    }

    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; set; }
}