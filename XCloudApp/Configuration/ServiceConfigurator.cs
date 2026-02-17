using Microsoft.EntityFrameworkCore;
using XCloudApp.DAL;
using XCloudApp.Services;

namespace XCloudApp.Configuration;

public static class ServiceConfigurator
{
    public static WebApplicationBuilder ConfigureBuilderServices(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
        //TODO: temporary
        builder.Services.AddDbContext<WebAppDbContext>(options => options.UseInMemoryDatabase("XCloudApp"));
        builder.Services.AddHealthChecks();

        var appUrl = builder.Configuration.GetValue<string>("AppUrl")
                     ?? throw new NullReferenceException("AppUrl configuration is missing");
        
        builder.Services.AddHttpClient("ApiClient", client =>
        {
            client.BaseAddress = new Uri(appUrl);
        });
        builder.Services.AddHttpClient();
        builder.Services.AddScoped<ISyncService, SyncService>();

        return builder;
    }
}
