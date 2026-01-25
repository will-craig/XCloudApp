using XCloudApp.Configuration;


var app = WebApplication
         .CreateBuilder(args)
         .ConfigureBuilderServices()
         .Build()
         .ConfigureMiddleware();

app.Run();