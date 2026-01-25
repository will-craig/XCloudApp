using Microsoft.EntityFrameworkCore;
using XCloudApp.Configuration;
using XCloudApp.DAL;
using XCloudApp.Domain.Entities;
using XCloudApp.Domain.Enum;

var app = WebApplication
         .CreateBuilder(args)
         .ConfigureBuilderServices()
         .Build()
         .ConfigureMiddleware();

app.MapHealthChecks("/healthz");
app.MapPost("/visit", async (WebAppDbContext dbContext) =>
{
    var newVisit = new Visit
    {
        CloudServiceProvider = CSP.AmazonWebServices
    };
    await dbContext.Visits.AddAsync(newVisit);
    await dbContext.SaveChangesAsync();
    return Results.Ok(newVisit);
}); 
app.MapGet("/visit", async (WebAppDbContext dbContext) =>
{
    var visits = await dbContext.Visits.ToListAsync();
    return visits;
});
app.Run();

