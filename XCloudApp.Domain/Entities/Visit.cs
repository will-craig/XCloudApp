using XCloudApp.Domain.Entities.Abstraction;
using XCloudApp.Domain.Enum;

namespace XCloudApp.Domain.Entities;

public class Visit : TrackableEntity
{
    public int Id { get; set; }
    public CSP CloudServiceProvider { get; set; }
    
}