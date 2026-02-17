using XCloudApp.Domain.Entities;

namespace XCloudApp.Services;

public interface ISyncService
{
    Task SyncVisitAsync(Visit visit);
}
