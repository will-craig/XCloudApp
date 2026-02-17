using Microsoft.EntityFrameworkCore;
using XCloudApp.Configuration;
using XCloudApp.DAL;
using XCloudApp.Domain.Entities;
using XCloudApp.Domain.Enum;
using XCloudApp.Services;

var app = WebApplication
         .CreateBuilder(args)
         .ConfigureBuilderServices()
         .Build()
         .ConfigureMiddleware();

app.MapHealthChecks("/healthz");
app.MapPost("/visit", async (WebAppDbContext dbContext, ISyncService syncService) =>
{
    var newVisit = new Visit
    {
        CloudServiceProvider = CSP.AmazonWebServices
    };
    await dbContext.Visits.AddAsync(newVisit);
    await dbContext.SaveChangesAsync();
    
    // Fire and forget sync (or await depending on consistency requirements)
    await syncService.SyncVisitAsync(newVisit);

    return Results.Ok(newVisit);
}); 
app.MapGet("/visit", async (WebAppDbContext dbContext) =>
{
    var visits = await dbContext.Visits.ToListAsync();
    return visits;
});
app.Run();

public partial class Program { }

