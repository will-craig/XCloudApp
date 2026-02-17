using XCloudApp.Components;

namespace XCloudApp.Configuration;

public static class MiddlewareConfigurator
{
    public static WebApplication ConfigureMiddleware(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseStatusCodePagesWithReExecute("/not-found");
        app.UseHttpsRedirection();

        app.MapStaticAssets();
        
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
           .AddInteractiveServerRenderMode();
        
        return app;
    }
}