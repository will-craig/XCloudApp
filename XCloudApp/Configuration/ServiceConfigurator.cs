namespace XCloudApp.Configuration;

public static class ServiceConfigurator
{
    public static WebApplicationBuilder ConfigureBuilderServices(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        // Add services to the container.
        services.AddRazorComponents()
                .AddInteractiveServerComponents();
        
        return builder;
    }
}