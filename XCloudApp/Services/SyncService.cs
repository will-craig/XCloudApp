using XCloudApp.Domain.Entities;

namespace XCloudApp.Services;

public class SyncService : ISyncService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<SyncService> _logger;

    public SyncService(IHttpClientFactory httpClientFactory, ILogger<SyncService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task SyncVisitAsync(Visit visit)
    {
        // specific endpoints for other clouds would be configured here
        var peerEndpoints = new[]
        {
            "http://azure-app.example.com/api/internal/sync",
            "http://aws-app.example.com/api/internal/sync",
            "http://gcp-app.example.com/api/internal/sync"
        };

        foreach (var endpoint in peerEndpoints)
        {
            try
            {
                // In a real app, we would skip the current cloud's own endpoint
                // and use a retry policy.
                _logger.LogInformation("Syncing visit {VisitId} to {Endpoint}", visit.Id, endpoint);
                
                // Mocking the call for POC
                // var client = _httpClientFactory.CreateClient();
                // await client.PostAsJsonAsync(endpoint, visit);
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to sync visit {VisitId} to {Endpoint}", visit.Id, endpoint);
            }
        }
    }
}
